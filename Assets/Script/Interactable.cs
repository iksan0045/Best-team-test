using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameplayTest
{
    public interface IInteractable
    {
        void Interact(Vector3 playerPos,bool facePlayer,bool runAway, float jumpForce);
    }
}
