namespace DictionnaireZhFR
{
    public class GetSinogramCommand : CommandBase
    {
        public override string Execute(string input)
        {
            var data = dictionnaire.ObtenirDonneesDictionnaire();

            // Normaliser l'entrée
            string normalizedInput = input.Trim().ToLower();
            string accentedInput = PinyinUtils.ConvertNumericPinyinToAccented(normalizedInput);
            string withoutTones = PinyinUtils.RemovePinyinTones(accentedInput);

            // Console.WriteLine($"Normalized Input: {normalizedInput}");
            // Console.WriteLine($"Accented Input: {accentedInput}");
            // Console.WriteLine($"Without Tones: {withoutTones}");

            // Liste pour stocker les résultats
            List<WordInfo> results = new List<WordInfo>();

            // Recherche dans le dictionnaire
            foreach (var entry in data)
            {   
                string entryPinyin = entry["Pinyin"];
                string entryPinyinNoTones = PinyinUtils.RemovePinyinTones(PinyinUtils.ConvertNumericPinyinToAccented(entryPinyin));
                // Console.WriteLine($"input: {input} ; Entry:{entry["Pinyin"]}");
                // Console.WriteLine($"input: {input} ; Entry:{PinyinUtils.RemovePinyinTones(PinyinUtils.ConvertNumericPinyinToAccented(entry["Pinyin"]))}");

                //Console.WriteLine($"Entry: {entry["Simpl"]} - {entry["Trad"]} - {entry["Pinyin"]} - {entry["Translations"]}");
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
                string message = $"Aucun sinogramme trouvé pour '{input}'.";
                Console.WriteLine(message);
                return message;
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

        // public override string GetHelp()
        // {
        //     return "Obtenir le sinogramme simplifié d'un mot français ou du pinyin.";
        // }
    }
}