using Google.Protobuf.WellKnownTypes;
using letber.lib.dto;

namespace letber.lib;

public interface IDbService
{
    Task<List<BookDetailsDto>> GetMostBorrowedBooks(CancellationToken contextCancellationToken);
    Task<object> GetMostBorrowers(Timestamp requestFromDate, Timestamp requestToDate);
}