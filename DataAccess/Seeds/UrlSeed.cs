using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Seeds;

public class UrlSeed : IEntityTypeConfiguration<Url>
{
    public void Configure(EntityTypeBuilder<Url> builder)
    {
        builder.HasData(
            new Url
            {
                Id = Guid.NewGuid(),
                FullUrl = "https://github.com/shikayo",
                ShortUrl = "localhost:45367/cautct",
                Code = "cautct",
                DateOfCreate = DateTime.Now,
                Count = 1
            },
            
            new Url
            {
                Id = Guid.NewGuid(),
                FullUrl = "https://www.google.ru",
                ShortUrl = "localhost:45367/8mbCpl",
                Code = "8mbCpl",
                DateOfCreate = DateTime.Now,
                Count = 0
            }
            
        );
    }
}