using UnityEngine;
using UnityEngine.UIElements;

namespace DataBinding_02_temp
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

            UpdateUI();

            myCharacter.onChanged += UpdateUI;
        }

        void UpdateUI()
        {
            nameLabel.text = myCharacter.Name;
            descLabel.text = myCharacter.Description;
        }
    }
}


/*
 public class Card
    {
        Character myCharacter;

        VisualElement cardRoot;

        

        public Card(VisualElement cardRoot, Character character)
        {
            this.cardRoot = cardRoot;
            this.myCharacter = character;


            myCharacter.onChanged += UpdateUI;
        }

        void UpdateUI()
        {
            
        }
    }
 
 */

