using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace IAmABox.Input
{
    public class InputHandler : MonoBehaviour
    {
        private void Update()
        {
            var mouse = Mouse.current.leftButton;
            if (mouse.wasPressedThisFrame)
            {
                OnClicked();
            }
        }

        public void OnClicked()
        {
            
        }
    }
}
