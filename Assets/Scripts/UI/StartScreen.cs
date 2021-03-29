using System;
using UnityEngine;

namespace MyCubeSurfer
{
    public class StartScreen : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _gameScreen;

        private void Awake()
        {
            MoveProperties.isPlayGame = false;
        }


        private void Update()
        {
            if (Input.touchCount > 0)
            {
                _gameScreen.gameObject.SetActive(true);
                gameObject.SetActive(false);
                MoveProperties.isPlayGame = true;
            }
        }
    }
}