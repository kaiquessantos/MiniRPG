using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    [System.Serializable]
    internal class Personagem
    {
        public string nome;
        public string classe;
        public int idade;
        public List<string> poderes = new List<string>();
        public string arma;


        public void Atacar()
        {
            Console.WriteLine();
            Console.WriteLine($"{nome} de classe {classe} ataca usando{arma}!");
            Console.WriteLine();
            Console.WriteLine("Tecle ENTER para prosseguir o uso do programa.");
            Console.ReadLine();
        }

        public void Powers()
        {
            
            foreach (string poder in poderes)
            {
                Console.WriteLine("Poderes: " + poder);
            }
        }

        public void PowersAtt()
        {
            Console.WriteLine();
            Console.WriteLine($"{nome} usa");
            foreach (string poder in poderes)
            {
                Console.WriteLine(poder);
            }
            Console.WriteLine();
            Console.WriteLine("Tecle ENTER para prosseguir o uso do programa.");
            Console.ReadLine();
        }


    }
}
