using Microsoft.EntityFrameworkCore;
using PhoneService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Infrastructure.Context;

public class PhoneServiceDBContext : DbContext
{
	public PhoneServiceDBContext(DbContextOptions<PhoneServiceDBContext> options) : base(options) { }

	public DbSet<PhoneBrand> phoneBrands => Set<PhoneBrand>();
	public DbSet<Phone> phones => Set<Phone>();
	public DbSet<Service> services => Set<Service>();
	public DbSet<Item> items => Set<Item>();

}
