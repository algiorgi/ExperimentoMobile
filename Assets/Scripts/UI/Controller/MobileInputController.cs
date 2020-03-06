using UnityEngine;
using UnityEngine.UI;
using experimentomobile.player;

namespace experimentomobile.ui.controller
{
    public class MobileInputController : MonoBehaviour
    {
        private Player player;
        [SerializeField]
        private Button jumpButton;

        private void Start()
        {
            player = GameObject.Find("Player").GetComponent<Player>();

            jumpButton.onClick.AddListener(() => player.PrepareJump());
        }
    }
}
