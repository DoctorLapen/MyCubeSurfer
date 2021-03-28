using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyCubeSurfer
{
    public class SurferCubesController : MonoBehaviour
    {
        [SerializeField]
        private float _yOffset;

        [SerializeField]
        private Transform _playerSkin;

        [SerializeField]
        private float _playerSkinSizeYScale;

        [SerializeField]
        private string _groundTag;

        

        

        [SerializeField]
        private List<GameObject> _cubes = new List<GameObject>();

        private float _cubeSizeY;
        private float _playerSkinOffsetY;
        private float _groundY;
        private Vector3 _raycastDirection = new Vector3(0,-1,0);
        private Collider _startCubeCollider;


        private void Awake()
        {
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
            if (_cubes.Count > roadBlocksAmount)
            {
                int cubesAmountDifference = _cubes.Count - roadBlocksAmount;
                int cubeIndex = _cubes.Count - 1;
                Vector3 topPosition = _cubes[cubesAmountDifference].transform.position;
                for (int i = 0; i < roadBlocksAmount;i++ )
                {
                    GameObject cube = _cubes[cubeIndex];
                    _cubes.RemoveAt(cubeIndex);
                    cube.transform.parent = null;
                    cubeIndex--;

                }
                for (int i = 0; i < _cubes.Count; i++)
                {
                    GameObject cube = _cubes[i];
                    cube.transform.position = topPosition;
                    topPosition.y += _cubeSizeY + _yOffset;
                }

                StartCoroutine(MoveToGround());

            }
            else
            {
            }
        }

        private IEnumerator MoveToGround()
        {
            bool isNotGroundFound = true;
            RaycastHit raycastHit;
            do
            {
                if (Physics.Raycast(_startCubeCollider.transform.position, _raycastDirection, out raycastHit))
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
        }
    }
}