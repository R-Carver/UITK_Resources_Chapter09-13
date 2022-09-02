using UnityEngine;
using UnityEngine.UIElements;

namespace CustomControls
{
    public class ColorPanel_Screen : MonoBehaviour
    {
        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            root.Add(new ColorPanel());
        }
    }
}


