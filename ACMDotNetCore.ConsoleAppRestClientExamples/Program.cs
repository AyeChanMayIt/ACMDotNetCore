// See https://aka.ms/new-console-template for more information
using ACMDotNetCore.ConsoleAppRestClientExamples;
using RestSharp;

Console.WriteLine("Hello, World!");
RestClientExamples restClientExamples = new RestClientExamples();
await restClientExamples.RunAsync();

