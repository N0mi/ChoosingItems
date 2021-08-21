using System.Linq;
using AmayaSoft.TestTask.Data;
using Utilites;

namespace AmayaSoft.TestTask
{
    public class GridGenerator
    {
        private CardBundleData _currentCards;
        private int _currentCapacity;
        
        public Grid GenerateGrid(CardBundleData cards, int row, int column)
        {
            _currentCards = cards;
            _currentCapacity = row * column;
            
            return new Grid(row, column, GenerateItems(_currentCapacity));
        }

        private CardData[] GenerateItems(int count)
        {
            var items = new CardData[count];
            for (int i = 0; i < count; i++)
            {
                items[i] = _currentCards.cardData.ToList().GetRandom();
            }

            return items;
        }
    }
}