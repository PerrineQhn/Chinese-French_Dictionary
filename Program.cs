using System.Data;
using System.IO;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenue dans le dictionnaire chinois-français !");
        
        CommandInterpreter commandInterpreter = new CommandInterpreter();
        commandInterpreter.Interpret(args);
    }
}
