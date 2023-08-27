using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameplayTest
{
    public class NpcChar1 : Character, IInteractable
    {
        // Start is called before the first frame update
        
        void Start()
        {
                
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void  Interact(Vector3 sourcePos,int id)
        {
            Debug.Log("Interact from" + gameObject.name);
            if (id == 1)
            {
                base.FaceDirPlayer(sourcePos,transform.position);
            }
            else if (id == 2)
            {
                base.Jump(3.5f);
            }
            else if (id == 3)
            {
                base.RunAway(sourcePos,transform.position,3.4f);
            }
        }
    }
}
