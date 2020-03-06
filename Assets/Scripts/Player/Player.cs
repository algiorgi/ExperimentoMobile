using UnityEngine;
using experimentomobile.utils;

namespace experimentomobile.player
{
    public class Player : MonoBehaviour
    {
        private Rigidbody playerRigidbody;
        private Animator playerAnimator;

        [SerializeField]
        private float jumpForce = 200f;
        [SerializeField]
        private bool isOnGround;
        [SerializeField]
        private bool isCrouched;

        private void Start()
        {
            playerRigidbody = GetComponent<Rigidbody>();
            playerAnimator = GetComponent<Animator>();
            isOnGround = true;
        }

        private void Update()
        {
            if (!isCrouched && Input.GetKeyDown(KeyCode.LeftControl))
            {
                Crouch();
            }
            if (isCrouched && Input.GetKeyUp(KeyCode.LeftControl))
            {
                Stand();
            }

            playerAnimator.SetBool("Crouched_b", isCrouched);
        }

        private void FixedUpdate()
        {            
            if (isOnGround && Input.GetKey(KeyCode.Space))
            {
                PrepareJump();                
            }
        }

        private void PrepareJump()
        {
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");
        }

        private void Jump()
        {            
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);            
        }

        private void Crouch()
        {
            isCrouched = true;
            playerAnimator.SetTrigger("StandingToCrouched_trig");
        }

        private void Stand()
        {            
            playerAnimator.SetTrigger("CrouchedToStanding_trig");
            isCrouched = false;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(Tags.BASE))
            {
                isOnGround = true;
                playerAnimator.SetBool("OnGround_b", true);
            }
        }
    }
}
