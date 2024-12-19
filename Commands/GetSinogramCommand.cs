namespace DictionnaireZhFR
{
    public class GetSinogramCommand : CommandBase
    {
        private readonly PinyinUtils _pinyinUtils = new PinyinUtils();

        public override string Execute(string input)
        {
            List<Dictionary<string, string>> data = dictionnaire.ObtenirDonneesDictionnaire();

            // Normaliser l'entrée
            string normalizedInput = input.Trim().ToLower();
            string accentedInput = _pinyinUtils.ConvertNumericPinyinToAccented(normalizedInput);
            string withoutTones = _pinyinUtils.RemovePinyinTones(accentedInput);

            // Liste pour stocker les résultats
            List<WordInfo> results = new List<WordInfo>();

            // Recherche dans le dictionnaire
            foreach (Dictionary<string, string> entry in data)
            {   
                string entryPinyin = entry["Pinyin"];
                string entryPinyinNoTones = _pinyinUtils.RemovePinyinTones(_pinyinUtils.ConvertNumericPinyinToAccented(entryPinyin));
                
                // Vérifier si les traductions contiennent l'entrée normalisée
                if (entry["Translations"].Contains(normalizedInput, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(CreateWordInfo(entry));
                }
                // Correspondance exacte avec le pinyin (avec tons)
                else if (entryPinyin == normalizedInput)
                {
                    results.Add(CreateWordInfo(entry));
                }
                // Correspondance avec le pinyin sans les tons
                else if (entryPinyinNoTones == withoutTones)
                {
                    results.Add(CreateWordInfo(entry));
                }
            }

            if (results.Count == 0)
            {
                throw new Exception($"Aucun sinogramme trouvé pour '{input}'.");
            }

            // Générer un message contenant tous les résultats trouvés
            string output = string.Join("\n", results.Select(w => w.ToString()));
            Console.WriteLine($"Sinogrammes trouvés pour '{input}':\n{output}");
            return output;
        }

        private WordInfo CreateWordInfo(Dictionary<string, string> entry)
        {
            return new WordInfo(
                $" Simplifié: {entry["Trad"]}"
            );
        }

    }
}