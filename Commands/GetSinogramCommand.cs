namespace DictionnaireZhFR
{
    public class GetSinogramCommand : CommandBase
    {
        private readonly PinyinUtils _pinyinUtils = new PinyinUtils();
        private readonly LocalizationService _localizationService;

        public GetSinogramCommand(LocalizationService localizationService)
        {
            _localizationService = localizationService;
        }

        public override string Execute(string input)
        {
            List<Dictionary<string, string>> data = dictionnaire.ObtenirDonneesDictionnaire();

            // Normaliser l'entrée
            string frenchWord = input.Trim().ToLower();

            // Liste pour stocker les résultats
            List<WordInfo> results = new List<WordInfo>();

            // Recherche dans le dictionnaire
            foreach (Dictionary<string, string> entry in data)
            {   
                // Vérifier si les traductions contiennent l'entrée normalisée
                if (entry["Translations"].Contains(frenchWord, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(CreateWordInfo(entry));
                }
            }

            if (results.Count == 0)
            {
                throw new Exception(_localizationService.GetText("NoSinogramFound") + $"'{input}'.");
                // throw new Exception($"Aucun sinogramme trouvé pour '{input}'.");
            }

            // Générer un message contenant tous les résultats trouvés
            string output = string.Join("\n", results.Select(w => w.ToString()));
            Console.WriteLine(_localizationService.GetText("SinogramsFound") + $"'{input}':\n{output}");
            // Console.WriteLine($"Sinogrammes trouvés pour '{input}':\n{output}");
            return output;
        }

        private WordInfo CreateWordInfo(Dictionary<string, string> entry)
        {   

            return new WordInfo(
                $" {_localizationService.GetText("Simplified")}: {entry["Simpl"]} ({entry["Pinyin"]})"
            );
        }

    }
}