using AmayaSoft.TestTask.Data;
using UnityEngine.Events;

namespace AmayaSoft.TestTask
{
    public class Level
    {
        public readonly UnityEvent OnComplete = new UnityEvent();

        private readonly Grid _grid;
        private readonly CardData _cardTask;

        public Grid Grid => _grid;
        public CardData Task => _cardTask;

        public Level(Grid grid, CardData task)
        {
            _grid = grid;
            _cardTask = task;
        }

        public void CheckCard(CardData card)
        {
            if(card == _cardTask)
                EndLevel();
        }

        private void EndLevel()
        {
            OnComplete.Invoke();
        }
    }
}