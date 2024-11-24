using System;
using UnityEngine;

namespace Game
{
    public class GameFinisher
    {
        public event Action<bool> GameFinished;

        public void FinishGame(bool isWin)
        {
            Debug.Log($"Game finished with result [{isWin}]");
            GameFinished?.Invoke(isWin);
        }
    }
}
