using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Fungus
{
    [CommandInfo("Custom",
                     "GetPlayerData",
                     "PlayerDataSO ��������")]
    [AddComponentMenu("")]
    public class GetPlayerData : Command
    {
        [SerializeField] protected PlayerDataSO playerDataSO;
        [SerializeField] protected string paramName = "";

        [VariableProperty(typeof(BooleanVariable),
                          typeof(IntegerVariable),
                          typeof(FloatVariable),
                          typeof(StringVariable))]
        [SerializeField] protected Variable variable;

        public override void OnEnter()
        {
            FieldInfo fieldInfo = playerDataSO.GetType().GetField(paramName);

            if (fieldInfo != null)
            {
                System.Type variableType = variable.GetType();

                if (variableType == typeof(BooleanVariable))
                {
                    BooleanVariable booleanVariable = variable as BooleanVariable;
                    if (booleanVariable != null)
                    {
                        booleanVariable.Value = (bool)fieldInfo.GetValue(playerDataSO);
                    }
                }
                else if (variableType == typeof(IntegerVariable))
                {
                    IntegerVariable integerVariable = variable as IntegerVariable;
                    if (integerVariable != null)
                    {
                        integerVariable.Value = (int)fieldInfo.GetValue(playerDataSO);
                    }
                }
                else if (variableType == typeof(FloatVariable))
                {
                    FloatVariable floatVariable = variable as FloatVariable;
                    if (floatVariable != null)
                    {
                        floatVariable.Value = (float)fieldInfo.GetValue(playerDataSO);
                    }
                }
                else if (variableType == typeof(StringVariable))
                {
                    StringVariable stringVariable = variable as StringVariable;
                    if (stringVariable != null)
                    {
                        stringVariable.Value = fieldInfo.GetValue(playerDataSO).ToString();
                    }
                }
            }

            Debug.Log(variable.GetValue());

            Continue();
        }
    }
}
