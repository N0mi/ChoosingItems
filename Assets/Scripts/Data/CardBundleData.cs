using System;
using System.Collections.Generic;
using UnityEngine;

namespace AmayaSoft.TestTask.Data
{
    public class SpriteRotatable
    {
        private Sprite _sprite;
    }
    
    [Serializable]
    public class CardData
    {
        public string Identifier => _identifier;
        [SerializeField] private string _identifier;
        
        public Sprite Sprite => _sprite;
        [SerializeField] private Sprite _sprite;
    }
    
    [CreateAssetMenu(fileName = "New CardBundleData", menuName = "Card Bundle Data")]
    public class CardBundleData : ScriptableObject
    {
        [SerializeField] private CardData[] _cardData;

        public IReadOnlyList<CardData> CardData => _cardData;
    }
}