using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameplayTest
{
    public interface Interactable
    {
        void Interact(bool facePlayer,float jumpForce,float run);
    }
}
