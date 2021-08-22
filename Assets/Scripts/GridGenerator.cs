using System;
using System.Linq;
using AmayaSoft.TestTask.Data;
using UnityEngine;
using Utilites;
using Random = UnityEngine.Random;

namespace AmayaSoft.TestTask
{
    public class GridGenerator
    {
        private CardBundleData _currentCards;
        private int _currentCapacity;
        private CardData _currentTask;
        
        public Grid GenerateGrid(CardBundleData cards, int row, int column, CardData task)
        {
            _currentCards = cards;
            _currentCapacity = row * column;
            _currentTask = task;
            
            return new Grid(row, column, GenerateItems(_currentCapacity));
        }

        private CardData[] GenerateItems(int count)
        {
            var items = new CardData[count];

            var taskPosition = GetPositionForTask();
            
            for (int i = 0; i < count; i++)
            {
                if (i == taskPosition)
                    items[i] = _currentTask;
                else
                    items[i] = FindCardInBundle();
            }

            return items;
        }

        private int GetPositionForTask()
        {
            return Random.Range(0, _currentCapacity-1);
        }

        private CardData FindCardInBundle()
        {
            if(_currentCards.CardData.Count <= 1) 
                throw new Exception("Not enough card in Bundle");
            
            CardData card = _currentCards.CardData.GetRandom();
            while (CardIsTask(card))
            {
                card = _currentCards.CardData.GetRandom();
            }
            
            return card;
        }

        private bool CardIsTask(CardData card)
        {
            return card == _currentTask;
        }
    }
}