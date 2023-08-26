using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameplayTest
{
    public class CharacterPlayer : MonoBehaviour
    {

        private Rigidbody2D _rb;

        //Circle collider untuk mengatur radius interaksi player dengan character lain
        [SerializeField]
        private CircleCollider2D _circleCollider2D;

        private float interactJump;

        private float interactRun;

        private bool interactFace;

        private float scaleX;


        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        public float _jumpForce;

        private bool _isGround;

        //input tombol jump
        bool JumpBtnIsPressed => Input.GetKeyDown(KeyCode.Space);

        [SerializeField]
        private LayerMask _groundLayer;

        public int charId;



        // Start is called before the first frame update
        void Start()
        {
            _circleCollider2D = GetComponent<CircleCollider2D>();
            scaleX = transform.localScale.x;
            _rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            _isGround = Physics2D.Raycast(transform.position, Vector3.down, 1.5f, _groundLayer);
            float moveDir = Input.GetAxis("Horizontal");
            _rb.velocity = new Vector2(moveDir * 2.5f, _rb.velocity.y);

            if (moveDir > 0)
            {
                transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
            }
            else if (moveDir < 0)
            {
                transform.localScale = new Vector3(scaleX * -1f, transform.localScale.y, transform.localScale.z);
            }


            if (_isGround && JumpBtnIsPressed)
            {
                Jump(_jumpForce);
            }
        }

        private void Jump(float jumpForce)
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
        

        private void OnTriggerEnter2D(Collider2D other)
        {
            Interactable interactable = other.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.Interact(interactFace, interactJump, interactRun);
            }
        }


        public void SetCharacterId(int id)
        {
            Debug.Log("ID" + id);
            SyncChar(id);
        }

        private void SyncChar(int id)
        {
            switch (id)
            {
                case 0:
                    _jumpForce = 0;
                    _spriteRenderer.color = Color.cyan;
                    break;

                case 1:
                    _jumpForce = 5f;
                    _spriteRenderer.color = Color.blue;
                    break;

                case 2:
                    _spriteRenderer.color = Color.yellow;
                    interactFace = true;
                    _circleCollider2D.radius = 4;
                    _jumpForce = 0;
                    break;

                case 3:
                    _spriteRenderer.color = Color.green;
                    _circleCollider2D.radius = 4;
                    interactJump = 5;
                    _jumpForce = 5f;
                    break;

                case 4:
                    _spriteRenderer.color = Color.red;
                    interactRun = 3.5f;
                    _circleCollider2D.radius = 4;
                    _jumpForce = 5f;
                    break;
            }
        }
    }
}
