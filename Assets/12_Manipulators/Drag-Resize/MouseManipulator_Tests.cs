using UnityEngine;
using UnityEngine.UIElements;

namespace Manipulator_Tests
{
    public class MouseManipulator_Tests : MonoBehaviour
    {
        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            VisualElement dragElem = root.Q("Elem2");
            dragElem.AddManipulator(new Dragger());

            VisualElement resizeElem = root.Q("Resizer");
            resizeElem.AddManipulator(new Resizer());
        }
    }
}


