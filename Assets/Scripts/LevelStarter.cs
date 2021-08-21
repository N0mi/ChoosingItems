using AmayaSoft.TestTask.View;
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

        private GridView _gridView;
        private Level _currentLvl;

        public LevelStarter(GridLayoutGroup cellContainer, CellView cell, TextMeshProUGUI taskText)
        {
            _cellContainer = cellContainer;
            _cell = cell;
            _taskText = taskText;
        }
        
        public void StartLevel(Level lvl)
        {
            _currentLvl = lvl;
            CreateGridView();
            ShowTaskOnScreen();
        }

        private void CreateGridView()
        {
            _gridView?.DestroyGrid();
            _gridView = new GridView(_currentLvl.Grid, _cell, _cellContainer);
        }

        private void ShowTaskOnScreen()
        {
            _taskText.text = "Find " + _currentLvl.Task.Identifier;
        }
    }
}