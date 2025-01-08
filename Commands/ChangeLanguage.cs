namespace DictionnaireZhFR;

public class ChangeLanguageCommand : CommandBase
{
    LocalizationService localizationService;
    string newLang;

    public ChangeLanguageCommand(LocalizationService localizationService, string[] commandArgument) : base(commandArgument)
    {
        this.localizationService = localizationService;
        newLang = commandArgument[1];
    }

    public override string Execute(string input)
    {
        newLang = input;
        localizationService.ChangeLanguage(newLang);
        return $"Langue changée en {newLang}.";
    }
}