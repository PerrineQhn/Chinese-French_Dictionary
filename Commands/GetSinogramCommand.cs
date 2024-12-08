namespace DictionnaireZhFR
{
    public class GetSinogramCommand : CommandBase
    {
        public override string Execute(string frenchWord)
        {
            var data = dictionnaire.ObtenirDonneesDictionnaire();

            List<WordInfo> results = new List<WordInfo>();

            foreach (var entry in data)
            {
                if (entry["Translations"].Contains(frenchWord))
                {
                    // Créer une instance de WordInfo pour chaque résultat correspondant
                    var wordInfo = new WordInfo(
                        entry["Simpl"], 
                        entry["Trad"], 
                        entry["Pinyin"], 
                        entry["Translations"]
                    );
                    results.Add(wordInfo);
                }
            }

            if (results.Count == 0)
            {
                string message = $"Aucun sinogramme trouvé pour '{frenchWord}'.";
                Console.WriteLine(message);
                return message;
            }

            // Générer un message contenant tous les résultats trouvés
            string output = string.Join("\n", results.Select(w => w.ToString()));
            Console.WriteLine($"Sinogrammes trouvés pour '{frenchWord}':\n{output}");
            return output;
        }
    }
}