using UnityEngine;

namespace GameplayTest
{
    public class Character : MonoBehaviour, Interactable
    {
        private Transform playerTransform;
        private Rigidbody2D rb;
        private float initialScaleX;

        private void Start()
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            rb = GetComponent<Rigidbody2D>();
            initialScaleX = transform.localScale.x;
        }

        private void Update()
        {
            if (playerTransform == null)
            {
                playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            }
        }

        public void Interact(bool facePlayer, float jumpForce, float speed)
        {
            Debug.Log("Interact " + gameObject.name);
            if (facePlayer)
            {
                FaceDirPlayer();
            }

            if (jumpForce > 0)
            {
                Jump(jumpForce);
            }

            if (speed > 0)
            {
                RunAway(speed);
            }
        }

        private void FaceDirPlayer()
        {
            if (playerTransform != null)
            {
                Vector3 directionToPlayer = playerTransform.position - transform.position;
                directionToPlayer.Normalize();
                float newScaleX = initialScaleX * Mathf.Sign(directionToPlayer.x);
                transform.localScale = new Vector3(newScaleX, transform.localScale.y, transform.localScale.z);
            }
        }

        private void Jump(float jumpForce)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        private void RunAway(float speed)
        {
            if (playerTransform != null)
            {
                Vector3 directionToPlayer = playerTransform.position - transform.position;
                directionToPlayer.Normalize();
                rb.velocity = new Vector2(-directionToPlayer.x * speed, rb.velocity.y);
                float newScaleX = initialScaleX * Mathf.Sign(directionToPlayer.x);
                transform.localScale = new Vector3(newScaleX, transform.localScale.y, transform.localScale.z);
            }
        }
    }
}
