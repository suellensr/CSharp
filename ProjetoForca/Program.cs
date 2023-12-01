using System;
using System.Globalization;
using Microsoft.VisualBasic;

namespace JodoDaForca
{
    class Program
    {
        static void Main()
        {
            string palavraSelecionada = SelecionarPalavra();
            char[] letrasDigitadas = new char[palavraSelecionada.Length+7];
            char[] letrasCorretas = new char[palavraSelecionada.Length];
            int j=0, erro = 0, acerto = 0; 
            
            bool jogoAcabou = false;

            try
            {
                InicializarPalavra(letrasCorretas, '_'); 
                while(jogoAcabou != true)
                {
                    Console.WriteLine("Digite uma letra:");
                    char letra = char.Parse(Console.ReadLine().ToLower());
              
                    letrasDigitadas[j] = letra;
                    j++;                 

                    bool ocorrencia = palavraSelecionada.Contains(letra);
                    if(ocorrencia == false)
                    {
                        erro++;
                    }
                    else
                    {
                        for(int i=0;i<palavraSelecionada.Length;i++)
                        {
                            if (letra == letrasCorretas[i])
                            {
                                Console.WriteLine("Você já tentou essa letra. Tente outra.");
                                continue;
                            }
                            else
                            {
                                if(letra == palavraSelecionada[i])
                                {
                                    letrasCorretas[i] = letra;
                                    acerto++;
                                }    
                            }
                        }
                    }

                    ExibeCorretas(letrasCorretas);
                    ExibeTentativas(letrasDigitadas);
                    ExibeForca(erro);
                    jogoAcabou = ConfereFinal(erro, acerto, palavraSelecionada);
                }
            }
            
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Ops! Algo deu errado.");                
            } 
            
        }        
                    
        static string SelecionarPalavra()
        {
            string[] palavras = { "cachorro", "gato", "elefante","vaca", "porco", "burro", "galinha", "formiga", "foca", 
            "baleia", "urso", "cavalo", "jabuti", "paca", "cupim", "lontra", "gorila", "macaco", "cobra", "camelo"  }; //lista de palavras possíveis
            Random randNum = new Random();
            int indice = randNum.Next(palavras.Length);
            return palavras[indice];
        }

        
        static void InicializarPalavra(char[] array, char valor)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = valor;
            }
        }

        static void ExibeCorretas(char[] letrasCorretas)
        {
            Console.WriteLine("Palavra:");
            foreach (char c in letrasCorretas)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();
        }

        static void ExibeTentativas(char[] letrasDigitadas)
        {
            Console.WriteLine("Suas tentativas:");
            foreach (char c in letrasDigitadas)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();
        }

        static void ExibeForca(int erro)
        {
            switch(erro.ToString())
            {
                case "0":
                    Console.WriteLine("Nenhum erro.");
                    Console.WriteLine("");
                    break;

                case "1":
                    Console.WriteLine("");
                    Console.WriteLine(" o ");
                    Console.WriteLine("");
                    break;

                case "2":
                    Console.WriteLine("");
                    Console.WriteLine(" o ");
                    Console.WriteLine(" | ");
                    Console.WriteLine("");
                    break;
                    
                case "3":
                    Console.WriteLine("");
                    Console.WriteLine(" o ");
                    Console.WriteLine("/| ");
                    Console.WriteLine("");
                    break;

                case "4":
                    Console.WriteLine("");
                    Console.WriteLine(" o ");
                    Console.WriteLine("/|\\");
                    Console.WriteLine("");
                    break;

                case "5":
                    Console.WriteLine("");
                    Console.WriteLine(" o ");
                    Console.WriteLine("/|\\");
                    Console.WriteLine("/");
                    Console.WriteLine("");
                    break;

                case "6":
                    Console.WriteLine("");
                    Console.WriteLine(" o ");
                    Console.WriteLine("/|\\");
                    Console.WriteLine("/ \\");
                    Console.WriteLine("");
                    break;

                default:
                    Console.WriteLine("Algo deu errado!");
                    break;
            }
        }

        static bool ConfereFinal(int erro, int acerto, string palavraSelecionada)
        {
            if(erro < 6 && acerto<palavraSelecionada.Length)
            {
                return false;
            }
            else
            {
                string resposta = (erro >= 6) ? "Você perdeu." : "Você acertou a palavra!!!";
                Console.WriteLine(resposta);
                return true;
            }
                
        }
    }
}    