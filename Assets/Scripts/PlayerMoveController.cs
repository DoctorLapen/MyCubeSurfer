
using UnityEngine;

namespace MyCubeSurfer
{
    public class PlayerMoveController : MonoBehaviour
    {
        [SerializeField]
        private float _speed;

        private void Awake()
        {
            Time.timeScale = 1;
            CurrentMoveProperties.sideMove = SideMove.Allowed;
            CurrentMoveProperties.moveDirection = MoveDirection.Straight;
        }


        private void FixedUpdate()
        {
            
            float sideMove = (float) CurrentMoveProperties.moveDirection * _speed * (float)CurrentMoveProperties.sideMove;
            transform.position += transform.forward *= _speed;
            transform.position += transform.right * sideMove;
        }

        public void MoveAwayFromWall(Vector3 wallPosition)
        {
            float directionValue = wallPosition.x - transform.position.x;
            MoveDirection backMoveDirection;
            if (directionValue > 0)
            {
                backMoveDirection = MoveDirection.Left;
            }
            else
            {
                backMoveDirection = MoveDirection.Right;
            }

            float x =  _speed * (float)backMoveDirection;
            transform.position += transform.right *  x;
        }

    }
}