using UnityEngine;
using UnityEngine.UIElements;

namespace DataBinding_04
{
    public class Card
    {
        Character myCharacter;
        VisualElement cardRoot;

        Label nameLabel;
        Label descLabel;

        public Card(VisualElement cardRoot, Character character)
        {
            this.cardRoot = cardRoot;
            this.myCharacter = character;

            nameLabel = cardRoot.Q<Label>("name");
            descLabel = cardRoot.Q<Label>("description");

            cardRoot
                .Query(className: "card")
                .Descendents<VisualElement>()
                .ForEach(elem => elem.pickingMode = PickingMode.Ignore);

            UpdateUI();

            myCharacter.onChanged += UpdateUI;
            cardRoot.userData = myCharacter;
        }

        void UpdateUI()
        {
            nameLabel.text = myCharacter.Name;
            descLabel.text = myCharacter.Description;
        }
    }
}

