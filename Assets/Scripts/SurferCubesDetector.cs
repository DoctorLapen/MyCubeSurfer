using System;
using UnityEngine;

namespace MyCubeSurfer
{
    public class SurferCubesDetector : MonoBehaviour
    {
        [SerializeField]
        private string _surferCubeTag;

        [SerializeField]
        private SurferCubesController _surferCubesController;

        

        
        private void OnTriggerEnter(Collider coll)
        {
            if (coll.CompareTag(_surferCubeTag))
            {
                CubesSegment cubesSegment = coll.transform.parent.GetComponent<CubesSegment>();
                if (cubesSegment.CubeType == CubeType.Surfer)
                {
                    _surferCubesController.AddSurferCubes(cubesSegment.cubes);
                }
            }
        }
    }
}