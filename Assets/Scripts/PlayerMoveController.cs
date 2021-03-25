
using UnityEngine;

namespace MyCubeSurfer
{
    public class PlayerMoveController : MonoBehaviour
    {
        [SerializeField]
        private float _speed;

        private void Awake()
        {
            CurrentMoveProperties.sideMove = SideMove.Allowed;
            CurrentMoveProperties.moveDirection = MoveDirection.Straight;
        }


        private void FixedUpdate()
        {
            
            float x = (float) CurrentMoveProperties.moveDirection * _speed * (float)CurrentMoveProperties.sideMove;
            transform.position += new Vector3(x, 0, _speed);
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
            transform.position += new Vector3(x, 0, _speed);
        }

    }
}