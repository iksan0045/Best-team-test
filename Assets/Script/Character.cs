using UnityEngine;

namespace GameplayTest
{
    public class Character : MonoBehaviour,IInteractable
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

        public void FacePlayer(Vector3 playerPos,Vector3 npcPos)
        {
            FaceDirPlayer(playerPos,npcPos);
        }

        public void JumpInteract(float jumpForce)
        {
            Jump(jumpForce);
        }

        public void RunAwayInteract(Vector3 playerPos,Vector3 npcPos,float speed)
        {
            RunAway(playerPos,npcPos,speed);
        }
        //Method diatas warisan dari Iinteractable


        private void FaceDirPlayer(Vector3 playerPos, Vector3 npcPos)
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

        private void Jump(float jumpForce)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        private void RunAway(Vector3 playerPos, Vector3 npcPos, float speed)
        {
            Vector3 runDirection = (npcPos - playerPos).normalized;

            rb.velocity = new Vector2(runDirection.x * speed, rb.velocity.y);
        }
    }
}
