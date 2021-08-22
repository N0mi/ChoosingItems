using System.Linq;
using AmayaSoft.TestTask.Data;
using AmayaSoft.TestTask.View;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AmayaSoft.TestTask
{
    public class LevelStarter
    {
        private readonly GridLayoutGroup _cellContainer;
        private readonly CellView _cell;
        private readonly TextMeshProUGUI _taskText;
        private readonly SettingsData _settings;
        private readonly Image _loadPanel;

        private GridView _gridView;
        private Level _currentLvl;
        private bool _isFirstShow;

        public LevelStarter(GridLayoutGroup cellContainer, CellView cell, TextMeshProUGUI taskText,
            SettingsData settings, Image loadPanel)
        {
            _cellContainer = cellContainer;
            _cell = cell;
            _taskText = taskText;
            _settings = settings;
            _loadPanel = loadPanel;
            _isFirstShow = true;
        }
        
        public void StartLevel(Level lvl)
        {
            _currentLvl = lvl;

            if (_isFirstShow)
            {
                _loadPanel.DOFade(0, 1f).OnComplete(() =>
                {
                    CreateGridView();
                    ShowTaskOnScreen();
                });
            }
            else
            {
                CreateGridView();
                ShowTaskOnScreen();
            }
        }

        private void CreateGridView()
        {
            _gridView?.DestroyGrid();
            _gridView = new GridView(_currentLvl, _cell, _cellContainer, _settings.BGColor.ToList());
            if (_isFirstShow)
            {
                _gridView.BounceActivateGrid();
            }
            _gridView.onCorrectCardClick.AddListener(_ => _currentLvl.EndLevel());
        }

        private void ShowTaskOnScreen()
        {
            _taskText.text = "Find " + _currentLvl.Task.Identifier;
            if (!_isFirstShow) return;
            
            _taskText.DOFade(1, 1f);
            _isFirstShow = false;
        }
    }
}