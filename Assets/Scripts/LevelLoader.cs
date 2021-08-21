using System.Linq;
using AmayaSoft.TestTask.Data;
using UnityEngine;
using UnityEngine.Events;
using Utilites;

namespace AmayaSoft.TestTask
{
    public class LevelLoader
    {
        private GridGenerator _gridGenerator = new GridGenerator();
        private LevelBuilder _levelBuilder = new LevelBuilder();
        
        public Level GetLevel(CardBundleData cards)
        {
            var grid = _gridGenerator.GenerateGrid(cards, 3,3);
            return _levelBuilder.CreateLevel(grid);
        }
    }
}