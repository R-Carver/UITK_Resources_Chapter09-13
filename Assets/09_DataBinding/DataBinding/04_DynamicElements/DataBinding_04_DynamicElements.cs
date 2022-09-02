using UnityEngine;
using UnityEngine.UIElements;

namespace DataBinding_04
{
    public class DataBinding_04_DynamicElements : MonoBehaviour
    {
        VisualElement cardContainer;
        VisualElement buttonAdd;

        TextField input_name;
        TextField input_desc;

        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            cardContainer = root.Q("cardContainer");
            buttonAdd = root.Q("button_add");

            input_name = root.Q<TextField>("Input_Name");
            input_desc = root.Q<TextField>("Input_Desc");

            buttonAdd.RegisterCallback<ClickEvent>(AddCard);
        }

        void AddCard(ClickEvent e)
        {
            if (input_name.value != "" && input_desc.value != "")
            {
                // read out the form data
                string name = input_name.value;
                string description = input_desc.value;

                // load and instantiate the template
                VisualTreeAsset cardTemplate = Resources.Load<VisualTreeAsset>("dataBinding/Template_Card");
                VisualElement cardElem = cardTemplate.Instantiate();
                cardContainer.Add(cardElem);

                // create a card and the respective data
                Card newCard = new Card(cardElem, new Character(name, description));
            }
        }

        
    }
}


