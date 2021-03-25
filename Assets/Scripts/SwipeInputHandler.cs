using System;
using UnityEngine;

namespace MyCubeSurfer
{
    public class SwipeInputHandler : MonoBehaviour
    {
        [SerializeField]
        private float _minDistanceForSwipe;
        
        private Vector2 _pointA;
        private Vector2 _pointB;
        
        

        public void Update()
        {
            
            
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                     _pointA = touch.position;
                     _pointB = touch.position;

                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    _pointB = touch.position;
                    if (IsSwipe())
                    {
                            if (IsHorizontalSwipe())
                            {
                                

                                float swipeDirection = _pointB.x - _pointA.x;
                                //Right
                                if (swipeDirection > 0)
                                {
                                    CurrentMoveProperties.moveDirection = MoveDirection.Right;
                                }
                                //Left
                                else
                                {
                                    CurrentMoveProperties.moveDirection = MoveDirection.Left;
                                }

                            }
                            
                            
                    }
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    CurrentMoveProperties.moveDirection = MoveDirection.Straight;
                    
                }
                
            }
            
        }

       
        

        private bool IsSwipe()
        {
            return CalculateHorizontalMovement() > _minDistanceForSwipe || CalculateVerticalMovement() > _minDistanceForSwipe;
        }

        private bool IsHorizontalSwipe()
        {
            return CalculateVerticalMovement() < CalculateHorizontalMovement();
        }

        private float CalculateHorizontalMovement()
        {
            return Mathf.Abs(_pointB.x - _pointA.x);
        }
        private float CalculateVerticalMovement() 
        {
            return Mathf.Abs(_pointB.y - _pointA.y);
        }
    }
}