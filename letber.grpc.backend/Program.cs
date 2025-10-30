using DvdRental.DB.Context;
using letber.grpc.backend.Services;
using letber.lib;

namespace letber.grpc.backend;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddGrpc();
        builder.Services.AddGrpcReflection();
        var connectionString = builder.Configuration.GetConnectionString("Postgres");
        builder.Services.AddNpgsql<DvdRentalDbContext>(connectionString);
        builder.Services.AddTransient<IDbService, DbService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.MapGrpcService<LibraryService>();
        app.MapGet("/",
            () =>
                "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

        app.Run();
    }
}