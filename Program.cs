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


            // Create a sub command with a description
            var subCommand = new Command("number", "SubCommand with arguments");


            subCommand.SetHandler(()=>{

                Console.WriteLine("Sub Command");

            });

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