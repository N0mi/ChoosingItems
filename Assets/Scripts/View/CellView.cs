using System;
using System.Collections;
using System.Collections.Generic;
using AmayaSoft.TestTask.Data;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CellView : MonoBehaviour
{
    public UnityEvent<CellView> onClick = new UnityEvent<CellView>();

    public CardData Card => _currentCard;
    private CardData _currentCard;
    
    [SerializeField] private Image picture;
    [SerializeField] private Image backGround;
    [SerializeField] private Button cellButton;
    
    private void Awake()
    {
        cellButton.onClick.AddListener(()=> onClick.Invoke(this));
    }

    public void SetCard(CardData card)
    {
        _currentCard = card;
        SetSprite(card.Sprite);
    }

    private void SetSprite(Sprite sprite)
    {
        picture.sprite = sprite;
    }

    public void SetBackGroundColor(Color color)
    {
        backGround.color = color;
    }
}
