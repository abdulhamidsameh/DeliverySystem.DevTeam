using DeliverySystem.DevTeam.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.DevTeam.BLL.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{

		IGenericRepository<T> Repository<T>() where T : BaseEntity;
		int Complete();
    }
}
