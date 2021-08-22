using System.Collections.Generic;
using System.Linq;
using AmayaSoft.TestTask.Data;
using UnityEngine;
using Utilites;

namespace AmayaSoft.TestTask
{
    public class TaskGenerator
    {
        private readonly List<CardData> _usedCard = new List<CardData>();
        private List<CardData> _currentBundle;

        public CardData GetTask(CardBundleData bundle)
        {
            _currentBundle = bundle.CardData.ToList();

            var taskCard = FindUniqueCard();

            _usedCard.Add(taskCard);
            return taskCard;
        }

        private CardData FindUniqueCard()
        {
            var taskCard = _currentBundle.GetRandomAndRemove();
            while (_usedCard.Contains(taskCard))
            {
                taskCard = _currentBundle.GetRandomAndRemove();
                if (_currentBundle.Count != 0 || !_usedCard.Contains(taskCard)) continue;
                
                Debug.LogError("The Bundle has run out of unique cards");
                break;
            }

            return taskCard;
        }
    }
}