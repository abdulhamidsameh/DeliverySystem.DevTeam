namespace DeliverySystem.DevTeam.BLL.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{

		IGenericRepository<T> Repository<T>() where T : BaseEntity;
		int Complete();
    }
}
