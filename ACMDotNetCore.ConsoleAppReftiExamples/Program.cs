using ACMDotNetCore.ConsoleAppReftiExamples;

try
{
    RefitExample refitExample = new RefitExample();
    await refitExample.RuuAsyn();
}
catch(Exception ex)
{
    Console.WriteLine(ex.ToString());
}



