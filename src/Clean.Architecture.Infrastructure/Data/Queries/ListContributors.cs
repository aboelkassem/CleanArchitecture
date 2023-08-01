﻿using Clean.Architecture.UseCases.Queries;
using Clean.Architecture.UseCases.Queries.GetContributor;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Infrastructure.Data.Queries;

public class ListContributors : IListContributorsQuery
{
  // You can use EF, Dapper, SqlClient, etc. for queries
  private readonly AppDbContext _db;

  public ListContributors(AppDbContext db)
  {
    _db = db;
  }
  public async Task<IEnumerable<ContributorDTO>> ListAsync()
  {
    var result = await _db.Contributors.FromSqlRaw("SELECT Id, Name FROM Contributors") // don't fetch other big columns
      .Select(c => new ContributorDTO(c.Id, c.Name))
      .ToListAsync();

    return result;
  }
}
