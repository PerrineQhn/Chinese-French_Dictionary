namespace DictionnaireZhFR;

public class ReadFileCommand : CommandBase
{
    public override string Execute(string filepath)
    {
        if (!File.Exists(filepath))
        {
            Console.WriteLine($"Le fichier '{filepath}' est introuvable.");
            return $"Le fichier '{filepath}' est introuvable.";
        }    

        try
        {
            string content = File.ReadAllText(filepath);
            Console.WriteLine(content);
            return content;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");
            return $"Erreur : {ex.Message}";
        }
    }

}