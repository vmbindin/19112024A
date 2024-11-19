using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;
using System.Linq;

namespace SampleSpace
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {

            // Create a single argument input to command
            var singleArgument = new Argument<int[]>
            (name: "number",
            description: "An argument that is parsed as an int.",
            getDefaultValue: () => [0]);


            // Create a sub command with a description
            var subCommand = new Command("number", "SubCommand with arguments");

            subCommand.Add(singleArgument);

            subCommand.SetHandler((singleArgumentValue)=>{

                foreach(int value in singleArgumentValue)
                {
                    Console.WriteLine("Your input {0}", value);
                }

            }, singleArgument);

            // Create a root command with a description
            var rootCommand = new RootCommand
            {
                Description = "Command with subcommand"
            };

            rootCommand.Add(subCommand);

            // Check if no arguments are provided and display help
            if (args.Length == 0)
            {
                rootCommand.Invoke("-h");
                return 0;
            }

            // Invoke the root command
            return await rootCommand.InvokeAsync(args);
        }
    }
}