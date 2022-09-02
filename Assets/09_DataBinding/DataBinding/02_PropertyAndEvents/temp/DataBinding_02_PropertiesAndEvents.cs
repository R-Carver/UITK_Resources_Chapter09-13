using UnityEngine;
using UnityEngine.UIElements;

namespace DataBinding_02_temp
{
    public class DataBinding_02_PropertiesAndEvents : MonoBehaviour
    {
        Character testChar;

        VisualElement card;

        TextField input_name;
        TextField input_desc;

        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            card = root.Q("Card");
            input_name = root.Q<TextField>("Input_Name");
            input_desc = root.Q<TextField>("Input_Desc");

            testChar = new Character("Lara", "Likes Pingpong");

            Card testCard = new Card(card, testChar);

            input_name.RegisterCallback<ChangeEvent<string>>(OnNameChanged);
            input_desc.RegisterCallback<ChangeEvent<string>>(OnDescChanged);
            
            input_name.SetValueWithoutNotify(testChar.Name);
            input_desc.SetValueWithoutNotify(testChar.Description);
        }

        void OnNameChanged(ChangeEvent<string> evt)
        {
            testChar.Name = evt.newValue;
        }

        void OnDescChanged(ChangeEvent<string> evt)
        {
            testChar.Description = evt.newValue;
        }
    }
}


