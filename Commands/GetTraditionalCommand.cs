using System.Text.RegularExpressions;

namespace DictionnaireZhFR
{
    public class GetTraditionalCommand : CommandBase
    {
        private readonly PinyinUtils _pinyinUtils = new PinyinUtils();


        public GetTraditionalCommand(LocalizationService localizationService) : base(localizationService)
        {
        }

        public override string Execute(string input)
        {
            List<Dictionary<string, string>> data = dictionnaire.ObtenirDonneesDictionnaire();
            
            string normalizedInput = input.Trim();
            string accentedInput = string.Empty;
            string withoutTones = string.Empty;

            // Si l’entrée correspond à un pattern du type [a-zü\d\s]+ alors appeler ConvertNumericPinyinToAccented
            if (Regex.IsMatch(input, @"^[a-zü\d\s]+$"))
            {
                normalizedInput = input.Trim().ToLower();
                accentedInput = _pinyinUtils.ConvertNumericPinyinToAccented(normalizedInput);
                withoutTones = _pinyinUtils.RemovePinyinTones(accentedInput);

                // Console.WriteLine($"Normalized Input: {normalizedInput}");
                // Console.WriteLine($"Accented Input: {accentedInput}");
                // Console.WriteLine($"Without Tones: {withoutTones}");
            }

            // Liste pour stocker les résultats
            List<WordInfo> results = new List<WordInfo>();

            // Recherche dans le dictionnaire
            foreach (Dictionary<string, string> entry in data)
            {       
                string entryPinyin = entry["Pinyin"];
                string entryPinyinNoTones = _pinyinUtils.RemovePinyinTones(_pinyinUtils.ConvertNumericPinyinToAccented(entryPinyin));

                // Comparaison avec différentes formes de pinyin ou caractères chinois
                if (entry["Simpl"] == input || entryPinyin == input)
                {
                    results.Add(CreateWordInfo(entry));
                }
                else if (!string.IsNullOrEmpty(normalizedInput) && entryPinyin == normalizedInput)
                {
                    results.Add(CreateWordInfo(entry));
                }
                else if (!string.IsNullOrEmpty(withoutTones) && entryPinyinNoTones == withoutTones)
                {
                    results.Add(CreateWordInfo(entry));
                }
            }

            if (results.Count == 0)
            {
                string message = _localizationService.GetText("NoTraditionalFound") + $"'{input}'.";
                Console.WriteLine(message);
                return message;
            }

            // Générer un message contenant tous les résultats trouvés
            string output = string.Join("\n", results.Select(w => w.ToString()));
            Console.WriteLine(_localizationService.GetText("TraditionalFound") + $"'{input}':\n{output}");
            return output;
        }

        private WordInfo CreateWordInfo(Dictionary<string, string> entry)
        {
            return new WordInfo(
                $" {_localizationService.GetText("Traditional")}: {entry["Trad"]}"
            );
        }
    }
}