namespace DictionnaireZhFR
{
    public class GetSinogramCommand : CommandBase
    {
        private readonly PinyinUtils _pinyinUtils = new PinyinUtils();

        public GetSinogramCommand(LocalizationService localizationService) 
            : base(localizationService)
        {
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

                if (entry["Translations"].Contains(frenchWord, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(CreateWordInfo(entry));
                }
            }
    
            if (results.Count == 0)
            {
                throw new Exception(_localizationService.GetText("NoSinogramFound") + $"'{input}'.");
            }

            // Générer un message contenant tous les résultats trouvés
            string output = string.Join("\n", results.Select(w => w.ToString()));
            Console.WriteLine(_localizationService.GetText("SinogramsFound") + $"'{input}':\n{output}");
            return output;
        }

        private WordInfo CreateWordInfo(Dictionary<string, string> entry)
        {   
            return new WordInfo(
                $" {_localizationService.GetText("Simplified")}: {entry["Simpl"]} ({entry["Pinyin"]}), {entry["Translations"]}"
            );
        }

    }
}