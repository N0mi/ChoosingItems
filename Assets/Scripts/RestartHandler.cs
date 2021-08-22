using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace AmayaSoft.TestTask
{
    public class RestartHandler
    {
        private readonly LevelLoader _loader;
        private readonly GameObject _restartPanel;

        public RestartHandler(LevelLoader loader, GameObject restartPanel)
        {
            _loader = loader;
            _loader.EndLevels.AddListener(EnableRestartPanel);
            
            _restartPanel = restartPanel;
            _restartPanel.GetComponentInChildren<Button>().onClick.AddListener(Restart);
            _restartPanel.SetActive(false);
        }

        private void EnableRestartPanel()
        {
            _restartPanel.SetActive(true);
        }

        private void Restart()
        {
            //Play fade in
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}