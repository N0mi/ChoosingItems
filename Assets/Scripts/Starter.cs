using UnityEngine;

namespace AmayaSoft.TestTask
{
    public class Starter : MonoBehaviour
    {
        private readonly LevelLoader _levelLoader = new LevelLoader();
        private readonly LevelStarter _levelStarter = new LevelStarter();

        private void Start()
        {
            SetupLevel();
        }

        private void SetupLevel()
        {
            var level = _levelLoader.GetLevel();
            _levelStarter.StartLevel(level);
            level.OnComplete.AddListener(SetupLevel);
        }
    }
}
