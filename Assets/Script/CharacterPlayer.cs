using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameplayTest
{
    public class CharacterPlayer : MonoBehaviour
    {

        private Rigidbody2D _rb;

        public bool isPlayer;

        //Circle collider untuk mengatur radius interaksi player dengan character lain
        [SerializeField]
        private CircleCollider2D _circleCollider2D;

        private float scaleX;

        [SerializeField]
        private float _jumpForce;

        private float _moveDir;

        private bool _isGround;

        //input tombol jump
        bool JumpBtnIsPressed => Input.GetKeyDown(KeyCode.Space) && isPlayer;

        [SerializeField]
        private LayerMask _groundLayer;



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
            if (isPlayer)
            {
                _moveDir = Input.GetAxis("Horizontal");
            }
            if (_moveDir != 0)
            {
                Move(_moveDir);
            }
            if (_moveDir > 0)
            {
                transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
            }
            else if (_moveDir < 0)
            {
                transform.localScale = new Vector3(scaleX * -1f, transform.localScale.y, transform.localScale.z);
            }


            if (_isGround && JumpBtnIsPressed)
            {
                Jump(_jumpForce);
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            IInteractable interactable = other.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
            
        }

        public void Move(float moveDir)
        {
            _rb.velocity = new Vector2(moveDir * 2.5f, _rb.velocity.y);
        }
        private void Jump(float jumpForce)
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }

        public void SetAsPlayer()
        {
            isPlayer = true;
        }


    }
}
