using System;
using UnityEngine;

namespace MyCubeSurfer
{
    public class PlayerMoveController : MonoBehaviour
    {
        [SerializeField]
        private float _speed;

        

        

        private void FixedUpdate()
        {
            transform.position += new Vector3((float)CurrentMoveDirection.value *_speed , 0, _speed);
        }
    }
}