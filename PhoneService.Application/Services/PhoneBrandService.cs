using PhoneService.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Application.Services;
public class PhoneBrandService : IPhoneBrandService
{
	private readonly IPhoneBrandService phoneBrandService;

	public PhoneBrandService(IPhoneBrandService phoneBrandService)
	{
		this.phoneBrandService = phoneBrandService;
	}
}
