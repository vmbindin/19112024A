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


            // Create an option with a description
            var singleOption = new Option<bool>
            (name: "--single",
            description: "An option whose argument is parsed as an int.");

            // Create a root command with a description
            var rootCommand = new RootCommand
            {
                Description = "Command with option"
            };

            rootCommand.Add(singleOption);
            rootCommand.SetHandler((singleOptionValue) =>
            {
                Console.WriteLine($"--single = {singleOptionValue}");
            },
            singleOption);

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