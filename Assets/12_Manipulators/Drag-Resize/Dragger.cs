using UnityEngine;
using UnityEngine.UIElements;

namespace Manipulator_Tests
{
    public class Dragger : MouseManipulator
    {
        private Vector2 startPos;
        bool isActive;

        public Dragger()
        {
            activators.Add(new ManipulatorActivationFilter { button = MouseButton.LeftMouse });
            isActive = false;
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

                isActive = true;
                target.CaptureMouse();
                e.StopPropagation();
            }
        }

        protected void OnMouseMove(MouseMoveEvent e)
        {
            if (!isActive || !target.HasMouseCapture())
                return;

            Vector2 diff = e.localMousePosition - startPos;

            target.style.top = target.layout.y + diff.y;
            target.style.left = target.layout.x + diff.x;

            e.StopPropagation();
        }

        protected void OnMouseUp(MouseUpEvent e)
        {
            if (!isActive || !target.HasMouseCapture() || !CanStartManipulation(e))
                return;

            isActive = false;
            target.ReleaseMouse();
            e.StopPropagation();
        }
    }

    
}


