public class CommandInterpreter
{
    // private string command;

    // public CommandInterpreter(string command)
    // {
    //     this.command = command;
    // }

    public void Interpret(string[] arguments)
    {
        if (arguments.Length > 0)
        {  
            string command = arguments[0];

            if (command == "GetSinogram")
            {
                GetSinogramCommand cmd = new GetSinogramCommand();
                cmd.GetSimplifier(arguments[1]);
            }

            if (command == "GetTraditional")
            {
                GetTraditionalCommand cmd = new GetTraditionalCommand();
                cmd.GetTraditional(arguments[1]);
            }

            if (command == "GetFrench")
            {
                GetFrenchCommand cmd = new GetFrenchCommand();
                cmd.Traduction(arguments[1]);
            }

            if (command == "Pinyin")
            {
                GetPinyinCommand cmd = new GetPinyinCommand();
                cmd.GetPinyin(arguments[1]);
            }

            if (command == "GetAllInformation")
            {
                GetAllInformationCommand cmd = new GetAllInformationCommand();
                cmd.GetAllInformation(arguments[1]);
            }

        }

        else
        {
            Console.WriteLine("Entrer un argument parmi les suivants : GetSinogram, GetTraditional, GetFrench, Definition");
            Console.WriteLine("Exemple : dotnet run GetSinogram bonjour");
            Console.WriteLine("Exemple : dotnet run GetFrench 你好");
            Console.WriteLine("Exemple : dotnet run Definition bonjour");
        }
    }
}