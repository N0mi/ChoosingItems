using System;
using System.Collections.Generic;
using UnityEngine;

namespace AmayaSoft.TestTask.Data
{
    [Serializable]
    public class LevelData
    {
        public int row;
        public int column;
        [Tooltip("If null then random")]
        public CardBundleData cardBundle;
    }
    
    [CreateAssetMenu(fileName = "new Settings", menuName = "Game Settings", order = 0)]
    public class SettingsData : ScriptableObject
    {
        [SerializeField] private Color[] _colorsBackGround;
        public IReadOnlyList<Color> BGColor => _colorsBackGround;

        [SerializeField] private LevelData[] _levelDatas;
        public IReadOnlyList<LevelData> Levels => _levelDatas;
    }
}