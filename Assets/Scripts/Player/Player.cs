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

        private void Start()
        {
            playerRigidbody = GetComponent<Rigidbody>();
            playerAnimator = GetComponent<Animator>();
            isOnGround = true;
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
