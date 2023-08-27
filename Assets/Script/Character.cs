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

        public void Interact(Vector3 playerPos,bool facePlayer,bool runAway, float jumpForce)
        {
            if (facePlayer)
            {
                FaceDirPlayer(playerPos);
            }
            else if (jumpForce > 0)
            {
                Jump(jumpForce);
            }
            else if (runAway)
            {
                RunAway(playerPos,transform.position);
            }
        }
        //Method diatas warisan dari Iinteractable


        private void FaceDirPlayer(Vector3 playerPos)
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

        private void RunAway(Vector3 playerPos, Vector3 npcPos)
        {
            Vector3 runDirection = (npcPos - playerPos).normalized;

            rb.velocity = new Vector2(runDirection.x * 3.2f, rb.velocity.y);
        }
    }
}
