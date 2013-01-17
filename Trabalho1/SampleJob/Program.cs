using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace SampleJob
{
    // exemplo de um programa que processa um ficheiro com números inteiros, produzindo
    // outro com os números inteiros ordenados por ordem crescente
    class Program
    { 
        // recebe em args dois nomes de ficheiros:
        // 1 arg - ficheiro com numeros inteiros (1 por linha)
        // 2 arg - ficheiro onde vai escrever os numeros inteiros ordenados
        static void Main(string[] args)
        {
            string str = "";
            
            foreach (string s in args) 
                str += s;
            
            Console.WriteLine("inicio do processo com args: " + str);

            string stintxt = Console.ReadLine();
            Console.WriteLine("lido do standard input:" + stintxt);
            
            ArrayList tab = new ArrayList();
            StreamReader fin = new StreamReader(args[0]);
            
            string line;
            while ((line = fin.ReadLine()) != null)
            {
                tab.Add(int.Parse(line));
            }
            
            tab.Sort();
            
            Thread.Sleep(8 * 1000); // simula tempo de execução longo
            
            StreamWriter fout = new StreamWriter(args[1]);
            
            foreach (object obj in tab)
                fout.WriteLine((int)obj);
            
            fin.Close(); fout.Close();
        }
    }
}
