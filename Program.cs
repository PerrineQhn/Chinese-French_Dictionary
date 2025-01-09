namespace DictionnaireZhFR
{
    class Program
    {
        static void Main(string[] args)
        {
            LocalizationService localizationService = new LocalizationService();
            Console.WriteLine(localizationService.GetText("WelcomeMessage"));

            // Définir les chemins pour les fichiers
            string xmlFilePath = "Data/cfdict.xml";
            string jsonFilePath = "Data/cfdict.json";

            // Vérifier si le fichier JSON existe
            if (!File.Exists(jsonFilePath))
            {
                // Instancier la classe Dictionnary_Creation
                Dictionnary_Creation generation_dictionnaire = new Dictionnary_Creation(localizationService);

                // Appeler la méthode pour générer le vocabulaire
                Console.WriteLine(localizationService.GetText("GeneratingJson"));
                generation_dictionnaire.CreateDictionnary_JSON(xmlFilePath, jsonFilePath);
            }
            else
            {
                Console.WriteLine(localizationService.GetText("JsonExists"));
            }

            // Boucle infinie pour entrer des commandes
            CommandInterpreter commandInterpreter = new CommandInterpreter(localizationService);

            while (true)
            {
                Console.WriteLine("\n" + localizationService.GetText("Entrez une commande (ou tapez 'Quitter' pour quitter) :"));
                Console.WriteLine(localizationService.GetText("GetSinogram") + ", " +
                                localizationService.GetText("GetTraditional") + ", " +
                                localizationService.GetText("GetFrench") + ", " +
                                localizationService.GetText("GetPinyin") + ", " +
                                localizationService.GetText("GetAllInformation") + ", " +
                                localizationService.GetText("ChangeLanguage") + ", " +
                                localizationService.GetText("ReadSaveFile") + ", " +
                                localizationService.GetText("Help"));

                // Lire la commande de l'utilisateur
                string command = Console.ReadLine();

                // Vérifier si une commande est entrée
                if (string.IsNullOrWhiteSpace(command))
                {
                    Console.WriteLine("Veuillez entrer une commande valide.");
                    continue;
                }

                // Passer la commande à l'interpréteur
                try
                {
                    commandInterpreter.Interpret(command);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur lors de l'exécution de la commande : {ex.Message}");
                }
            }
        }
    }
}