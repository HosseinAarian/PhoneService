using PhoneService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Application.Interfaces;
public interface IPhoneService
{
	Task<IEnumerable<Phone>> GetAllPhonesAsync();
	Task<Phone> GetPhoneByIdAsync(int id);
	Task CreatePhoneAsync(Phone phone);
	Task UpdatePhoneAsync(Phone phone);
	Task DeletePhoneAsync(int id);
}
