using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Popups
{
    //Я не "забыл" вынести в отдельный файл, просто всегда презентеры храню рядом со вьюшкой
    public interface IPlanetPopupPresenter : IDisposable
    {
        string HeaderText { get; }
        Sprite Icon { get; }
        string PopulationText { get; }
        string LevelText { get; }
        string IncomeText { get; }
        string UpgradePriceText { get; }
        bool CanUpgrade { get; }
        bool IsMaxLevel { get; }
        string UpgradeButtonText { get; }

        event Action InfoChanged;
        void Upgrade();
    }

    //Mvp Presenter Model
    public class PlanetPopup : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _headerText;

        [SerializeField]
        private Button _closeButton;

        [SerializeField]
        private Image _icon;

        [SerializeField]
        private TextMeshProUGUI _populationText;

        [SerializeField]
        private TextMeshProUGUI _levelText;

        [SerializeField]
        private TextMeshProUGUI _incomeText;

        [SerializeField]
        private Button _upgradeButton;

        [SerializeField]
        private TextMeshProUGUI _upgradeButtonText;

        [SerializeField]
        private TextMeshProUGUI _upgradePriceText;

        [SerializeField]
        private GameObject _priceContainerGo;

        private IPlanetPopupPresenter _presenter;

        private void Awake()
        {
            _closeButton.onClick.AddListener(OnCloseClick);
            _upgradeButton.onClick.AddListener(OnUpgradeClick);
        }

        public void Open(IPlanetPopupPresenter presenter)
        {
            _presenter = presenter;

            SetInfo();
            _presenter.InfoChanged += SetInfo;
            gameObject.SetActive(true);
        }

        private void SetInfo()
        {
            SetHeaderText();
            SetIcon();
            SetPopulationText();
            SetLevelText();
            SetIncomeText();
            SetUpgradePriceText();
            SetUpgradeButtonText();
            SetUpgradeButtonState();
            SetPriceContainerState();
        }

        private void SetHeaderText()
        {
            _headerText.text = _presenter.HeaderText;
        }

        private void SetIcon()
        {
            _icon.sprite = _presenter.Icon;
        }

        private void SetPopulationText()
        {
            _populationText.text = _presenter.PopulationText;
        }

        private void SetLevelText()
        {
            _levelText.text = _presenter.LevelText;
        }

        private void SetIncomeText()
        {
            _incomeText.text = _presenter.IncomeText;
        }

        private void SetUpgradePriceText()
        {
            _upgradePriceText.text = _presenter.UpgradePriceText;
        }

        private void SetUpgradeButtonText()
        {
            _upgradeButtonText.text = _presenter.UpgradeButtonText;
        }

        private void SetUpgradeButtonState()
        {
            _upgradeButton.interactable = _presenter.CanUpgrade;
        }

        private void SetPriceContainerState()
        {
            _priceContainerGo.SetActive(!_presenter.IsMaxLevel);
        }

        private void OnCloseClick()
        {
            if (_presenter != null)
            {
                _presenter.Dispose();
                _presenter.InfoChanged -= SetInfo;
                _presenter = null;
            }

            gameObject.SetActive(false);
        }

        private void OnUpgradeClick()
        {
            _presenter.Upgrade();
        }
    }
}
