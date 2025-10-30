using System.Text.Json.Nodes;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Spectre.Console;
using Spectre.Console.Json;

namespace letber.client;

class Program
{
    static async Task<int> Main(string[] args)
    {
        try
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7052");
            var client = new Library.LibraryClient(channel);

            var name = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Pick a [green]Method to call[/]?")
                    .AddChoices("MostBorrowedBooks", "BorrowingPatterns", "MostBorrowers", "UserReadingPace"));
            JsonText json = new JsonText("");
            switch (name)
            {
                case "MostBorrowedBooks":
                    var mbdResult = (await client.MostBorrowedBooksAsync(new Empty()));
                    json = new JsonText(System.Text.Json.JsonSerializer.Serialize(mbdResult.BooksDetails));
                    break;
                case "BorrowingPatterns":
                    var bpResult = client.BorrowingPatterns(new BookIdRequest());
                    json = new JsonText(System.Text.Json.JsonSerializer.Serialize(bpResult.BooksDetails));
                    break;
                case "MostBorrowersAsync":
                    var mbsResult = await client.MostBorrowersAsync(new MostBorrowersRequest()
                    {
                        FromDate = Timestamp.FromDateTime(DateTime.Today.AddYears(-10)),
                        ToDate = Timestamp.FromDateTime(DateTime.Today)
                    });
                    json = new JsonText(System.Text.Json.JsonSerializer.Serialize(mbsResult.Users));
                    break;
                case "UserReadingPaceAsync":
                    var urResult = await client.UserReadingPaceAsync(new UserRequest() { Id = 1 });
                    json = new JsonText(System.Text.Json.JsonSerializer.Serialize(urResult.PagesPerDay));
                    break;
            }

            AnsiConsole.Write(
                new Panel(json)
                    .Header($"Result for method {name} is:")
                    .Collapse()
                    .RoundedBorder()
                    .BorderColor(Color.Yellow));
            return 0;
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteException(ex, ExceptionFormats.ShortenEverything);
            return -1;
        }
    }
}