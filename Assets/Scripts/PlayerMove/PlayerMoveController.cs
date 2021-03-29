
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
            MoveProperties.sideMove = SideMove.Allowed;
            MoveProperties.moveDirection = MoveDirection.Straight;
        }


        private void FixedUpdate()
        {
            if (MoveProperties.isPlayGame)
            {
                float sideMove = (float) MoveProperties.moveDirection * _speed * (float)MoveProperties.sideMove;
                transform.position += transform.forward *= _speed;
                transform.position += transform.right * sideMove;
            }
            
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