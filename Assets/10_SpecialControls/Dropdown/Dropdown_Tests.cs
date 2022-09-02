using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

namespace Dropdown_Testing
{
    public class Dropdown_Tests : MonoBehaviour
    {
        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            DropdownField dropdown = root.Q<DropdownField>("MyDropdown");

            List<string> someStrings = new List<string> { "a", "b", "c" };

            dropdown.choices = someStrings;
            dropdown.value = someStrings[2];

            dropdown.formatSelectedValueCallback = (elem) => "Hello " + elem;
            dropdown.formatListItemCallback = (elem) => "I am " + elem;

            dropdown.RegisterCallback<ChangeEvent<string>>((elem) => Debug.Log(elem.newValue + " was selected"));

        }
    }
}
