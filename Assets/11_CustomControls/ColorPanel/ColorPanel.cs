using UnityEngine.UIElements;
using UnityEngine;

namespace CustomControls
{
    public class ColorPanel : VisualElement
    {
        public new class UxmlFactory : UxmlFactory<ColorPanel> { }

        private const string styleResource = "Stylesheet_ColorPanel";

        private const string ussDefaultPanel = "default_panel";

        public ColorPanel()
        {
            styleSheets.Add(Resources.Load<StyleSheet>(styleResource));

            VisualElement panel = new VisualElement();

            panel.style.width = 200;
            panel.style.height = 200;
            panel.AddToClassList(ussDefaultPanel);

            hierarchy.Add(panel);

            

        }
    }
}


