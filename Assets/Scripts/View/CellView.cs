using System;
using System.Collections;
using System.Collections.Generic;
using AmayaSoft.TestTask.Data;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CellView : MonoBehaviour
{
    public UnityEvent<CellView> onClick = new UnityEvent<CellView>();
    public UnityEvent endAnim = new UnityEvent();

    public CardData Card => _currentCard;
    public Image Picture => _picture;
    private CardData _currentCard;
    
    [SerializeField] private Image _picture;
    [SerializeField] private Image _backGround;
    [SerializeField] private Button _cellButton;
    private Tween _punch;

    private void Awake()
    {
        _cellButton.onClick.AddListener(()=> onClick.Invoke(this));
    }

    public void SetCard(CardData card)
    {
        _currentCard = card;
        SetSprite(card.Sprite);
    }

    private void SetSprite(Sprite sprite)
    {
        _picture.sprite = sprite;
    }

    public void SetBackGroundColor(Color color)
    {
        _backGround.color = color;
    }

    public void CorrectAnim()
    {
        _picture.rectTransform.DOLocalJump(Vector3.up, 15f, 2, 0.5f).OnComplete(()=> endAnim.Invoke());
    }

    public void UncorrectAnim()
    {
        if(_punch.IsActive()) _punch.Complete();
        _punch = _picture.rectTransform.DOPunchPosition(Vector3.right * 10f, 0.5f, 20, 5f)
            .OnComplete(() => endAnim.Invoke());
    }
}
