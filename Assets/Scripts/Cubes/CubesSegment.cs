using System.Collections.Generic;
using UnityEngine;

namespace MyCubeSurfer
{
    public class CubesSegment : MonoBehaviour
    {
        [SerializeField]
        private CubeType _cubeType;

        public CubeType CubeType
        {
            get { return this._cubeType; }
        }

        
        
        public List<GameObject> cubes = new List<GameObject>();
        
    }
}