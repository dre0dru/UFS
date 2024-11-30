using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Money
{
    public class MoneyView : MonoBehaviour
    {
        [SerializeField]
        private Image _icon;

        [SerializeField]
        private TextMeshProUGUI _countText;

        private Tween _tween;

        public void SetCountText(string count)
        {
            _countText.text = count;
        }
    }
}
