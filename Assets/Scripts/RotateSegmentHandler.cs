using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyCubeSurfer
{
    public class RotateSegmentHandler : MonoBehaviour
    {
        [SerializeField]
        private string _playerTag;

        [SerializeField]
        private float _rotateSpeed;

      

        private Vector3 _rotateAngle = new Vector3(0, 90, 0);

        

        

        
        private void OnTriggerStay(Collider coll)
        {
            if (coll.CompareTag(_playerTag))
            {
                if (coll.transform.parent.transform.eulerAngles.y < _rotateAngle.y)
                {
                    coll.transform.parent.transform.eulerAngles +=  new Vector3(0, _rotateSpeed, 0);
                }
            }
        }
    }
}
