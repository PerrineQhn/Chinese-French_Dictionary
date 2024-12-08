namespace DictionnaireZhFR;
public class CommandInterpreter
{
    private SaveResearch saveResearch = new SaveResearch();

    public void Interpret(string[] arguments)
    {
        if (arguments.Length > 0)
        {
            string command = arguments[0];

            if (arguments.Length > 1)
            {
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

                    case "Pinyin":
                        commandInstance = new GetPinyinCommand();
                        break;

                    case "GetAllInformation":
                        commandInstance = new GetAllInformationCommand();
                        break;

                    default:
                        Console.WriteLine("Commande inconnue.");
                        return;
                }

                /// Exécuter la commande via la méthode Execute
                result = commandInstance.Execute(word);

                // Demander à l'utilisateur s'il veut sauvegarder la recherche
                Console.WriteLine("Voulez-vous sauvegarder cette recherche ? (oui/non)");
                string userInput = Console.ReadLine()?.Trim().ToLower();

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

}