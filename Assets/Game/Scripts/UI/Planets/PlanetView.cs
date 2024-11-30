using System;
using Modules.UI;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Planets
{
    //Немного переделал структуру префаба, чтобы было удобней работать с состояниями
    public class PlanetView : MonoBehaviour
    {
        [Header("Locked state")]
        [SerializeField]
        private GameObject _lockedStateGo;

        [SerializeField]
        private TextMeshProUGUI _unlockPriceText;

        [Header("Unlocked state")]
        [SerializeField]
        private GameObject _unlockedStateGo;

        [SerializeField]
        private GameObject _coinGo;

        [SerializeField]
        private GameObject _incomeProgressStateGo;

        [SerializeField]
        private TextMeshProUGUI _progressBarText;

        [SerializeField]
        private Image _progressBar;

        [Header("General")]
        [SerializeField]
        private Image _icon;

        [SerializeField]
        private SmartButton _button;

        public Vector3 MoneyAnimationStartPoint => _coinGo.transform.position;

        public event Action Clicked;
        public event Action Held;

        private void OnEnable()
        {
            _button.OnClick += OnButtonClick;
            _button.OnHold += OnButtonHold;
        }

        private void OnDisable()
        {
            _button.OnClick -= OnButtonClick;
            _button.OnHold -= OnButtonHold;
        }

        [Button]
        public void SetUnlockedState(bool isUnlocked)
        {
            _lockedStateGo.SetActive(!isUnlocked);
            _unlockedStateGo.SetActive(isUnlocked);
        }

        [Button]
        public void SetIncomeReadyState(bool isIncomeReady)
        {
            _incomeProgressStateGo.SetActive(!isIncomeReady);
            _coinGo.SetActive(isIncomeReady);
        }

        [Button]
        public void SetIcon(Sprite icon)
        {
            _icon.sprite = icon;
        }

        [Button]
        public void SetProgress(float progress)
        {
            _progressBar.fillAmount = progress;
        }

        [Button]
        public void SetProgressBarText(string text)
        {
            _progressBarText.text = text;
        }

        [Button]
        public void SetUnlockPriceText(string text)
        {
            _unlockPriceText.text = text;
        }

        private void OnButtonHold()
        {
            Held?.Invoke();
        }

        private void OnButtonClick()
        {
            Clicked?.Invoke();
        }
    }
}
