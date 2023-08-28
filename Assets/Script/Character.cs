using UnityEngine;

namespace GameplayTest
{
    public class Character : MonoBehaviour
    {
        private Transform playerTransform;
        public Rigidbody2D rb;
        private float initialScaleX;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            initialScaleX = transform.localScale.x;
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void Update()
        {
            if (playerTransform == null)
            {
                playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            }
        }

        
        //Method diatas warisan dari Iinteractable


        public void FaceDirPlayer(Vector3 playerPos)
        {
            if (playerPos.x > 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }

        }

        public void Jump(float jumpForce)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        public void RunAway(Vector3 playerPos, Vector3 npcPos)
        {
            Vector3 runDirection = (npcPos - playerPos).normalized;

            rb.velocity = new Vector2(runDirection.x * 3.5f, rb.velocity.y);
        }
    }
}
