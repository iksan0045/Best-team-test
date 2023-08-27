using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameplayTest
{
    public interface IInteractable
    {
        void FacePlayer(Vector3 playerPos, Vector3 npcPos);
        void JumpInteract (float jumpForce);
        void RunAwayInteract(Vector3 playerPos,Vector3 npcPos,float speed);
    }
}
