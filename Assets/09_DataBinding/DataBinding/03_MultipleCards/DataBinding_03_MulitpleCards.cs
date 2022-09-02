using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

namespace DataBinding_03
{
    public class DataBinding_03_MulitpleCards : MonoBehaviour
    {
        List<Character> characters;
        Character currentCharacter;

        VisualElement card1;
        VisualElement card2;
        VisualElement card3;

        TextField input_name;
        TextField input_desc;

        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            card1 = root.Q("Card1");
            card2 = root.Q("Card2");
            card3 = root.Q("Card3");
            input_name = root.Q<TextField>("Input_Name");
            input_desc = root.Q<TextField>("Input_Desc");

            characters = DataSimulator.getData();

            VisualElement cardContainer = root.Q("cardContainer");
            cardContainer.RegisterCallback<ClickEvent>(OnCardSelected);


            input_name.RegisterCallback<ChangeEvent<string>>(OnNameChanged);
            input_desc.RegisterCallback<ChangeEvent<string>>(OnDescChanged);


            InitializeUI();
        }

        void OnCardSelected(ClickEvent e)
        {
            VisualElement cardElem = e.target as VisualElement;
            currentCharacter = cardElem.userData as Character;
            UpdateInputFields();
        }

        void UpdateInputFields()
        {
            input_name.SetValueWithoutNotify(currentCharacter.Name);
            input_desc.SetValueWithoutNotify(currentCharacter.Description);
        }

        void InitializeUI()
        {
            Card cardView1 = new Card(card1, characters[0]);
            Card cardView2 = new Card(card2, characters[1]);
            Card cardView3 = new Card(card3, characters[2]);
        }

        void OnNameChanged(ChangeEvent<string> evt)
        {
            currentCharacter.Name = evt.newValue;
        }

        void OnDescChanged(ChangeEvent<string> evt)
        {
            currentCharacter.Description = evt.newValue;
        }
    }
}


