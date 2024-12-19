namespace DictionnaireZhFR;

public class PinyinUtils
{
    private readonly Dictionary<char, string[]> _toneMapping;

    // Constructeur pour initialiser le dictionnaire de mapping
    public PinyinUtils()
    {
        _toneMapping = new Dictionary<char, string[]>
        {
            { 'a', new[] { "ā", "á", "ǎ", "à" } },
            { 'o', new[] { "ō", "ó", "ǒ", "ò" } },
            { 'e', new[] { "ē", "é", "ě", "è" } },
            { 'i', new[] { "ī", "í", "ǐ", "ì" } },
            { 'u', new[] { "ū", "ú", "ǔ", "ù" } },
            { 'ü', new[] { "ǖ", "ǘ", "ǚ", "ǜ" } }
        };
    }

    public string ConvertNumericPinyinToAccented(string numericPinyin)
    {
        // Découpe le pinyin en syllabes
        string[] syllables = numericPinyin.Split(' ');

        for (int i = 0; i < syllables.Length; i++)
        {
            string syllable = syllables[i];
            char tone = syllable.Last(); // Le dernier caractère est le ton numérique

            if (char.IsDigit(tone))
            {
                int toneIndex = int.Parse(tone.ToString()) - 1; // Convertir en index (0-4)

                foreach (char vowel in _toneMapping.Keys)
                {
                    if (syllable.Contains(vowel))
                    {
                        // Remplace la première voyelle trouvée par sa version accentuée
                        syllables[i] = syllable.Replace(vowel.ToString(), _toneMapping[vowel][toneIndex]);
                        break;
                    }
                }

                // Supprime le chiffre une fois la conversion effectuée
                syllables[i] = syllables[i].Remove(syllables[i].Length - 1);
            }
        }

        // Recompose les syllabes en une chaîne avec des espaces
        return string.Join(" ", syllables);
    }

    public string RemovePinyinTones(string pinyin)
    {
        return pinyin
            .Replace("ā", "a").Replace("á", "a").Replace("ǎ", "a").Replace("à", "a")
            .Replace("ō", "o").Replace("ó", "o").Replace("ǒ", "o").Replace("ò", "o")
            .Replace("ē", "e").Replace("é", "e").Replace("ě", "e").Replace("è", "e")
            .Replace("ī", "i").Replace("í", "i").Replace("ǐ", "i").Replace("ì", "i")
            .Replace("ū", "u").Replace("ú", "u").Replace("ǔ", "u").Replace("ù", "u")
            .Replace("ǖ", "ü").Replace("ǘ", "ü").Replace("ǚ", "ü").Replace("ǜ", "ü");
    }
}