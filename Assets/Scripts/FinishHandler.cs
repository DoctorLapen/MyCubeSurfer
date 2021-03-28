using System;
using UnityEngine;

namespace MyCubeSurfer
{
    public class FinishHandler : MonoBehaviour
    {
        [SerializeField]
        private string _playerTag;

        [SerializeField]
        private RectTransform _levelPassedScreen;

        

        
        private void OnTriggerEnter(Collider coll)
        {
            if (coll.CompareTag(_playerTag))
            {
                Time.timeScale = 0;
                _levelPassedScreen.gameObject.SetActive(true);
            }
        }
    }
}