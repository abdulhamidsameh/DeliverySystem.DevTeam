using DeliverySystem.DevTeam.DAL.Models;
using Microsoft.EntityFrameworkCore;
namespace DeliverySystem.DevTeam.BLL.Specifications
{
	internal static class SpeceficationsEvaluator<T> where T : BaseEntity
	{
		public static IQueryable<T> GetQuery(IQueryable<T> inputQuery,ISpecification<T> spec)
		{
			var query = inputQuery;

			if (spec.Criteria is not null)
				query = query.Where(spec.Criteria);
			
			if (spec.Includes.Count > 0)
				foreach (var include in spec.Includes)
					query = query.Include(include);

			return query;
		}

	}
}
