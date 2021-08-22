using System;
using System.Linq;
using AmayaSoft.TestTask.Data;
using UnityEngine;
using UnityEngine.Events;
using Utilites;

namespace AmayaSoft.TestTask
{
    public class LevelLoader
    {
        public UnityEvent EndLevels = new UnityEvent();
        
        private readonly SettingsData _settings;
        private readonly BundlesKit _kit;
        private readonly LevelBuilder _levelBuilder = new LevelBuilder();

        private int _levelCounter = 0;
        private int row = 3;
        private int column = 3;
        private CardBundleData loadedCards;
        public LevelLoader(SettingsData settings, BundlesKit kit)
        {
            _settings = settings;
            _kit = kit;
        }
        
        public Level GetNextLevel()
        {
            LoadData();
            _levelCounter++;
            
            return _levelBuilder.CreateLevel(loadedCards, row, column);
        }

        private void LoadData()
        {
            if (_levelCounter >= _settings.Levels.Count)
            {
                EndLevels.Invoke();
                throw new IndexOutOfRangeException();
            }

            var lvlData = _settings.Levels[_levelCounter];
            row = lvlData.row;
            column = lvlData.column;

            loadedCards = lvlData.cardBundle == null ? _kit.Bundles.GetRandom() : lvlData.cardBundle;
        }
    }
}