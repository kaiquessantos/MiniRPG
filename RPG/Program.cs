using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{

    internal class Program
    {

        static List<Personagem> rpg = new List<Personagem>();


        enum Menu
        {
            Sair, Criar, Remover, Listar, Jogar
        }


        static void Main(string[] args)
        {

            Carregar();

            bool inout = false;
            while (inout == false)
            {

                Console.WriteLine("Welcome to RPG!");
                Console.WriteLine("1-Criar Personagem\n2-Remover Personagem\n3-Listar Personagens\n4-Jogar\n0-Sair");
                int opcao = int.Parse(Console.ReadLine());
                Menu escolha = (Menu)opcao;

                switch (escolha)
                {
                    case Menu.Sair:
                        inout = true;
                        break;

                    case Menu.Criar:
                        Create();
                        break;

                    case Menu.Remover:
                        Remover();
                        break;

                    case Menu.Listar:
                        Listar();
                        break;

                    case Menu.Jogar:
                        Jogar();
                        break;
                }

                Console.Clear();

            }
            
        }



        static void Create()
        {

            Personagem personagem = new Personagem();

            Console.WriteLine("Digite o nome do seu personagem: ");
            personagem.nome = Console.ReadLine();
            Console.WriteLine("Digite a classe do seu personagem:\nLadino\nVanguarda\nMago ");
            personagem.classe = Console.ReadLine();
            Console.WriteLine("Digite a idade do seu personagem: ");
            personagem.idade = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite os poderes do seu personagem: ");
            string powers = Console.ReadLine();
            personagem.poderes.Add(powers);
            Console.WriteLine("Digite a sua arma: ");
            personagem.arma = Console.ReadLine();
            
            rpg.Add(personagem);
            Salvar();

            Console.WriteLine("Personagem criado com sucesso, tecle ENTER para prosseguir com o uso do programa.");
            Console.ReadLine();
        }

        static void Remover()
        {
            Listar();
            Console.WriteLine("Digite o ID do personagem que deseja remover: ");
            int idremov = int.Parse(Console.ReadLine());
            rpg.RemoveAt(idremov);
            Salvar();
            Console.WriteLine("Personagem removido! Tecle ENTER para prosseguir com o uso do programa.");
            Console.ReadLine();
        }


        static void Salvar()
        {
            FileStream stream = new FileStream("rpg.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();
            encoder.Serialize(stream, rpg);
            stream.Close();
        }

        static void Listar()
        {

            int id = 0;

            if (id >= 0 & id < rpg.Count)
            {

                foreach (Personagem personagem in rpg)
                {

                    Console.WriteLine($"ID: {id}");
                    Console.WriteLine($"Nome: {personagem.nome}");
                    Console.WriteLine($"Classe: {personagem.classe}");
                    Console.WriteLine($"Idade: {personagem.idade}");
                    personagem.Powers();
                    Console.WriteLine($"Arma(s): {personagem.arma}");
                    Console.WriteLine();
                    id++;
                    Salvar();
                    
                }

                Console.WriteLine("Este(s) é(são) seu(s) personagem(ens). Tecle ENTER para prosseguir o uso do programa.");
                Console.ReadLine();

            }

            else
            {
                Console.WriteLine("Você não possui personagens salvos. Tecle ENTER para voltar ao menu e criar o seu!");
                Console.ReadLine();
            }

            


        }

        static void Carregar()
        {

            FileStream stream = new FileStream("rpg.dat", FileMode.OpenOrCreate);
            try
            {
                BinaryFormatter encoder = new BinaryFormatter();
                rpg = (List<Personagem>)encoder.Deserialize(stream);

                if ( rpg == null )
                {
                    rpg = new List<Personagem>();
                }
            }
            catch (Exception)
            {
                rpg = new List<Personagem>();
            }
            

            stream.Close();

        }


        enum Play
        {
            Sair, Atacar, Powers
        }


        static void Jogar()
        {

            bool inout = false;
            while (inout == false)
            {

                Console.WriteLine("Vamos jogar um pouco!");
                Console.WriteLine("Primeiro escolha por ID com qual personagem irá jogar: ");
                Listar();
                Console.WriteLine("Digite aqui o ID: ");
                int character = int.Parse(Console.ReadLine());

                Personagem personagem = rpg[character];

                Console.WriteLine("Tecle:\n1-Atacar\n2-Usar poderes\n0-Sair");
                int teclou = int.Parse(Console.ReadLine());
                Play teclado = (Play)teclou;

                switch (teclado)
                {
                    case Play.Sair:
                        inout = true;
                        break;

                    case Play.Atacar:
                        personagem.Atacar();
                        break;

                    case Play.Powers:
                        personagem.PowersAtt();
                        break;
                }

                Console.Clear();

            }

        }



    }
}
