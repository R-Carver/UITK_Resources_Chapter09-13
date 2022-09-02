using UnityEngine;
using System;

namespace DataBinding_02
{
    public class Character
    {
        public event Action onChanged;

        private string name;
        public string Name
        {
            get { return name; }
            set 
            {
                if (value != name)
                {
                    name = value;
                    onChanged?.Invoke();
                }
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                if (value != description)
                {
                    description = value;
                    onChanged.Invoke();
                }
            }
        }

        public Character(string name, string description)
        {
            this.name = name;
            this.description = description;
        }
    }
}


