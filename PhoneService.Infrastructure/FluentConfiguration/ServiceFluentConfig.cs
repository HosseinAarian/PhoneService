using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Infrastructure.FluentConfiguration;

public class ServiceFluentConfig : IEntityTypeConfiguration<Service>
{
	public void Configure(EntityTypeBuilder<Service> builder)
	{
		builder.HasKey(x => x.Id);

		builder.HasMany(s => s.Items)
			   .WithOne(i => i.Service)
			   .HasForeignKey(i => i.ServiceId)
			   .OnDelete(DeleteBehavior.Cascade);
	}
}
