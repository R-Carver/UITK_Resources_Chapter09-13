using UnityEngine;
using UnityEngine.UIElements;

namespace Manipulator_Tests
{
    public class Colorizer : MouseManipulator
    {   
        public Colorizer()
        {
            activators.Add(new ManipulatorActivationFilter { button = MouseButton.RightMouse, clickCount = 2 });
        }

        protected override void RegisterCallbacksOnTarget()
        {
            target.RegisterCallback<MouseDownEvent>(OnMouseDown);
        }

        protected override void UnregisterCallbacksFromTarget()
        {
            target.UnregisterCallback<MouseDownEvent>(OnMouseDown);
        }

        void OnMouseDown(MouseDownEvent evt)
        {   
            if(CanStartManipulation(evt))
            {
                target.style.backgroundColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                evt.StopPropagation();
            }
        }
    }
}


