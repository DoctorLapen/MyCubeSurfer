using System;
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
        private List<GameObject> _cubes = new List<GameObject>();

        private float _cubeSizeY;
        private float _playerSkinOffsetY;

        private void Awake()
        {
            int startCubeIndex = 0;
            _cubeSizeY = _cubes[startCubeIndex].GetComponent<Collider>().bounds.size.y;
            float playerSkinSizeY = _playerSkin.GetComponent<Collider>().bounds.size.y;
            _playerSkinOffsetY = playerSkinSizeY * _playerSkinSizeYScale;
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
    }
}