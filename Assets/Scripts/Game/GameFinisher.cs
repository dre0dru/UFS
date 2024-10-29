using UnityEngine;

namespace Game
{
    public sealed class GameFinisher : MonoBehaviour
    {
        public void FinishGame()
        {
            Debug.Log("Game over!");
            Time.timeScale = 0;
        }
    }
}
