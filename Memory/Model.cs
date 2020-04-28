using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    class Model
    {
        Random random = new Random();
        int how_many=16;
        public int suma;
        int correct;
        List<string> icons = new List<string>()
        {
            "h", "h", "f", "f", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "p", "p"
        };
        public Model()
        {
            suma = 0;
            how_many = 16;
            correct = 2;
        }


        public bool decision(string firstClick, string SecondClick)
        {
            suma++;
            if (firstClick.Equals(SecondClick))
            {
                correct += 2;
                return true;
                
            }
            else
            {
                return false;
            }
           
        }
        public string[] randomize()
        {
           /* string[] table = new string[how_many];
            for(int i=0; i<16;i++)
            {
                
                int randomNumber = random.Next(icons.Count);
                table[i] = icons[randomNumber];
                icons.RemoveAt(randomNumber);
            }*/
            return icons.ToArray();
        }

        public bool checkwinner()
        {
            if (correct == how_many)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
