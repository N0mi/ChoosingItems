using DG.Tweening;
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
        private readonly Image _loadPanel;
        private readonly Button _restartButton;
        private readonly Image _panelImage;

        private Tween _fadeTween;
        public RestartHandler(LevelLoader loader, GameObject restartPanel, Image loadPanel)
        {
            _loader = loader;
            _loader.EndLevels.AddListener(EnableRestartPanel);
            
            _restartPanel = restartPanel;
            _loadPanel = loadPanel;
            _restartButton = _restartPanel.GetComponentInChildren<Button>();
            _panelImage = _restartPanel.GetComponent<Image>();
            _restartButton.onClick.AddListener(Restart);
            _restartPanel.SetActive(false);
            _restartButton.gameObject.SetActive(false);
        }

        private void EnableRestartPanel()
        {
            _panelImage.color = new Color(0,0,0,0);
            _restartPanel.SetActive(true);
            _panelImage.DOFade(0.6f, 1f).OnComplete(() => _restartButton.gameObject.SetActive(true));
        }

        private void Restart()
        {
            if (_fadeTween.IsActive()) return;
            _fadeTween = _loadPanel.DOFade(1, 1f).OnComplete(() =>
                SceneManager.LoadScene(SceneManager.GetActiveScene().name));
        }
    }
}