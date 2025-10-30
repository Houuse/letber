using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using letber.lib;

namespace letber.grpc.backend.Services;

public class LibraryService : Library.LibraryBase
{
    private readonly ILogger<LibraryService> _logger;
    private readonly IDbService _dbService;

    public LibraryService(ILogger<LibraryService> logger, IDbService dbService)
    {
        _logger = logger;
        _dbService = dbService;
    }

    public override async Task<MostBorrowedBooksReply> MostBorrowedBooks(Empty request, ServerCallContext context)
    {
        var mbb = await _dbService.GetMostBorrowedBooks(context.CancellationToken);
        return new MostBorrowedBooksReply()
            { BooksDetails = { mbb.Select(d => new BookDetails() { RentalCount = d.RentalCount, BookTitle = d.Title }) } };
    }

    public override Task<MostBorrowersReply> MostBorrowers(MostBorrowersRequest request, ServerCallContext context)
    {
        //TODO
        //var mbs = await _dbService.GetMostBorrowers(request.FromDate, request.ToDate);
        var result = new MostBorrowersReply();
        return base.MostBorrowers(request, context);
    }

    public override Task<UserReadingPaceReply> UserReadingPace(UserRequest request, ServerCallContext context)
    {
        //TODO
        var result = new UserReadingPaceReply();
        return base.UserReadingPace(request, context);
    }

    public override Task<BorrowingPatternsReply> BorrowingPatterns(BookIdRequest request, ServerCallContext context)
    {
        //TODO
        return base.BorrowingPatterns(request, context);
    }
}