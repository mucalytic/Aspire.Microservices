using Aspire.Microservices.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Aspire.Microservices.Api.Tags;

public class TagsContext(DbContextOptions<TagsContext> options) : DbContext(options)
{
    public DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Colour).IsRequired().HasMaxLength(7);
            entity.Property(e => e.NoteId).IsRequired();
            entity.Property(e => e.CreatedAtUtc).IsRequired();
            entity.HasIndex(e => e.NoteId);
        });
    }
}
