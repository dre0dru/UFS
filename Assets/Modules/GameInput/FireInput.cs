using UnityEngine;

namespace Modules.GameInput
{
    public class FireInput : MonoBehaviour
    {
        //Для инпута обычно предпочитаю polling вместо эвентов
        public bool IsShootInputPressed { get; private set; }

        private void Update()
        {
            IsShootInputPressed = Input.GetKeyDown(KeyCode.Space);
        }
    }
}
