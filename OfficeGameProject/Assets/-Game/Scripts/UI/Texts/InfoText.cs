using System;
using _Game.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Game.Code.UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class InfoText : MonoBehaviour
    {
        [FormerlySerializedAs("infoData")] public InfoEvent ınfoEvent;
        private TMP_Text text;

        private void Awake()
        {
            text = GetComponent<TMP_Text>();
UpdateText(ınfoEvent.Info);
        }

        private void OnEnable()
        {
            ınfoEvent.onInfoUpdated += UpdateText;
        }

        private void OnDisable()
        {
            ınfoEvent.onInfoUpdated -= UpdateText;
        }

        private void UpdateText(string obj)
        {
            text.text = obj;
        }
    }
}