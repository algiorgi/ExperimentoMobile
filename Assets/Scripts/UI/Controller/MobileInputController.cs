using UnityEngine;
using UnityEngine.UI;
using experimentomobile.player;
using UnityEngine.EventSystems;

namespace experimentomobile.ui.controller
{
    public class MobileInputController : MonoBehaviour
    {
        private Player player;
        [SerializeField]
        private Button jumpButton;
        [SerializeField]
        private Button crouchButton;

        private void Start()
        {
            player = GameObject.Find("Player").GetComponent<Player>();

            jumpButton.onClick.AddListener(() => player.PrepareJump());

            EventTrigger trigger = crouchButton.gameObject.AddComponent<EventTrigger>();
            trigger.triggers.Add(CreateCrouchHandler());
            trigger.triggers.Add(CreateStandHandler());
        }

        private EventTrigger.Entry CreateCrouchHandler()
        {
            EventTrigger.Entry handler = new EventTrigger.Entry
            {
                eventID = EventTriggerType.PointerDown
            };
            handler.callback.AddListener((e) => player.Crouch());
            return handler;
        }

        private EventTrigger.Entry CreateStandHandler()
        {
            EventTrigger.Entry handler = new EventTrigger.Entry
            {
                eventID = EventTriggerType.PointerUp
            };
            handler.callback.AddListener((e) => player.Stand());
            return handler;
        }
    }
}
