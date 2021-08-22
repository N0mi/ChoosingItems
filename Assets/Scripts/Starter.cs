using System;
using AmayaSoft.TestTask.Data;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace AmayaSoft.TestTask
{
    public class Starter : MonoBehaviour
    {
        [SerializeField] private BundlesKit bundlesKit;
        [SerializeField] private SettingsData settingsData;
        [Space]
        [SerializeField] private CellView cellPrefab;
        [SerializeField] private GridLayoutGroup cellContainer;
        [Space]
        [SerializeField] private TextMeshProUGUI textTask;
        [Space]
        [SerializeField] private GameObject restartPanel;
        
        private LevelLoader _levelLoader;
        private LevelStarter _levelStarter;
        private RestartHandler _restartHandler;

        private void Start()
        {
            _levelStarter = new LevelStarter(cellContainer, cellPrefab, textTask, settingsData);
            _levelLoader = new LevelLoader(settingsData, bundlesKit);
            _restartHandler = new RestartHandler(_levelLoader, restartPanel);
            SetupLevel();
        }

        private void SetupLevel()
        {
            try
            {
                var level = _levelLoader.GetNextLevel();
                _levelStarter.StartLevel(level);
                level.OnComplete.AddListener(SetupLevel);
            }
            catch (IndexOutOfRangeException e) { }
        }
    }
}
