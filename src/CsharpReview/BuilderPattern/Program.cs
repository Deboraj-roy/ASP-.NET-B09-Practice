// See https://aka.ms/new-console-template for more information
using BuilderPattern;

Console.WriteLine("BuilderPattern, World!");

string connectionString = 
    new ConnectionStringBuilder("localhost", "AspnetB9")
    .UseMultipleActiveRecords()
    .SetCredentials("aspnetb9", "123456")
    .UsePort(2222)
    .GetConnectionString();

Console.WriteLine(connectionString);