using UnityEngine;
using UnityEngine.UIElements;

namespace Manipulator_Tests
{
    public class Resizer : MouseManipulator
    {
        private Vector2 startPos;
        bool active;

        public Resizer()
        {
            activators.Add(new ManipulatorActivationFilter { button = MouseButton.LeftMouse });
        }

        protected override void RegisterCallbacksOnTarget()
        {
            target.RegisterCallback<MouseDownEvent>(OnMouseDown);
            target.RegisterCallback<MouseMoveEvent>(OnMouseMove);
            target.RegisterCallback<MouseUpEvent>(OnMouseUp);
        }

        protected override void UnregisterCallbacksFromTarget()
        {
            target.UnregisterCallback<MouseDownEvent>(OnMouseDown);
            target.UnregisterCallback<MouseMoveEvent>(OnMouseMove);
            target.UnregisterCallback<MouseUpEvent>(OnMouseUp);
        }

        protected void OnMouseDown(MouseDownEvent e)
        {
            if (CanStartManipulation(e))
            {
                startPos = e.localMousePosition;

                active = true;
                target.CaptureMouse();
                e.StopPropagation();
            }
        }

        protected void OnMouseMove(MouseMoveEvent e)
        {
            if (!active || !target.HasMouseCapture())
                return;

            Vector2 diff = e.localMousePosition - startPos;

            target.parent.style.height = target.parent.layout.height - diff.x;
            target.parent.style.width = target.parent.layout.width - diff.x;

            e.StopPropagation();
        }

        protected void OnMouseUp(MouseUpEvent e)
        {
            if (!active || !target.HasMouseCapture() || !CanStopManipulation(e))
                return;

            active = false;
            target.ReleaseMouse();
            e.StopPropagation();
        }
    }

}

