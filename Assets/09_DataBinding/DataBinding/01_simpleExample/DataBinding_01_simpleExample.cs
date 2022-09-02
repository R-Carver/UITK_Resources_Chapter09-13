using UnityEngine.UIElements;
using UnityEngine;

namespace DataBinding_01
{
    public class DataBinding_01_simpleExample : MonoBehaviour
    {
        VisualElement card;

        TextField input_name;
        TextField input_desc;

        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            card = root.Q("Card");
            input_name = root.Q<TextField>("Input_Name");
            input_desc = root.Q<TextField>("Input_Desc");

            card.RegisterCallback<ClickEvent>(OnCardClicked);
            input_name.RegisterCallback<ChangeEvent<string>>(OnNameChanged);
            input_desc.RegisterCallback<ChangeEvent<string>>(OnDescChanged);

        }

        void OnCardClicked(ClickEvent evt)
        {
            string name = card.Q<Label>("name").text;
            string description = card.Q<Label>("description").text;

            input_name.SetValueWithoutNotify(name);
            input_desc.SetValueWithoutNotify(description);
        }

        void OnNameChanged(ChangeEvent<string> evt)
        {
            Label nameLabel = card.Q<Label>("name");
            nameLabel.text = evt.newValue;
        }

        void OnDescChanged(ChangeEvent<string> evt)
        {
            Label descLabel = card.Q<Label>("description");
            descLabel.text = evt.newValue;
        }
    }
}

