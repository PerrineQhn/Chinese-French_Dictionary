namespace DictionnaireZhFR;
public class CommandInterpreter
{
    private SaveResearch saveResearch = new SaveResearch(new LocalizationService());

    private readonly LocalizationService _localizationService;

    public CommandInterpreter(LocalizationService localizationService)
    {
        _localizationService = localizationService;
    }

    public void Interpret(string input)
    {
        // Divise l'entrée en arguments en utilisant '\t' comme séparateur
        string[] arguments = input.Split('\t');

        if (arguments.Length > 0)
        {
            string command = arguments[0];
            string translatedCommand = _localizationService.GetText(command);
            string originalCommand = _localizationService.GetOriginalCommand(translatedCommand);

            if (arguments.Length > 1)
            {
                // Combine tous les arguments après la commande en une seule chaîne
                string word = arguments[1];
                string result = string.Empty;

                CommandBase commandInstance;
                // Console.WriteLine($"Commande Traduite : {translatedCommand}, Commande originale : {originalCommand}, command : {command}");


                switch (originalCommand)
                {
                    
                    case "GetSinogram":
                    // case _localizationService.GetText("GetSinogram"):
                        commandInstance = new GetSinogramCommand(_localizationService);
                        break;

                    case "GetTraditional":
                        commandInstance = new GetTraditionalCommand(_localizationService);
                        break;

                    case "GetFrench":
                        commandInstance = new GetFrenchCommand(_localizationService);
                        break;

                    case "GetPinyin":
                        commandInstance = new GetPinyinCommand(_localizationService);
                        break;

                    case "GetAllInformation":
                        commandInstance = new GetAllInformationCommand(_localizationService);
                        break;

                    case "ReadSaveFile":
                        commandInstance = new ReadFileCommand(_localizationService);
                        break;

                    case "ChangeLanguage":
                        commandInstance = new ChangeLanguageCommand(_localizationService);
                        break; 

                    default:
                        throw new CommandNotFoundException(_localizationService.GetText("Commande non reconnue.")+ $" '{originalCommand}'"+_localizationService.GetText("non reconnue"));
                }

                // Exécuter la commande via la méthode Execute
                result = commandInstance.Execute(word);

                // Ne demander de sauvegarder que pour les commandes de recherche
                if (IsSearchCommand(originalCommand))
                {
                    // Console.WriteLine("Voulez-vous sauvegarder cette recherche ? (oui/non)");
                    Console.WriteLine(_localizationService.GetText("Voulez-vous sauvegarder cette recherche ? (oui/non)"));
                    string userInput = Console.ReadLine();
                    if (userInput != null)
                    {
                        userInput = userInput.Trim().ToLower();
                    }

                    if (userInput == "oui" || userInput == "o" || userInput == "y" || userInput == "yes" || userInput == "是")
                    {
                        saveResearch.Save(translatedCommand, word, result);
                        Console.WriteLine(_localizationService.GetText("Recherche sauvegardée avec succès dans Output/searches.txt."));
                    }
                    else
                    {
                        Console.WriteLine(_localizationService.GetText("Recherche non sauvegardée."));
                    }
                }
            }
            else if (originalCommand == "Help")
            {
                DisplayHelp();
            }
            else if (originalCommand == "Exit")
            {
                Console.WriteLine(_localizationService.GetText("Au revoir !"));
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine(_localizationService.GetText("Argument manquant. Veuillez entrer un mot après la commande."));
            }
        }

        else
        {
            Console.WriteLine(_localizationService.GetText("Aucune commande spécifiée."));
            Console.WriteLine("\n"+_localizationService.GetText("Options disponibles : GetSinogram, GetTraditional, GetFrench, Pinyin, GetAllInformation"));
            Console.WriteLine(_localizationService.GetText("Exemple : GetSinogram\tbonjour"));
            Console.WriteLine(_localizationService.GetText("Exemple : GetFrench\t你好"));
        }

    }
    private void DisplayHelp()
    {
        Console.WriteLine("\n"+ _localizationService.GetText("Voici les commandes disponibles (un \\t est utilisé pour séparer la commande des arguments):"));
        Console.WriteLine(_localizationService.GetText("GetSinogramHelp"));
        Console.WriteLine(_localizationService.GetText("GetTraditionalHelp"));
        Console.WriteLine(_localizationService.GetText("GetFrenchHelp"));
        Console.WriteLine(_localizationService.GetText("GetPinyinHelp"));
        Console.WriteLine(_localizationService.GetText("GetAllInformationHelp"));
        Console.WriteLine(_localizationService.GetText("ReadSaveFileHelp"));
        Console.WriteLine(_localizationService.GetText("ChangeLanguageHelp"));
        Console.WriteLine(_localizationService.GetText("HelpHelp"));
        Console.WriteLine(_localizationService.GetText("ExitHelp"));
        Console.WriteLine(_localizationService.GetText("\nExemples :"));
        Console.WriteLine(_localizationService.GetText(" - GetSinogram\tbonjour"));
        Console.WriteLine(_localizationService.GetText(" - GetFrench\t你好"));
    }

    private bool IsSearchCommand(string command)
    {
        return command == "GetSinogram" || command == "GetTraditional" || command == "GetFrench" || command == "GetPinyin" || command == "GetAllInformation";
    }

}