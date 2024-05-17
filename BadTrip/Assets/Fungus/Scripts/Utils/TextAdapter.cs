// This code is part of the Fungus library (https://github.com/snozbot/fungus)
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using TMPro;

namespace Fungus
{
    /// <summary>
    /// Helper class for hiding the many, many ways we might want to show text to the user.
    /// </summary>
    public class TextAdapter : IWriterTextDestination
    {
        protected TextMeshProUGUI textUI;
        protected InputField inputField;
#if UNITY_2018_1_OR_NEWER
        protected TMPro.TMP_Text tmpro;
#endif
        protected Component textComponent;
        protected PropertyInfo textProperty;
        protected IWriterTextDestination writerTextDestination;

        public void InitFromGameObject(GameObject go, bool includeChildren = false)
        {
            if (go == null)
            {
                return;
            }

            if (!includeChildren)
            {
                textUI = go.GetComponent<TextMeshProUGUI>();
                inputField = go.GetComponent<InputField>();
#if UNITY_2018_1_OR_NEWER
                tmpro = go.GetComponent<TMPro.TMP_Text>();
#endif
                writerTextDestination = go.GetComponent<IWriterTextDestination>();
            }
            else
            {
                textUI = go.GetComponentInChildren<TextMeshProUGUI>();
                inputField = go.GetComponentInChildren<InputField>();
#if UNITY_2018_1_OR_NEWER
                tmpro = go.GetComponentInChildren<TMPro.TMP_Text>();
#endif
                writerTextDestination = go.GetComponentInChildren<IWriterTextDestination>();
            }
            
            // Try to find any component with a text property
            if (textUI == null && inputField == null && writerTextDestination == null)
            {
                Component[] allcomponents = null;
                if (!includeChildren)
                    allcomponents = go.GetComponents<Component>();
                else
                    allcomponents = go.GetComponentsInChildren<Component>();

                for (int i = 0; i < allcomponents.Length; i++)
                {
                    var c = allcomponents[i];
                    textProperty = c.GetType().GetProperty("text");
                    if (textProperty != null)
                    {
                        textComponent = c;
                        break;
                    }
                }
            }
        }

        public void ForceRichText()
        {
            if (textUI != null)
            {
                textUI.richText = true;
            }

#if UNITY_2018_1_OR_NEWER
            if (tmpro != null)
            {
                tmpro.richText = true;
            }
#endif

            if (writerTextDestination != null)
            {
                writerTextDestination.ForceRichText();
            }
        }

        public void SetTextColor(Color textColor)
        {
            if (textUI != null)
            {
                textUI.color = textColor;
            }
            else if (inputField != null)
            {
                if (inputField.textComponent != null)
                {
                    inputField.textComponent.color = textColor;
                }
            }
#if UNITY_2018_1_OR_NEWER
            else if (tmpro != null)
            {
                tmpro.color = textColor;
            }
#endif
            else if (writerTextDestination != null)
            {
                writerTextDestination.SetTextColor(textColor);
            }
        }

        public void SetTextAlpha(float textAlpha)
        {
            if (textUI != null)
            {
                Color tempColor = textUI.color;
                tempColor.a = textAlpha;
                textUI.color = tempColor;
            }
            else if (inputField != null)
            {
                if (inputField.textComponent != null)
                {
                    Color tempColor = inputField.textComponent.color;
                    tempColor.a = textAlpha;
                    inputField.textComponent.color = tempColor;
                }
            }
#if UNITY_2018_1_OR_NEWER
            else if (tmpro != null)
            {
                tmpro.alpha = textAlpha;
            }
#endif
            else if (writerTextDestination != null)
            {
                writerTextDestination.SetTextAlpha(textAlpha);
            }
        }

        public bool HasTextObject()
        {
            return (textUI != null || inputField != null || textComponent != null ||
#if UNITY_2018_1_OR_NEWER
                tmpro != null ||
#endif
                 writerTextDestination != null);
        }

        public bool SupportsRichText()
        {
            if (textUI != null)
            {
                return textUI.richText;
            }
            if (inputField != null)
            {
                return false;
            }
#if UNITY_2018_1_OR_NEWER
            if (tmpro != null)
            {
                return true;
            }
#endif
            if (writerTextDestination != null)
            {
                return writerTextDestination.SupportsRichText();
            }
            return false;
        }

        public bool SupportsHiddenCharacters()
        {
#if UNITY_2018_1_OR_NEWER
            if (tmpro != null)
            {
                return true;
            }
#endif
            return false;
        }

        public int RevealedCharacters
        {
            get
            {
#if UNITY_2018_1_OR_NEWER
                if (tmpro != null)
                {
                    return tmpro.maxVisibleCharacters;
                }
#endif
                return 0;
            }
            set
            {
#if UNITY_2018_1_OR_NEWER
                if (tmpro != null)
                {
                    tmpro.maxVisibleCharacters = value;
                }
#endif
            }
        }

        public char LastRevealedCharacter
        {
            get
            {
#if UNITY_2018_1_OR_NEWER
                if (tmpro != null && tmpro.textInfo != null && tmpro.textInfo.characterInfo != null)
                {
                    if (tmpro.maxVisibleCharacters < tmpro.textInfo.characterInfo.Length && tmpro.maxVisibleCharacters > 0)
                    {
                        return tmpro.textInfo.characterInfo[tmpro.maxVisibleCharacters - 1].character;
                    }
                }
#endif
                return (char)0;
            }
        }

        public int CharactersToReveal
        {
            get
            {
#if UNITY_2018_1_OR_NEWER
                if (tmpro != null)
                {
                    return tmpro.textInfo.characterCount;
                }
#endif
                return 0;
            }
        }

        public virtual string Text
        {
            get
            {
                if (textUI != null)
                {
                    return textUI.text;
                }
                else if (inputField != null)
                {
                    return inputField.text;
                }
                else if (writerTextDestination != null)
                {
                    return Text;
                }
#if UNITY_2018_1_OR_NEWER
                else if (tmpro != null)
                {
                    return tmpro.text;
                }
#endif
                else if (textProperty != null)
                {
                    return textProperty.GetValue(textComponent, null) as string;
                }

                return "";
            }

            set
            {
                if (textUI != null)
                {
                    textUI.text = value;
                }
                else if (inputField != null)
                {
                    inputField.text = value;
                }
                else if (writerTextDestination != null)
                {
                    Text = value;
                }
#if UNITY_2018_1_OR_NEWER
                else if (tmpro != null)
                {
                    tmpro.text = value;
                    tmpro.ForceMeshUpdate();
                }
#endif
                else if (textProperty != null)
                {
                    textProperty.SetValue(textComponent, value, null);
                }
            }
        }
    }
}