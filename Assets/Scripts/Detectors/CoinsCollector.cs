using System;
using UnityEngine;

namespace MyCubeSurfer
{
    public class CoinsCollector : MonoBehaviour
    {
        [SerializeField]
        private string _coinTag;

        [SerializeField]
        private CoinsView _coinsView;

        

        private int _coinsAmount = 0;
        

        
        private void OnTriggerEnter(Collider coll)
        {
            if (coll.CompareTag(_coinTag))
            {
                _coinsAmount++;
                _coinsView.UpdateCoins(_coinsAmount);
                Destroy(coll.gameObject);
            }
        }
    }
}