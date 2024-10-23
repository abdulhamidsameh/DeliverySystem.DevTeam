namespace DeliverySystem.DevTeam.BLL.Specifications
{
	public class BaseSpacefications<T> : ISpecification<T> where T : BaseEntity
	{
		public BaseSpacefications(Expression<Func<T, bool>> criteriaExpression)
		{
			Criteria = criteriaExpression;
		}
		public BaseSpacefications()
		{

		}


		public Expression<Func<T, bool>> Criteria { get; set; } = null!;
		public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
	}
}
