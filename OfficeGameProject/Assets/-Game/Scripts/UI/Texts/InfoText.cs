using System;
using _Game.Scripts;
using TMPro;
using UnityEngine;

namespace _Game.Code.UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class InfoText : MonoBehaviour
    {
        public InfoData infoData;
        private TMP_Text text;

        private void Awake()
        {
            text = GetComponent<TMP_Text>();
UpdateText(infoData.Info);
        }

        private void OnEnable()
        {
            infoData.onInfoUpdated += UpdateText;
        }

        private void OnDisable()
        {
            infoData.onInfoUpdated -= UpdateText;
        }

        private void UpdateText(string obj)
        {
            text.text = obj;
        }
    }
}