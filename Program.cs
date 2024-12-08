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
                Console.WriteLine("Options disponibles : GetSinogram, GetTraditional, GetFrench, GetPinyin, GetAllInformation, help");

                // Lire la commande de l'utilisateur
                string command = Console.ReadLine();

                // Vérifier si l'utilisateur veut quitter
                if (command.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Au revoir !");
                    break;
                }

                // Vérifier si l'utilisateur demande de l'aide
                if (command.Equals("help", StringComparison.OrdinalIgnoreCase))
                {
                    AfficherAide();
                    continue;
                }

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

        // Méthode pour afficher l'aide
        static void AfficherAide()
        {
            Console.WriteLine("\nVoici les commandes disponibles et comment les utiliser :");
            Console.WriteLine(" - GetSinogram\t<mot-français> : Obtenir le sinogramme simplifié d'un mot français.");
            Console.WriteLine(" - GetTraditional\t<mot-chinois_simplifié> : Obtenir le sinogramme traditionnel d'un mot chinois.");
            Console.WriteLine(" - GetFrench\t<mot-chinois> : Obtenir la traduction française d'un mot chinois.");
            Console.WriteLine(" - GetPinyin\t<mot-chinois> : Obtenir la translittération pinyin d'un mot chinois.");
            Console.WriteLine(" - GetAllInformation\t<mot> : Obtenir toutes les informations (simplifié, traditionnel, pinyin, traduction) sur un mot donné.");
            Console.WriteLine(" - exit : Quitter le programme.");
            Console.WriteLine("\nExemples :");
            Console.WriteLine(" - GetSinogram\tbonjour");
            Console.WriteLine(" - GetFrench\t你好");
        }
    }
}