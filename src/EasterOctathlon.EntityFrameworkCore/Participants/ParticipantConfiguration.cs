using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EasterOctathlon.Participants;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EasterOctathlon.EntityFrameworkCore.Participants;

public class ParticipantConfiguration : IEntityTypeConfiguration<Participant>
{
    public void Configure(EntityTypeBuilder<Participant> builder)
    {
        builder.ToTable("Participants", EasterOctathlonConsts.DbSchema);
        builder.ConfigureByConvention();

        builder.Property(x => x.Uid)
            .IsRequired();

        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(ParticipantConsts.MaxFirstNameLength);

        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(ParticipantConsts.MaxLastNameLength);

        builder.Property(x => x.NickName)
            .HasMaxLength(ParticipantConsts.MaxNickNameLength);

        builder.Property(x => x.Gender)
            .IsRequired();

        builder.Property(x => x.DateOfBirth)
            .HasColumnType("date");

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.Property(x => x.Note)
            .HasMaxLength(ParticipantConsts.MaxNoteLength);

        builder.HasIndex(x => x.Uid)
            .IsUnique();
    }
}
