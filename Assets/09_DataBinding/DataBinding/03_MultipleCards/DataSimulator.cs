using UnityEngine;
using System.Collections.Generic;

namespace DataBinding_03
{
    public class DataSimulator
    {
        public static List<Character> getData()
        {
            List<Character> dummyData = new List<Character>();

            Character charLara = new Character(
                "Lara",
                "Makes amazing Aplle-Pie",
                "dataBinding/img_lara"
            );

            Character charRodolfo = new Character(
                "Rodolfo",
                "Paints clouds for a living",
                "dataBinding/img_rodolfo"
            );

            Character charMaya = new Character(
                "Maya",
                "Has a collection of 500 StarBucks cups",
                "dataBinding/img_maya"
            );

            dummyData.Add(charLara);
            dummyData.Add(charRodolfo);
            dummyData.Add(charMaya);

            return dummyData;
        }
    }
}


