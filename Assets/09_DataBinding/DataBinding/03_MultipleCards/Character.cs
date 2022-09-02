using UnityEngine;
using System;

namespace DataBinding_03
{
    public class Character
    {
        public event Action onChanged;
        public string avatarImgPath;

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

        public Character(string name, string description, string img)
        {
            this.name = name;
            this.description = description;
            this.avatarImgPath = img;
        }
    }
}

