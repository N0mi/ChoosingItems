using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AmayaSoft.TestTask.View
{
    public class GridView
    {
        private List<CellView> _cells = new List<CellView>();
        
        public GridView(Grid grid, CellView cell, GridLayoutGroup cellContainer)
        {
            cellContainer.constraintCount = grid.Column;
            
            foreach (var card in grid.Items)
            {
                var cellView = Object.Instantiate(cell, cellContainer.transform);
                _cells.Add(cellView);
                cellView.SetCard(card);
                cellView.SetBackGroundColor(Color.gray);
            }
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