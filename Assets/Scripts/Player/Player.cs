using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace experimentomobile.player
{
    public class Player : MonoBehaviour
    {
        private Rigidbody playerRigidbody;

        [SerializeField]
        private float jumpForce = 300f;
        [SerializeField]
        private bool isOnGround;

        private void Start()
        {
            playerRigidbody = GetComponent<Rigidbody>();
            isOnGround = true;
        }

        private void FixedUpdate()
        {
            if (isOnGround && Input.GetKey(KeyCode.Space))
            {
                Jump();
            }
        }

        private void Jump()
        {
            isOnGround = false;
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Base"))
            {
                isOnGround = true;
            }
        }
    }
}
