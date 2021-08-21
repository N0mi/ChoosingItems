using System;
using System.Collections;
using System.Collections.Generic;
using AmayaSoft.TestTask.Data;
using UnityEngine;
using UnityEngine.UI;

public class CellView : MonoBehaviour
{
    [SerializeField] private Image picture;
    [SerializeField] private Image backGround;
    [SerializeField] private Button cellButton;
    private CardData _currentCard;

    private void Awake()
    {
        cellButton.onClick.AddListener(Click);
    }

    private void Click()
    {
        Debug.Log(_currentCard.Identifier);
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
