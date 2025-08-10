using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Infrastructure.FluentConfiguration;
public class PhoneBrandFluentConfig : IEntityTypeConfiguration<PhoneBrand>
{
	public void Configure(EntityTypeBuilder<PhoneBrand> builder)
	{
		builder.HasKey(x => x.Id);

		builder.HasMany(pb => pb.Phones)
			   .WithOne(p => p.PhoneBrand)
			   .HasForeignKey(p => p.PhoneBrandId)
			   .OnDelete(DeleteBehavior.Cascade);
	}
}
