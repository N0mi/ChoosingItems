using System;
using AmayaSoft.TestTask.Data;
using Coffee.UIExtensions;
using DG.Tweening;
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
        [SerializeField] private Image loadPanel;
        [SerializeField] private UIParticle _particle;
        
        private LevelLoader _levelLoader;
        private LevelStarter _levelStarter;
        private RestartHandler _restartHandler;

        private void Start()
        {
            _levelStarter = new LevelStarter(cellContainer, cellPrefab, textTask, settingsData, loadPanel, _particle);
            _levelLoader = new LevelLoader(settingsData, bundlesKit);
            _restartHandler = new RestartHandler(_levelLoader, restartPanel, loadPanel);
            SetupLevel();
        }

        private void SetupLevel()
        {
            try
            {
                var level = _levelLoader.GetNextLevel();
                level.OnComplete.AddListener(SetupLevel);
                _levelStarter.StartLevel(level);
            }
            catch (IndexOutOfRangeException e) { }
        }
    }
}
