using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JaPark.Shared.Infrastructure.Outbox;

public class OutboxMessageConsumerConfiguration : IEntityTypeConfiguration<OutboxMessageConsumer>
{

    public void Configure(EntityTypeBuilder<OutboxMessageConsumer> builder)
    {
        builder.ToTable("OutboxMessageConsumer");
        builder.HasKey(x => new { x.Name, x.OutboxMessageId });
        builder.Property(o => o.Name).HasMaxLength(500);
    }
}
