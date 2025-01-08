namespace DictionnaireZhFR;
public class CommandInterpreter
{
    private SaveResearch saveResearch = new SaveResearch();

    public void Interpret(string input)
    {
        // Divise l'entrée en arguments en utilisant '\t' comme séparateur
        string[] arguments = input.Split('\t');

        if (arguments.Length > 0)
        {
            string command = arguments[0];

            if (arguments.Length > 1)
            {
                // Combine tous les arguments après la commande en une seule chaîne
                string word = arguments[1];
                string result = string.Empty;

                CommandBase commandInstance;

                switch (command)
                {
                    case "GetSinogram":
                        commandInstance = new GetSinogramCommand();
                        break;

                    case "GetTraditional":
                        commandInstance = new GetTraditionalCommand();
                        break;

                    case "GetFrench":
                        commandInstance = new GetFrenchCommand();
                        break;

                    case "GetPinyin":
                        commandInstance = new GetPinyinCommand();
                        break;

                    case "GetAllInformation":
                        commandInstance = new GetAllInformationCommand();
                        break;

                    case "ReadSaveFile":
                        commandInstance = new ReadFileCommand();
                        break;

                    default:
                        throw new CommandNotFoundException($"Command '{command}' not recognized.");
                }

                // Exécuter la commande via la méthode Execute
                result = commandInstance.Execute(word);

                // Demander à l'utilisateur s'il veut sauvegarder la recherche
                Console.WriteLine("Voulez-vous sauvegarder cette recherche ? (oui/non)");
                string userInput = Console.ReadLine();
                if (userInput != null)
                {
                    userInput = userInput.Trim().ToLower();
                }

                if (userInput == "oui" || userInput == "o" || userInput == "y" || userInput == "yes")
                {
                    // Sauvegarder la recherche et le résultat
                    saveResearch.Save(command, word, result);
                    Console.WriteLine("Recherche sauvegardée avec succès dans Output/searches.txt.");
                }
                else
                {
                    Console.WriteLine("Recherche non sauvegardée.");
                }
            }
            else if (command == "help")
            {
                DisplayHelp();
            }
            else if (command == "exit")
            {
                Console.WriteLine("Au revoir !");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Argument manquant. Veuillez entrer un mot après la commande.");
            }
        }

        else
        {
            Console.WriteLine("Aucune commande spécifiée.");
            Console.WriteLine("\nOptions disponibles : GetSinogram, GetTraditional, GetFrench, Pinyin, GetAllInformation");
            Console.WriteLine("Exemple : GetSinogram bonjour");
            Console.WriteLine("Exemple : GetFrench 你好");
        }

    }
    private void DisplayHelp()
    {
        Console.WriteLine("\nVoici les commandes disponibles (un \\t est utilisé pour séparer la commande des arguments):");
        Console.WriteLine(" - GetSinogram\t<mot-français> : Obtenir le sinogramme simplifié d'un mot français.");
        Console.WriteLine(" - GetTraditional\t<mot-chinois_simplifié> : Obtenir le sinogramme traditionnel d'un mot chinois.");
        Console.WriteLine(" - GetFrench\t<mot-chinois> : Obtenir la traduction française d'un mot chinois.");
        Console.WriteLine(" - GetPinyin\t<mot-chinois> : Obtenir la translittération pinyin d'un mot chinois.");
        Console.WriteLine(" - GetAllInformation\t<mot> : Obtenir toutes les informations sur un mot donné.");
        Console.WriteLine(" - ReadSaveFile\t<chemin_fichier> : Lire le contenu d'un fichier texte comprenant les sauvegardes réalisées.");
        Console.WriteLine(" - help : Afficher cette aide.");
        Console.WriteLine(" - exit : Quitter le programme.");
        Console.WriteLine("\nExemples :");
        Console.WriteLine(" - GetSinogram\tbonjour");
        Console.WriteLine(" - GetFrench\t你好");
    }

}