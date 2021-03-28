using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyCubeSurfer
{
    public class SurferCubesController : MonoBehaviour
    {
        private const int DETECTOR_CUBE_INDEX = 0; 
        [SerializeField]
        private float _yOffset;

        [SerializeField]
        private Transform _playerSkin;

        [SerializeField]
        private float _playerSkinSizeYScale;

        [SerializeField]
        private string _groundTag;

        [SerializeField]
        private RectTransform _gameOverScreen;

        
        [SerializeField]
        private List<GameObject> _cubes = new List<GameObject>();

        private float _cubeSizeY;
        private float _playerSkinOffsetY;
        private float _groundY;
        private Vector3 _raycastDirection = new Vector3(0,-1,0);
        
        private Collider _startCubeCollider;
        private bool _isNotMovingThrough;


        private void Awake()
        {
            _isNotMovingThrough = true; 
            int startCubeIndex = 0;
             _startCubeCollider = _cubes[startCubeIndex].GetComponent<Collider>();
            _cubeSizeY = _startCubeCollider.bounds.size.y;
            float playerSkinSizeY = _playerSkin.GetComponent<Collider>().bounds.size.y;
            _playerSkinOffsetY = playerSkinSizeY * _playerSkinSizeYScale;
            _groundY = _cubes[startCubeIndex].transform.position.y;
            
        }

        public void AddSurferCubes(List<GameObject> surferCubes)
        {
            int lastCubeIndex = _cubes.Count - 1;
            Vector3 position = _cubes[lastCubeIndex].transform.position;
            for (int i = 0; i < surferCubes.Count; i++)
            {
                GameObject newCube = surferCubes[i];
                position.y += _cubeSizeY + _yOffset;
                newCube.transform.SetParent(transform);
                newCube.transform.position = position;
                _cubes.Add(newCube);
            }

            position.y += _playerSkinOffsetY;
            _playerSkin.position = position;
        }

        public void MoveThroughRoadBlock(int roadBlocksAmount)
        {
            Debug.Log("MoveThroughRoadBlock");
            if (_cubes.Count > roadBlocksAmount)
            {
                ChangeDetectorPosition(roadBlocksAmount);
                DetachRemovedBlocks(roadBlocksAmount);
                StartCoroutine(MoveToGround());
              
            }
            else if (_cubes.Count <= roadBlocksAmount && _isNotMovingThrough)
            {
                Time.timeScale = 0;
                _gameOverScreen.gameObject.SetActive(true);
            }
        }

        private void DetachRemovedBlocks(int roadBlocksAmount)
        {
            int firstItemIndex = 0;
            for (int i = 0; i < roadBlocksAmount; i++)
            {
                GameObject cube = _cubes[firstItemIndex];
                _cubes.RemoveAt(firstItemIndex);
                cube.transform.parent = null;
            }
        }

        private void ChangeDetectorPosition(int newPositionIndex)
        {
            GameObject detectorCube = _cubes[DETECTOR_CUBE_INDEX];
            GameObject topCube = _cubes[newPositionIndex];
            Vector3 topPosition = topCube.transform.position;
            Vector3 detectorCubePosition = detectorCube.transform.position;
            topCube.transform.position = detectorCubePosition;
            detectorCube.transform.position = topPosition;
            _cubes[DETECTOR_CUBE_INDEX] = topCube;
            _cubes[newPositionIndex] = detectorCube;
        }

        private IEnumerator MoveToGround()
        {
            _isNotMovingThrough = false;
            bool isNotGroundFound = true;
            RaycastHit raycastHit;
            do
            {
                Vector3 origin = _startCubeCollider.transform.position;
                float nearZ = origin.z - _startCubeCollider.bounds.size.z / 2;
                origin.z = nearZ ;
                if (Physics.Raycast(origin, _raycastDirection, out raycastHit))
                {
                    isNotGroundFound = !raycastHit.collider.CompareTag(_groundTag);
                }

                yield return null;
            } while (isNotGroundFound);

            float newY = _groundY;
            Vector3 newPosition = Vector3.zero;
            for (int i = 0; i < _cubes.Count; i++)
            {
                GameObject cube = _cubes[i];
                newPosition = cube.transform.position;
                newPosition.y = newY;
                cube.transform.position = newPosition ;
                if (_cubes.Count != 1)
                {
                     newY += _cubeSizeY + _yOffset;
                }
                
            }
            newPosition = _playerSkin.position;
            newPosition.y = newY + _playerSkinOffsetY;
            _playerSkin.position = newPosition;
            _isNotMovingThrough = true;
        }
    }
}