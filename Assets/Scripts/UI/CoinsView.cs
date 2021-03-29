using UnityEngine;
using UnityEngine.UI;

namespace MyCubeSurfer
{
    public class CoinsView : MonoBehaviour
    {
        [SerializeField]
        private Text _coinsText;

        [SerializeField]
        private string _startText;

        

        public void UpdateCoins(int coins)
        {
            _coinsText.text = coins.ToString();
        }


    }
}