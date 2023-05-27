using CommandLine;
using PasswordGenerator;

namespace HawkSteel
{
    internal class Program
    {
        public class Options
        {
            [Option('a', "AccountCount", Required = true, HelpText = "Account Count, Max 65535.")]
            public int AccountCount { get; set; }

            [Option('p', "AccountPrefix", Required = false, HelpText = "Custom Account Prefix.")]
            public string? AccountPrefix { get; set; }
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Generate Start.");
            Parser.Default.ParseArguments<Options>(args).WithParsed(Run);
        }

        private static void Run(Options option)
        {
            if (option.AccountCount < ushort.MinValue || option.AccountCount > ushort.MaxValue)
                throw new ArgumentException($"Illegal Parameter, Value : {option.AccountCount}");

            GenerateCSV(option);
            Console.WriteLine("Generate Done.");
        }

        private static void GenerateCSV(Options option)
        {
            using var writer = new StreamWriter(string.Format("GenerateAccount_{0}.csv",
                DateTime.Now.ToString("yyyyMMddHHmmss")));
            var accountPrefix = new Password().IncludeUppercase().LengthRequired(4).Next();
            var password = new Password().IncludeLowercase().IncludeUppercase().IncludeNumeric().LengthRequired(10);
            accountPrefix = string.IsNullOrEmpty(option.AccountPrefix) ? accountPrefix : option.AccountPrefix;

            writer.WriteLine("Account,Password");

            for (int i = 0; i < option.AccountCount; i++)
            {
                Console.WriteLine($"Generate Count {i}");
                // Numbers start from 1
                var numToString = (i + 1).ToString().PadLeft(5, '0');
                writer.WriteLine($"{accountPrefix}{numToString},{password.Next()}");
            }
        }
    }
}