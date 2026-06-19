using Domain.Curriculum.Subjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Curriculum.Subjects;

public sealed class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.ToTable("Subjects", "Curriculum");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasConversion(id => id.Value,
            value => SubjectId.From(value));

        builder.Property(x => x.Name)
            .HasMaxLength(SubjectName.MaxLength)
            .HasConversion(name => name.Value, value => SubjectName.Create(value))
            .IsRequired();

        builder.HasIndex(x => x.Name)
            .IsUnique();

        builder.Property(x => x.Description)
            .HasMaxLength(500)
            .IsRequired();


        builder.Property(x => x.GradeBand)
            .HasMaxLength(25)
            .HasConversion(gradeBand => gradeBand.Value,
                value => GradeBand.Create(value))
            .IsRequired();

        builder.Property(x => x.IsArchived)
            .IsRequired();
    }
}