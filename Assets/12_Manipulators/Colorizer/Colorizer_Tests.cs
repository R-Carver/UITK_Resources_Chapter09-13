using UnityEngine.UIElements;
using UnityEngine;

namespace Manipulator_Tests
{
    public class Colorizer_Tests : MonoBehaviour
    {
        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            VisualElement elem1 = root.Q("Elem1");
            VisualElement elem2 = root.Q("Elem2");
            VisualElement elem3 = root.Q("Elem3");

            elem1.AddManipulator(new Colorizer());
            elem2.AddManipulator(new Colorizer());
        }
    }

}

