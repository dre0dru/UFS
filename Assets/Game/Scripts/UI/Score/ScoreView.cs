using TMPro;
using UnityEngine;

namespace Game.Scripts.UI.Score
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _scoreText;

        public void SetScore(string scoreText)
        {
            _scoreText.text = scoreText;
        }

    }
}
