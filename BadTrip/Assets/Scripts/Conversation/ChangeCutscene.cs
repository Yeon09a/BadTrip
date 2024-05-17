using UnityEngine;

namespace Fungus
{
    [CommandInfo("Custom",
                 "Change Cutscene",
                 "�ƾ� sprite ����")]
    [AddComponentMenu("")]
    public class ChangeCutscene : Command
    {
        [Tooltip("������ View�� SpriteRenderer")]
        [SerializeField] protected SpriteRenderer spriteRenderer;

        [Tooltip("������ sprite")]
        [SerializeField] protected Sprite sprite;

        // Start is called before the first frame update
        void Start()
        {

        }

        public override void OnEnter()
        {
            spriteRenderer.sprite = sprite;

            Continue();
        }
    }
}
