using System;
using UnityEngine;

namespace MyCubeSurfer
{
    public class InvisibleWallsDetector : MonoBehaviour
    {
        [SerializeField]
        private string _invisibleWallTag;

        [SerializeField]
        private PlayerMoveController _playerMoveController;

        
        
        private void OnTriggerEnter(Collider coll)
        {
            if (coll.CompareTag(_invisibleWallTag))
            {
                MoveProperties.sideMove = SideMove.NotAllowed;
            }
        }

        private void OnTriggerStay(Collider coll)
        {
            if (coll.CompareTag(_invisibleWallTag))
            {
                _playerMoveController.MoveAwayFromWall(coll.transform.position);
            }
        }

        private void OnTriggerExit(Collider coll)
        {
            if (coll.CompareTag(_invisibleWallTag))
            {
                 MoveProperties.sideMove = SideMove.Allowed;
            }
        }
    }
}