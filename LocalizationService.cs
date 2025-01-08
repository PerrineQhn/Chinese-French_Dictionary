using System.Globalization;

namespace DictionnaireZhFR;

public class LocalizationService
{
    Dictionary<string, Dictionary<string, string>> data;
    string currentLanguage;

    public LocalizationService()
    {
        currentLanguage = CultureInfo.CurrentCulture.Name.Split("-")[0];

        // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-initialize-a-dictionary-with-a-collection-initializer
        data = new Dictionary<string, Dictionary<string, string>>()
        {
            { "fr" , new Dictionary<string, string>()
                {   
                    { "Entrez une commande (ou tapez 'Quitter' pour quitter) :", "Entrez une commande (ou tapez 'Quitter' pour quitter) :"},
                    { "GetSinogram", "ObtenirSinogramme" },
                    { "GetTraditional", "ObtenirTraditionnel" },
                    { "GetFrench", "ObtenirFrancais" },
                    { "GetPinyin", "ObtenirPinyin" },
                    { "GetAllInformation", "ObtenirToutesInformations" },
                    { "ChangeLanguage", "ChangerLangue" },
                    { "ReadSaveFile", "LireFichierSauvegarde" },
                    { "Help", "Aide" },
                    { "Exit", "Quitter" },
                    { "Au revoir !" , "Au revoir !" },
                    { "Commande", "Commande" },
                    { "Argument manquant. Veuillez entrer un mot après la commande.","Argument manquant. Veuillez entrer un mot après la commande."},
                    { "non reconnue", "non reconnue" },
                    { "Voulez-vous sauvegarder cette recherche ? (oui/non)", "Voulez-vous sauvegarder cette recherche ? (oui/non)"},
                    { "Recherche sauvegardée avec succès dans Output/searches.txt.", "Recherche sauvegardée avec succès dans Output/searches.txt."},
                    { "Recherche non sauvegardée.", "Recherche non sauvegardée."},
                    { "Aucune commande spécifiée.", "Aucune commande spécifiée."},
                    { "Options disponibles : GetSinogram, GetTraditional, GetFrench, Pinyin, GetAllInformation", "Options disponibles : ObtenirFrancais, ObtenirTraditionnel, ObtenirFrancais, ObtenirPinyin, ObtenirToutesInformations"},
                    { "Langue changée en", "Langue changée en"},
                    { "Génération du fichier JSON...", "Génération du fichier JSON..."},
                    { "Le fichier JSON existe déjà.", "Le fichier JSON existe déjà."},
                    { "WelcomeMessage", "Bienvenue dans le dictionnaire chinois-français !"},
                    { "JsonExists", "Génération du fichier JSON..."},
                    { "GeneratingJson", "Le fichier JSON existe déjà."},
                    { "Veuillez entrer une commande valide.", "Veuillez entrer une commande valide."},
                    { "Exemple : GetSinogram\tbonjour", "Exemple : ObtenirSinogramme\tbonjour" },
                    { "Exemple : GetFrench\t你好", "Exemple : ObtenirFrancais\t你好" },
                    { "Voici les commandes disponibles (un \\t est utilisé pour séparer la commande des arguments):", "Voici les commandes disponibles (un \\t est utilisé pour séparer la commande des arguments):"},
                    { "GetSinogramHelp", "- ObtenirSinogramme\t<mot-français> : Obtenir le sinogramme simplifié d'un mot français."},
                    { "GetTraditionalHelp", "- ObtenirTraditionnel\t<mot-chinois_simplifié> : Obtenir le sinogramme traditionnel d'un mot chinois."},
                    { "GetFrenchHelp", "- ObtenirFrancais\t<mot-chinois> : Obtenir la traduction française d'un mot chinois."},
                    { "GetPinyinHelp", "- ObtenirPinyin\t<mot-chinois> : Obtenir la translittération pinyin d'un mot chinois."},
                    { "GetAllInformationHelp", "- ObtenirToutesInformations\t<mot> : Obtenir toutes les informations sur un mot donné."},
                    { "ReadSaveFileHelp", "- LireFichierSauvegarde\t<chemin_fichier> : Lire le contenu d'un fichier texte comprenant les sauvegardes réalisées."},
                    { "ChangeLanguageHelp", "- ChangerLangue\t<langue> : Changer la langue du programme."},
                    { "HelpHelp", "- Aide : Afficher cette aide."},
                    { "ExitHelp", "- Quitter : Quitter le programme."},
                    { "\nExemples :", "\nExemples :"},
                    { " - GetSinogram\tbonjour", " - ObtenirSinogramme\tbonjour"},
                    { " - GetFrench\t你好", " - ObtenirFrancais\t你好"},
                    { "Aucune information trouvée pour '{0}'. Suggestions : {1}", "Aucune information trouvée pour '{0}'. Suggestions : {1}"},
                    { "Informations pour '{0}' ({1}) :\nLe sinogramme traditionnel est : {2}\nLe sinogramme simplifié : {3}\nLe pinyin : {4}\nLa traduction : {5}", "Informations pour '{0}' ({1}) :\nLe sinogramme traditionnel est : {2}\nLe sinogramme simplifié : {3}\nLe pinyin : {4}\nLa traduction : {5}"},
                    { "Informations pour '{0}' ({1}) :\nLe sinogramme simplifié : {2}\nLe pinyin : {3}\nLa traduction : {4}\n", "Informations pour '{0}' ({1}) :\nLe sinogramme simplifié : {2}\nLe pinyin : {3}\nLa traduction : {4}\n"},
                    { "Informations pour '{0}' ({1}) :\nLe sinogramme traditionnel est : {2}\nLe sinogramme simplifié : {3}\nLa traduction : {4}\n", "Informations pour '{0}' ({1}) :\nLe sinogramme traditionnel est : {2}\nLe sinogramme simplifié : {3}\nLa traduction : {4}\n"},
                    { "PinyinFound", "Pinyin pour '{0}' : {1}" },
                    { "PinyinNotFound", "Aucun Pinyin trouvé pour" },
                    { "FrenchTranslation", "Traduction française pour " },
                    { "NoTranslationFound", "Aucune traduction trouvée pour " },
                    { "NoSinogramFound", "Aucun sinogramme trouvé pour " },
                    { "SinogramsFound", "Sinogrammes trouvés pour " },
                    { "Simplified", "Simplifié" },
                    { "NoTraditionalFound", "Aucun caractère traditionnel trouvé pour " },
                    { "TraditionalFound", "Caractères traditionnels trouvés pour " },
                    { "Traditional", "Traditionnel" },
                    { "FileNotFound", "Fichier non trouvé pour '{0}'"},
                    { "Error", "Erreur"},
                    { "ErrorSavingSearch", "Erreur lors de la sauvegarde de la recherche" },
                    { "{0} : Command = {1}, Word = {2}", "{0} : Commande = {1}, Mot = {2}" },
                    { "Result : {0}", "Résultat : {0}" },
                    { "Simplified: {0}, Traditional: {1}, Pinyin: {2}, Translations: {3}", "Simplifié : {0}, Traditionnel : {1}, Pinyin : {2}, Traductions : {3}" },
                    { "EmptyOrInvalidJSON", "Fichier JSON vide ou invalide."},
                    { "JsonCreated", "Fichier JSON créé avec succès" },
                    { "ErrorSave", "Erreur lors de la sauvegarde du fichier JSON"}
                }   
            },
            { "en" , new Dictionary<string, string>()
                {   
                    { "Entrez une commande (ou tapez 'Quitter' pour quitter) :", "Enter a command (or type 'Exit' to exit):"},
                    { "GetSinogram", "GetSinogram" },
                    { "GetTraditional", "GetTraditional" },
                    { "GetFrench", "GetFrench" },
                    { "GetPinyin", "GetPinyin" },
                    { "GetAllInformation", "GetAllInformation" },
                    { "ChangeLanguage", "ChangeLanguage" },
                    { "ReadSaveFile", "ReadSaveFile" },
                    { "Help", "Help" },
                    { "Exit", "Exit" },
                    { "Au revoir !" , "Goodbye !" },
                    { "Commande", "Command" },
                    { "Argument manquant. Veuillez entrer un mot après la commande.","Missing argument. Please enter a word after the command."},
                    { "non reconnue", "unrecognized" },
                    { "Voulez-vous sauvegarder cette recherche ? (oui/non)", "Do you want to save this search? (yes/no)"},
                    { "Recherche sauvegardée avec succès dans Output/searches.txt.", "Search successfully saved in Output/searches.txt."},
                    { "Recherche non sauvegardée.", "Search not saved."},
                    { "Aucune commande spécifiée.", "No command specified."},
                    { "Options disponibles : GetSinogram, GetTraditional, GetFrench, Pinyin, GetAllInformation", "Available options: GetSinogram, GetTraditional, GetFrench, GetPinyin, GetAllInformation"},
                    { "Langue changée en", "Language changed to"},
                    { "Génération du fichier JSON...", "Generating JSON file..."},
                    { "Le fichier JSON existe déjà.", "JSON file already exists."},
                    { "WelcomeMessage", "Welcome to the Chinese-French dictionary!"},
                    { "JsonExists", "Generating JSON file..."},
                    { "GeneratingJson", "JSON file already exists."},
                    { "Veuillez entrer une commande valide.", "Please enter a valid command."},
                    { "Exemple : GetSinogram\tbonjour", "Example: GetSinogram\tbonjour" },
                    { "Exemple : GetFrench\t你好", "Example: GetFrench\t你好" },
                    { "Voici les commandes disponibles (un \\t est utilisé pour séparer la commande des arguments):", "Here are the available commands (a \\t is used to separate the command from the arguments):"},
                    { "GetSinogramHelp", "- GetSinogram\t<French-word> : Get the simplified sinogram of a French word."},
                    { "GetTraditionalHelp", "- GetTraditional\t<simplified_chinese-word> : Get the traditional sinogram of a simplified Chinese word."},
                    { "GetFrenchHelp", "- GetFrench\t<Chinese-word> : Get the French translation of a Chinese word."},
                    { "GetPinyinHelp", "- GetPinyin\t<Chinese-word> : Get the pinyin transliteration of a Chinese word."},
                    { "ChangeLanguageHelp", "- ChangeLanguage\t<lang> : Change the program language."},
                    { "GetAllInformationHelp", "- GetAllInformation\t<word> : Get all information about a given word."},
                    { "ReadSaveFileHelp", "- ReadSaveFile\t<file_path> : Read the content of a text file containing the saved searches."},
                    { "HelpHelp", "- Help : Display this help."},
                    { "ExitHelp", "- Exit : Exit the program."},
                    { "\nExemples :", "\nExamples :"},
                    { " - GetSinogram\tbonjour", " - GetSinogram\tbonjour"},
                    { " - GetFrench\t你好", " - GetFrench\t你好"},
                    { "Aucune information trouvée pour '{0}'. Suggestions : {1}", "No information found for '{0}'. Suggestions: {1}"},
                    { "Informations pour '{0}' ({1}) :\nLe sinogramme traditionnel est : {2}\nLe sinogramme simplifié : {3}\nLe pinyin : {4}\nLa traduction : {5}", "Information for '{0}' ({1}):\nThe traditional sinogram is: {2}\nThe simplified sinogram: {3}\nThe pinyin: {4}\nThe translation: {5}"},
                    { "Informations pour '{0}' ({1}) :\nLe sinogramme simplifié : {2}\nLe pinyin : {3}\nLa traduction : {4}\n", "Information for '{0}' ({1}):\nThe simplified sinogram: {2}\nThe pinyin: {3}\nThe translation: {4}\n"},
                    { "Informations pour '{0}' ({1}) :\nLe sinogramme traditionnel est : {2}\nLe sinogramme simplifié : {3}\nLa traduction : {4}\n", "Information for '{0}' ({1}):\nThe traditional sinogram is: {2}\nThe simplified sinogram: {3}\nThe translation: {4}\n"},
                    { "PinyinFound", "Pinyin for '{0}': {1}" },
                    { "PinyinNotFound", "No Pinyin found for" },
                    { "FrenchTranslation", "French translation for " },
                    { "NoTranslationFound", "No translation found for " },
                    { "NoSinogramFound", "No sinogram found for " },
                    { "SinogramsFound", "Sinograms found for " },
                    { "Simplified", "Simplified" },
                    { "NoTraditionalFound", "No traditional character found for " },
                    { "TraditionalFound", "Traditional characters found for " },
                    { "Traditional", "Traditional" },
                    { "FileNotFound", "File not found for '{0}'"},
                    { "Error", "Error" },
                    { "ErrorSavingSearch", "Error saving search" },
                    { "{0} : Command = {1}, Word = {2}", "{0} : Command = {1}, Word = {2}" },
                    { "Result : {0}", "Result : {0}" },
                    { "Simplified: {0}, Traditional: {1}, Pinyin: {2}, Translations: {3}", "Simplified: {0}, Traditional: {1}, Pinyin: {2}, Translations: {3}" },
                    { "EmptyOrInvalidJSON", "Empty or invalid JSON file." },
                    { "JsonCreated", "JSON file successfully created" },
                    { "ErrorSave", "Error saving JSON file" }
                }
            },

            {"zh", new Dictionary<string, string>()
                {
                    { "Entrez une commande (ou tapez 'Quitter' pour quitter) :", "输入命令（或键入“退出”以退出）：" },
                    { "GetSinogram", "获取汉字" },
                    { "GetTraditional", "获取繁体" },
                    { "GetFrench", "获取法文" },
                    { "GetPinyin", "获取拼音" },
                    { "GetAllInformation", "获取所有信息" },
                    { "ChangeLanguage", "更改语言" },
                    { "ReadSaveFile", "读取保存文件" },
                    { "Help", "帮助" },
                    { "Exit", "退出" },
                    { "Au revoir !" , "再见！" },
                    { "Commande", "命令" },
                    { "Argument manquant. Veuillez entrer un mot après la commande.","缺少参数。请输入命令后的单词。"},
                    { "non reconnue", "未识别" },
                    { "Voulez-vous sauvegarder cette recherche ? (oui/non)", "您要保存此搜索吗？（是/否）" },
                    { "Recherche sauvegardée avec succès dans Output/searches.txt.", "搜索已成功保存在Output/searches.txt中。" },
                    { "Recherche non sauvegardée.", "搜索未保存。" },
                    { "Aucune commande spécifiée.", "未指定任何命令。" },
                    { "Options disponibles : GetSinogram, GetTraditional, GetFrench, Pinyin, GetAllInformation", "可用选项：获取汉字，获取繁体，获取法文，获取拼音，获取所有信息" },
                    { "Langue changée en", "语言更改为" },
                    { "Génération du fichier JSON...", "正在生成JSON文件..." },
                    { "Le fichier JSON existe déjà.", "JSON文件已存在。" },
                    { "WelcomeMessage", "欢迎使用中法词典！" },
                    { "JsonExists", "正在生成JSON文件..." },
                    { "GeneratingJson", "JSON文件已存在。" },
                    { "Veuillez entrer une commande valide.", "请输入有效命令。" },
                    { "Exemple : GetSinogram\tbonjour", "示例：获取汉字\tbonjour" },
                    { "Exemple : GetFrench\t你好", "示例：获取法文\t你好" },
                    { "Voici les commandes disponibles (un \\t est utilisé pour séparer la commande des arguments):", "以下是可用命令（使用\\t将命令与参数分开）：" },
                    { "GetSinogramHelp", "- 获取汉字\t<法语单词>：获取法文单词的简化汉字。" },
                    { "GetTraditionalHelp", "- 获取繁体\t<简体字>：获取简体中文单词的繁体汉字。" },
                    { "GetFrenchHelp", "- 获取法文\t<中文单词>：获取中文单词的法文翻译。" },
                    { "GetPinyinHelp", "- 获取拼音\t<中文单词>：获取中文单词的拼音音译。" },
                    { "GetAllInformationHelp", "- 获取所有信息\t<反对>：获取有关给定单词的所有信息。" },
                    { "ChangeLanguageHelp", "- 更改语言\t<语言>：更改程序的语言。" },
                    { "ReadSaveFileHelp", "- 读取保存文件\t<文件路径>：读取包含保存搜索的文本文件的内容。" },
                    { "HelpHelp", "- 帮助：显示此帮助。" },
                    { "ExitHelp", "- 退出：退出程序。" },
                    { "\nExemples :", "\n示例：" },
                    { " - GetSinogram\tbonjour", " - 获取汉字\tbonjour" },
                    { " - GetFrench\t你好", " - 获取法文\t你好" },
                    { "Aucune information trouvée pour '{0}'. Suggestions : {1}", "未找到'{0}'的任何信息。建议：{1}" },
                    { "Informations pour '{0}' ({1}) :\nLe sinogramme traditionnel est : {2}\nLe sinogramme simplifié : {3}\nLe pinyin : {4}\nLa traduction : {5}", "关于'{0}'的信息（{1}）：\n传统汉字是：{2}\n简化汉字：{3}\n拼音：{4}\n翻译：{5}" },
                    { "Informations pour '{0}' ({1}) :\nLe sinogramme simplifié : {2}\nLe pinyin : {3}\nLa traduction : {4}\n", "关于'{0}'的信息（{1}）：\n简化汉字：{2}\n拼音：{3}\n翻译：{4}\n" },
                    { "Informations pour '{0}' ({1}) :\nLe sinogramme traditionnel est : {2}\nLe sinogramme simplifié : {3}\nLa traduction : {4}\n", "关于'{0}'的信息（{1}）：\n传统汉字是：{2}\n简化汉字：{3}\n翻译：{4}\n" },
                    { "PinyinFound", "'{0}'的拼音：{1}" },
                    { "PinyinNotFound", "未找到'{0}'的拼音" },
                    { "FrenchTranslation", "法文翻译为" },
                    { "NoTranslationFound", "未找到'{0}'的任何翻译" },
                    { "NoSinogramFound", "未找到'{0}'的任何汉字" },
                    { "SinogramsFound", "找到'{0}'的汉字" },
                    { "Simplified", "简化" },
                    { "NoTraditionalFound", "未找到'{0}'的任何繁体字符" },
                    { "TraditionalFound", "找到'{0}'的繁体字符" },
                    { "Traditional", "繁体" },
                    { "FileNotFound", "未找到'{0}'的文件" },
                    { "Error", "错误" },
                    { "ErrorSavingSearch", "保存搜索时出错" },
                    { "{0} : Command = {1}, Word = {2}", "{0} : 命令 = {1}, 单词 = {2}" },
                    { "Result : {0}", "结果：{0}" },
                    { "Simplified: {0}, Traditional: {1}, Pinyin: {2}, Translations: {3}", "简化：{0}，繁体：{1}，拼音：{2}，翻译：{3}" },
                    { "EmptyOrInvalidJSON", "空或无效的JSON文件。" },
                    { "JsonCreated", "JSON文件创建成功" },
                    { "ErrorSave", "保存JSON文件时出错" }
                }
            }
        };
    }

    public string GetText(string key)
    {
        if (data[currentLanguage].ContainsKey(key))
        {
            return data[currentLanguage][key];
        }

        // Si la clé n'existe pas, on vérifie si c'est une valeur
        string originalKey = GetOriginalCommand(key);
        if (originalKey != key && data[currentLanguage].ContainsKey(originalKey))
        {
            return data[currentLanguage][originalKey];
        }

        return key;
    }

    public string GetTextArg(string key, params object[] args)
    {
        string text = GetText(key);
        return string.Format(text, args);
    }

    public void ChangeLanguage(string lang)
    {
        //CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
        currentLanguage = lang;
    }

    public string GetOriginalCommand(string localizedCommand)
    {
        foreach (var lang in data)
        {
            foreach (var command in lang.Value)
            {
                if (command.Value == localizedCommand)
                {
                    return command.Key;
                }
            }
        }   
        return localizedCommand;
    }
}