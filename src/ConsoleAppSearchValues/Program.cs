using System.Buffers;
using System.Runtime.InteropServices;

Console.WriteLine("***** Testes com .NET 9 | SearchValues + substrings *****");
Console.WriteLine($"Versao do .NET em uso: {RuntimeInformation
    .FrameworkDescription} - Ambiente: {Environment.MachineName} - Kernel: {Environment
    .OSVersion.VersionString}");

const string UrlBase = "https://raw.githubusercontent.com/renatogroffe/DotNet9-ConsoleApp-SearchValues/refs/heads/main/sample.data";

using var httpClient = new HttpClient();
var text = await httpClient.GetStringAsync(UrlBase);

Console.WriteLine();
Console.WriteLine("Texto que sera utilizado:");

Console.WriteLine();
var newColor = ConsoleColor.DarkCyan;
var oldColor = Console.ForegroundColor;
Console.ForegroundColor = newColor;
Console.WriteLine(text);
Console.ForegroundColor = oldColor;

string? part = null;
do
{
    Console.WriteLine();
    Console.WriteLine("Informe uma string a ser pesquisada:");
    Console.ForegroundColor = newColor;
    part = Console.ReadLine();
    Console.ForegroundColor = oldColor;
}
while (String.IsNullOrEmpty(part));

Console.WriteLine();
var searchValues = SearchValues.Create([part],
    StringComparison.OrdinalIgnoreCase);
var spanText = text.AsSpan();
Console.WriteLine($"IndexOfAny = {spanText.IndexOfAny(searchValues)}");