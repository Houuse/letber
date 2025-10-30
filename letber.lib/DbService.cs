using DvdRental.DB.Context;
using Google.Protobuf.WellKnownTypes;
using letber.lib.dto;
using Microsoft.EntityFrameworkCore;

namespace letber.lib;

public class DbService : IDbService
{
    private readonly DvdRentalDbContext _dvdRentalDbContext;

    public DbService(DvdRentalDbContext dvdRentalDbContext)
    {
        _dvdRentalDbContext = dvdRentalDbContext;
    }
    public async Task<List<BookDetailsDto>> GetMostBorrowedBooks(CancellationToken contextCancellationToken)
    {
        var result = _dvdRentalDbContext.Database.SqlQuery<BookDetailsDto>($"""
                                                                            SELECT f.title as Title, rc.rental_count as RentalCount
                                                                            FROM (SELECT COUNT(*) rental_count, r.inventory_id
                                                                                  FROM rental r
                                                                                  GROUP BY r.inventory_id
                                                                                  HAVING COUNT(*) > 1
                                                                                  ORDER BY COUNT(*) DESC) rc
                                                                                     JOIN inventory i ON rc.inventory_id = i.inventory_id
                                                                                     JOIN film f ON i.film_id = f.film_id
                                                                            ORDER BY rental_count DESC
                                                                            LIMIT 10
                                                                            """);
        return result.ToList();
    }

    public Task<object> GetMostBorrowers(Timestamp requestFromDate, Timestamp requestToDate)
    {
        throw new NotImplementedException();
    }
}