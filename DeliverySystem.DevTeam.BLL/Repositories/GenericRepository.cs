using DeliverySystem.DevTeam.BLL.Interfaces;
using DeliverySystem.DevTeam.DAL.Data;
using DeliverySystem.DevTeam.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.DevTeam.BLL.Repositories
{
    public class GenericRepository<T>  : IGenericRepository<T> where T : BaseEntity
	{
		private protected readonly ApplicationDbContext _dbContext;

		public GenericRepository(ApplicationDbContext dbContext)
        {
			this._dbContext = dbContext;
		}
        public void Add(T entity)
			=> _dbContext.Set<T>().Add(entity);
		
		

		public void Delete(T entity)
			=> _dbContext.Set<T>().Remove(entity);
			

		public IEnumerable<T> GetAll()
		
			=> _dbContext.Set<T>().AsNoTracking().ToList();
		

		public T GetById(int id)
		{
			return _dbContext.Find<T>(id); 
		}

		public void Update(T entity)
			=> _dbContext.Set<T>().Update(entity);
			
		
	}
}
