﻿using NimblePros.SampleToDo.Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NimblePros.SampleToDo.Infrastructure.Data.Config;

public class ToDoItemConfiguration : IEntityTypeConfiguration<ToDoItem>
{
  public void Configure(EntityTypeBuilder<ToDoItem> builder)
  {
    builder.Property(p => p.Id)
      .IsRequired()
      .HasValueGenerator<VogenIdValueGenerator<AppDbContext, ToDoItem, ToDoItemId>>();
    builder.Property(t => t.Title)
        .IsRequired();
    builder.Property(t => t.ContributorId)
        .IsRequired(false);
    builder.Property(t => t.Priority)
      .HasConversion(
          p => p.Value,
          p => Priority.FromValue(p));
  }
}