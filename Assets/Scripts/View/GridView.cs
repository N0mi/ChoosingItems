using System.Collections.Generic;
using System.Linq;
using AmayaSoft.TestTask.Data;
using Coffee.UIExtensions;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utilites;

namespace AmayaSoft.TestTask.View
{
    public class GridView
    {
        public readonly UnityEvent<CardData> onCorrectCardClick = new UnityEvent<CardData>();
        private readonly Level _level;
        private readonly Grid _grid;
        private readonly CellView _cellPrefab;
        private readonly GridLayoutGroup _cellContainer;
        private readonly UIParticle _particle;
        private readonly List<CellView> _cells = new List<CellView>();
        private readonly List<Color> _BGcolors;
        private Tweener _punch;

        public GridView(Level level, CellView cell, GridLayoutGroup cellContainer, List<Color> bgColors,
            UIParticle particle)
        {
            _level = level;
            _grid = _level.Grid;
            _cellPrefab = cell;
            _cellContainer = cellContainer;
            _particle = particle;
            _BGcolors = bgColors.ToList();
            cellContainer.constraintCount = _grid.Column;
            
            foreach (var card in _grid.Items)
            {
                CreateCell(card);
            }
        }

        private void CreateCell(CardData card)
        {
            var cellView = Object.Instantiate(_cellPrefab, _cellContainer.transform);
            _cells.Add(cellView);
            cellView.SetCard(card);
            cellView.SetBackGroundColor(_BGcolors.GetRandomAndRemove());
            cellView.onClick.AddListener(CellClick);
        }

        private void CellClick(CellView cell)
        {
            if (_level.CheckCorrectCard(cell.Card))
            {
                cell.endAnim.AddListener(()=>onCorrectCardClick.Invoke(cell.Card));
                _particle.rectTransform.position = cell.BackGround.rectTransform.position;
                _particle.Play();
                cell.CorrectAnim();
            }
            else
            {
                cell.UncorrectAnim();;
            }
        }

        public void BounceActivateGrid()
        {
            foreach (var cell in _cells)
            {
                cell.transform.localScale = Vector3.zero;
                cell.transform.DOScale(1, 0.5f).SetEase(Ease.OutBounce);
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