using System;
using System.Collections.Generic;
using AmayaSoft.TestTask.Data;

namespace AmayaSoft.TestTask
{
    public class Grid
    {
        public IReadOnlyList<CardData> Items => _items;
        public readonly int Row;
        public readonly int Column;
        
        private readonly CardData[] _items;

        public Grid(int row, int column, CardData[] items)
        {
            if (row * column != items.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            
            Row = row;
            Column = column;
            _items = items;
        }
    }
}