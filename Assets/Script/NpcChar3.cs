using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameplayTest
{
    public class NpcChar3 : Character, IInteractable
    {
        //Mengandung behavior khusus interaksi dengan character lain
        [SerializeField]
        private int behaviourValue;

        private CharacterPlayer _characterController;
        private Vector3 playerPos;

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
                //Panggil interaksi dengan npc secara spesifik sesuai char dan interaksi yang diberikan
                //bisa ditambahkan variabel baru sesuai 
                playerPos = other.transform.position;
            }
        }

        public void Interact()
        {
            base.FaceDirPlayer(playerPos);
        }

       
    }
}
