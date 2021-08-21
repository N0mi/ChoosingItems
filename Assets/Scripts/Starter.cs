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
        [Space]
        [SerializeField] private CellView cellPrefab;
        [SerializeField] private GridLayoutGroup cellContainer;
        [Space]
        [SerializeField] private TextMeshProUGUI textTask;
        
        private readonly LevelLoader _levelLoader = new LevelLoader();
        private LevelStarter _levelStarter;

        private void Start()
        {
            _levelStarter = new LevelStarter(cellContainer, cellPrefab, textTask);
            SetupLevel();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SetupLevel();
            }
        }

        private void SetupLevel()
        {
            var level = _levelLoader.GetLevel(bundlesKit.Bundles[1]);
            _levelStarter.StartLevel(level);
            //level.OnComplete.AddListener(SetupLevel);
        }
    }
}
