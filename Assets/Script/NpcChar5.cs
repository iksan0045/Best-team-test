using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameplayTest
{
    public class NpcChar5 : Character, IInteractable
    {
        [SerializeField]
        private int behaviourValue;
        private CharacterPlayer _characterController;

        private void Start()
        {
            _characterController = GetComponent<CharacterPlayer>();
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("There is object");
            IInteractable interactable = other.GetComponent<IInteractable>();
            if (interactable != null && _characterController.isPlayer)
            {
                //Vector3 directrionPos = transform.position - other.transform.position;
                //directrionPos.Normalize();
                //direction = directrionPos.x;
                interactable.Interact(transform.position, behaviourValue);
                Debug.Log("Call interactable");
            }
        }

        public void Interact(Vector3 sourcePos, int id)
        {
            Debug.Log("Interact from" + gameObject.name);
            if (id == 1)
            {
                base.FaceDirPlayer(sourcePos, transform.position);
            }
            else if (id == 2)
            {
                base.Jump(3.5f);
            }
            else if (id == 3)
            {
                base.RunAway(sourcePos, transform.position, 3.4f);
            }
        }
    }
}
