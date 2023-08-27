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
                //Panggil interaksi dengan npc secara spesifik
                interactable.Interact(transform.position,false,true,0);
            }
        }
    }
}
