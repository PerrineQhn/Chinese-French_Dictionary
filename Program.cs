using System;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
       Console.WriteLine("Bienvenue dans le dictionnaire chinois-français !");
        
        // Définir les chemins pour les fichiers
        string xmlFilePath = "Data/cfdict.xml";
        string jsonFilePath = "Data/cfdict.json";

        // Vérifier si le fichier XML existe
        if (!File.Exists(jsonFilePath))
        {
            // Instancier la classe Dictionnary_Creation
            Dictionnary_Creation generation_dictionnaire = new Dictionnary_Creation();

            // Appeler la méthode pour générer le vocabulaire
            Console.WriteLine("Génération du fichier JSON...");
            generation_dictionnaire.CreateDictionnary_JSON(xmlFilePath, jsonFilePath);
        }
        else
        {
            Console.WriteLine("Le fichier JSON existe déjà.");
        }

        // Boucle infinie pour entrer des commandes
        CommandInterpreter commandInterpreter = new CommandInterpreter();
        while (true)
        {
            Console.WriteLine("\nEntrez une commande (ou tapez 'exit' pour quitter) :");
            Console.WriteLine("Options disponibles : GetSinogram, GetTraditional, GetFrench, GetPinyin, GetAllInformation");

            // Lire la commande de l'utilisateur
            string command = Console.ReadLine();

            // Vérifier si l'utilisateur veut quitter
            if (command.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Au revoir !");
                break;
            }

            // Découper la commande en arguments et interpréter
            string[] commandArgs = command.Split(' ');
            commandInterpreter.Interpret(commandArgs);
        }
    }
}