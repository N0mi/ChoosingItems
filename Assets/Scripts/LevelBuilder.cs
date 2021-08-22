using AmayaSoft.TestTask.Data;
using Utilites;

namespace AmayaSoft.TestTask
{
    public class LevelBuilder
    {
        private readonly GridGenerator _gridGenerator = new GridGenerator();
        private readonly TaskGenerator _taskGenerator = new TaskGenerator();
        
        public Level CreateLevel(CardBundleData cards, int row, int column)
        {
            var task = _taskGenerator.GetTask(cards);
            var grid = _gridGenerator.GenerateGrid(cards, row, column, task);
            
            return new Level(grid, task);
        }
    }
}