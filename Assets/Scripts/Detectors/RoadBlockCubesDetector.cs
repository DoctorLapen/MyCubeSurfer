using UnityEngine;

namespace MyCubeSurfer
{
    public class RoadBlockCubesDetector:MonoBehaviour
    {
        [SerializeField]
        private string _roadBlockCubeTag;

        [SerializeField]
        private SurferCubesController _surferCubesController;

        

        
        private void OnTriggerEnter(Collider coll)
        {
            if (coll.CompareTag(_roadBlockCubeTag))
            {
                CubesSegment cubesSegment = coll.transform.parent.GetComponent<CubesSegment>();
                if (cubesSegment.CubeType == CubeType.Roadblock)
                {
                    _surferCubesController.MoveThroughRoadBlock(cubesSegment.cubes.Count);
                }
            }
        }
    }
}