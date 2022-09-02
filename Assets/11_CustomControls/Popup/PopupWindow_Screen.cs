using UnityEngine;
using UnityEngine.UIElements;

namespace CustomControls
{
    public class PopupWindow_Screen : MonoBehaviour
    {
        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            PopupWindow popup = new PopupWindow();
            popup.Prompt = "Do you really want to quit?";
            popup.confirmed += () => Debug.Log("Quitting the game");
            popup.cancelled += () => root.Remove(popup);

            root.Add(popup);
        }
    }
}


