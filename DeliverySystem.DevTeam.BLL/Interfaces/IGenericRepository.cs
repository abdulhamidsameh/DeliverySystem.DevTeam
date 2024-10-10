using DeliverySystem.DevTeam.BLL.Specifications;
using DeliverySystem.DevTeam.DAL.Models;
namespace DeliverySystem.DevTeam.BLL.Interfaces
{
	public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T? GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
		IEnumerable<T> GetAllWithSpec(ISpecification<T> spec);
		T? GetWithSpec(ISpecification<T> spec);

	}
}
