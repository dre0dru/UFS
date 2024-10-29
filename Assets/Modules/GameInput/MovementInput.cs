using UnityEngine;

namespace Modules.GameInput
{
    public class MovementInput : MonoBehaviour
    {
        //Для инпута обычно предпочитаю polling вместо эвентов
        public float HorizontalInput { get; private set; }

        private void Update()
        {
            HorizontalInput = 0;

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                HorizontalInput = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                HorizontalInput = 1;
            }
        }
    }
}
