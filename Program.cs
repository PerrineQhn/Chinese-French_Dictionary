namespace DictionnaireZhFR
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue dans le dictionnaire chinois-français !");

            // Définir les chemins pour les fichiers
            string xmlFilePath = "Data/cfdict.xml";
            string jsonFilePath = "Data/cfdict.json";

            // Vérifier si le fichier JSON existe
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
                Console.WriteLine("Commandes disponibles (utiliser tab pour ajouter les arguments) : GetSinogram, GetTraditional, GetFrench, GetPinyin, GetAllInformation, ReadSaveFile, help");

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