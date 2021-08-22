using System.Collections.Generic;
using AmayaSoft.TestTask.Data;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utilites;

namespace AmayaSoft.TestTask.View
{
    public class GridView
    {
        public readonly UnityEvent<CardData> onCardClick = new UnityEvent<CardData>();
        private readonly Grid _grid;
        private readonly CellView _cellPrefab;
        private readonly GridLayoutGroup _cellContainer;
        private readonly List<CellView> _cells = new List<CellView>();
        private readonly List<Color> _BGcolors;

        public GridView(Grid grid, CellView cell, GridLayoutGroup cellContainer, List<Color> bgColors)
        {
            _grid = grid;
            _cellPrefab = cell;
            _cellContainer = cellContainer;
            _BGcolors = bgColors;
            cellContainer.constraintCount = grid.Column;
            
            foreach (var card in grid.Items)
            {
                CreateCell(card);
            }
        }

        private void CreateCell(CardData card)
        {
            var cellView = Object.Instantiate(_cellPrefab, _cellContainer.transform);
            _cells.Add(cellView);
            cellView.SetCard(card);
            cellView.SetBackGroundColor(_BGcolors.GetRandom());
            cellView.onClick.AddListener(CardClickHandler);
        }

        private void CardClickHandler(CellView cell)
        {
            onCardClick.Invoke(cell.Card);
        }

        public void DestroyGrid()
        {
            foreach (var cell in _cells)
            {
                Object.Destroy(cell.gameObject);
            }
            _cells.Clear();
        }
    }
}