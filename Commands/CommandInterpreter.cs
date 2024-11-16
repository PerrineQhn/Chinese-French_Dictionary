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

                switch (command)
                {
                    case "GetSinogram":
                        GetSinogramCommand sinogramCmd = new GetSinogramCommand();
                        result = sinogramCmd.GetSimplifier(word); // Capture le résultat
                        break;

                    case "GetTraditional":
                        GetTraditionalCommand traditionalCmd = new GetTraditionalCommand();
                        result = traditionalCmd.GetTraditional(word); // Capture le résultat
                        break;

                    case "GetFrench":
                        GetFrenchCommand frenchCmd = new GetFrenchCommand();
                        result = frenchCmd.Traduction(word); // Capture le résultat
                        break;

                    case "Pinyin":
                        GetPinyinCommand pinyinCmd = new GetPinyinCommand();
                        result = pinyinCmd.GetPinyin(word); // Capture le résultat
                        break;

                    case "GetAllInformation":
                        GetAllInformationCommand allInfoCmd = new GetAllInformationCommand();
                        result = allInfoCmd.GetAllInformation(word); // Capture le résultat
                        break;

                    default:
                        Console.WriteLine("Commande inconnue.");
                        return;
                }

                // Sauvegarder la recherche et le résultat
                saveResearch.Save(command, word, result);
            }
            else
            {
                Console.WriteLine("Argument manquant. Veuillez entrer un mot après la commande.");
            }
        }
        else
        {
            Console.WriteLine("Aucune commande spécifiée.");
        }

        Console.WriteLine("\nOptions disponibles : GetSinogram, GetTraditional, GetFrench, Pinyin, GetAllInformation");
        Console.WriteLine("Exemple : GetSinogram bonjour");
        Console.WriteLine("Exemple : GetFrench 你好");
    }
}