using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Infrastructure.FluentConfiguration;
public class PhoneFluentConfig : IEntityTypeConfiguration<Phone>
{
	public void Configure(EntityTypeBuilder<Phone> builder)
	{
		builder.HasKey(x => x.Id);

		builder.HasMany(p => p.Items)
			   .WithOne(i => i.Phone)
			   .HasForeignKey(i => i.PhoneId)
			   .OnDelete(DeleteBehavior.Cascade);
	}
}
