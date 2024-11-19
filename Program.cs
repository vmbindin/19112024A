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
            // Create a root command with a description
            var rootCommand = new RootCommand
            {
                Description = "Command with arguments"
            };

            // Create a single argument input to command
            var singleArgument = new Argument<int>
            (name: "number",
            description: "An argument that is parsed as an int.",
            getDefaultValue: () => 0);


            rootCommand.Add(singleArgument);

            rootCommand.SetHandler((singleArgumentValue)=>{

                Console.WriteLine("Your input {0}", singleArgumentValue);


            }, singleArgument);

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