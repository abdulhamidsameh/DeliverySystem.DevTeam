using DeliverySystem.DevTeam.DAL.Models;
using System.Linq.Expressions;
namespace DeliverySystem.DevTeam.BLL.Specifications
{
	public interface ISpecification<T> where T : BaseEntity
	{
		public Expression<Func<T, bool>> Criteria { get; set; }
		public List<Expression<Func<T, object>>> Includes { get; set; }
	}
}
