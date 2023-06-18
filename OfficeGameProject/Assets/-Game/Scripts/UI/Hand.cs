using System;
using _Game.Scripts;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    public StateEnterEvent stateEnterEvent;
    public StateExitEvent stateExitEvent;
    public Transform realWorldObject;
    private RectTransform rectTransform;
    private Image hand;

    private void Awake()
    {
        hand = GetComponentInChildren<Image>();
        hand.enabled = false;
    }

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        transform.DOScale(0.9f, 0.75f).SetEase(Ease.OutSine).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnEnable()
    {
        stateEnterEvent.onStateEnter += DrawHandle;
        stateExitEvent.onStateExit += HideHandle;
    }

    private void OnDisable()
    {
        stateEnterEvent.onStateEnter -= DrawHandle;
        stateExitEvent.onStateExit -= HideHandle;
    }

    private void HideHandle(State obj)
    {
        hand.enabled = false;
    }

    private void DrawHandle(State obj)
    {
        if (stateEnterEvent.stateMainObject)
        {
            realWorldObject = stateEnterEvent.stateMainObject.transform;
            if (realWorldObject)
            {
                DOTween.Sequence().AppendInterval(1f).AppendCallback(delegate
                {
                    var screenPos = Camera.main.WorldToScreenPoint(realWorldObject.position);
                    var uiPos = new Vector3(screenPos.x, screenPos.y, screenPos.z);
                    rectTransform.position = uiPos;
                    hand.enabled = true;
                });
            }
        }
        else
        {
            realWorldObject = null;
            hand.enabled = false;

        }
    }
}