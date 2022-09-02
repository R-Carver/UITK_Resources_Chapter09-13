using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

namespace DataBinding_03
{
    public class Card
    {
        Character myCharacter;
        VisualElement cardRoot;

        Label nameLabel;
        Label descLabel;
        VisualElement avatarImg;

        public Card(VisualElement cardRoot, Character character)
        {
            this.cardRoot = cardRoot;
            this.myCharacter = character;

            nameLabel = cardRoot.Q<Label>("name");
            descLabel = cardRoot.Q<Label>("description");
            avatarImg = cardRoot.Q("avatar");

            cardRoot
                .Query(className: "card")
                .Descendents<VisualElement>()
                .ForEach(elem => elem.pickingMode = PickingMode.Ignore);

            SetImage();
            UpdateUI();

            myCharacter.onChanged += UpdateUI;
            cardRoot.userData = myCharacter;
        }

        void SetImage()
        {
            Sprite avatarSprite = Resources.Load<Sprite>(myCharacter.avatarImgPath);
            avatarImg.style.backgroundImage = new StyleBackground(avatarSprite);
        }

        void UpdateUI()
        {
            nameLabel.text = myCharacter.Name;
            descLabel.text = myCharacter.Description;
        }
    }
}

