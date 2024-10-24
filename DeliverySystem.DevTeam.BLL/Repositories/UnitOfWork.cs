namespace DeliverySystem.DevTeam.BLL.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _dbContext;
		private Hashtable _repository;
		public UnitOfWork(ApplicationDbContext dbContext)
        {
			_dbContext = dbContext;
			_repository = new Hashtable();
		}


		public IGenericRepository<T> Repository<T>() where T : BaseEntity
		{
			var key  = typeof(T).Name;
			if (!_repository.ContainsKey(key)) 
			{
				var repository = new GenericRepository<T>(_dbContext) ;
				_repository.Add(key, repository);
			}

			return _repository[key] as IGenericRepository<T>;
		}

		public int Complete()
		{
			return _dbContext.SaveChanges();
		}


		public void Dispose()
		{ 
			_dbContext.Dispose();
		}

		
	}
}
