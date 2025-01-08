namespace DictionnaireZhFR;

public abstract class CommandBase
{
    protected LocalizationService _localizationService;
    protected Dictionnaire dictionnaire;

    public CommandBase(LocalizationService localizationService)
    {
        _localizationService = localizationService;
        dictionnaire = new Dictionnaire(localizationService);
    }

    // Méthode abstraite que chaque commande doit implémenter et retourner une chaîne
    public abstract string Execute(string input);
}