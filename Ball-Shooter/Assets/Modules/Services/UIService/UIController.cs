using System;
using Modules.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.Services.UIService
{
    public class UIController : MonoBehaviour, IUIController
    {
        public event Action OnPlay = delegate { };
        public event Action OnNextLevel = delegate { };
        public event Action OnRestart = delegate { };

        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject mainMenuPanel;
        [SerializeField] private GameObject losePanel;
        [SerializeField] private TextMeshProUGUI textLevel;

        [SerializeField] private Button playButton;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button nextLevelButton;

        private void Awake()
        {
            playButton.onClick.AddListener(() => OnPlay?.Invoke());
            restartButton.onClick.AddListener(() => OnRestart?.Invoke());
            nextLevelButton.onClick.AddListener(() => OnNextLevel?.Invoke());
        }

        public void Initialize(int level)
        {
            textLevel.text = level.ToString();
        }

        public void Play()
        {
            mainMenuPanel.SetActive(false);
        }

        public void ActivateLosePanel()
        {
            winPanel.SetActive(false);
            losePanel.SetActive(true);
            mainMenuPanel.SetActive(false);
        }

        public void ActivateWinPanel()
        {
            winPanel.SetActive(true);
            losePanel.SetActive(false);
            mainMenuPanel.SetActive(false);
        }
    }
}