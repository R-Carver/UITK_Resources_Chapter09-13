using UnityEngine;
using System;

namespace DataBinding_02_temp
{
    public class Character
    {
        public event Action onChanged;

        private string name;
        public string Name
        {
            get => name;
            set
            {
                if (value != name)
                {
                    name = value;
                    onChanged.Invoke();
                }
            }
        }

        public string description;
        public string Description
        {
            get => description;
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

/*
 public class Character
    {
        public event Action onChanged;

        private string name;
        public string description;
        

        public Character(string name, string description)
        {
            this.name = name;
            this.description = description;
        }
    }

public string Description
        {
            get { return value;}
            set
            {
                if (value != description)
                {
                    description = value;
                    onChanged.Invoke();
                }
            }
        }
 */
