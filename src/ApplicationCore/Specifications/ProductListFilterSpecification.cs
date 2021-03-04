using ApplicationCore.Entities;
using Ardalis.Specification;
using System.Linq;

namespace ApplicationCore.Specifications
{
    public class ProductListFilterSpecification: Specification<Product>
    {
        public ProductListFilterSpecification(int? brandId, int? typeId)
        {
            Query
                .Where(i => (!brandId.HasValue || i.BrandId == brandId) &&
                (!typeId.HasValue || i.ProductTypeId == typeId));                
        }
    }
}
