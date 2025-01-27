using Dermastore.Domain.Entities;

namespace Dermastore.Domain.Specifications
{
    public class ExampleEntitySpecification : BaseSpecification<ExampleEntity>
    {
        public ExampleEntitySpecification(ExampleEntitySpecParams exampleEntitySpecParams) 
            : base(x => x.Name == exampleEntitySpecParams.Search)
        {
            AddInclude(x => x.Gender);
        }
    }
}
