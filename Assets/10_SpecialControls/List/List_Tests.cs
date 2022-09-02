using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

namespace List_Testing
{
    public class List_Tests : MonoBehaviour
    {
        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            ListView list = root.Q<ListView>("MyList");
            VisualTreeAsset listItemAsset = Resources.Load<VisualTreeAsset>("Layout_ListItem");

            List<Person> poeple = new List<Person> {
                new Person("Harry", "Bosch"),
                new Person("Peter", "Parker"),
                new Person("Bruce", "Wayne"),
                new Person("Harry", "Bosch"),
                new Person("Peter", "Parker"),
                new Person("Bruce", "Wayne"),
                new Person("Harry", "Bosch"),
                new Person("Peter", "Parker"),
                new Person("Bruce", "Wayne"),
                new Person("Harry", "Bosch"),
                new Person("Peter", "Parker"),
                new Person("Bruce", "Wayne"),
                new Person("Harry", "Bosch"),
                new Person("Peter", "Parker"),
                new Person("Bruce", "Wayne"),
                new Person("Harry", "Bosch"),
                new Person("Peter", "Parker"),
                new Person("Bruce", "Wayne"),
                new Person("Harry", "Bosch"),
                new Person("Peter", "Parker"),
                new Person("Bruce", "Wayne"),
            };

            list.makeItem = () => listItemAsset.Instantiate();
            list.bindItem = (elem, index) =>
            {
                Label nameLabel = elem.Q<Label>("Name");
                Label surnameLabel = elem.Q<Label>("Surname");

                nameLabel.text = poeple[index].name;
                surnameLabel.text = poeple[index].surname;
            };

            list.itemsSource = poeple;
            list.fixedItemHeight = 50;
        }
    }

    public class Person
    {
        public string name;
        public string surname;

        public Person(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }
    }


}



