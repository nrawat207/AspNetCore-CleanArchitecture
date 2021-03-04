using ApplicationCore.Entities;
using Ardalis.Specification;

namespace ApplicationCore.Specifications
{
    public class ProductListFilterPaginatedSpecification: Specification<Product>
    {
           public ProductListFilterPaginatedSpecification(int skip,int take,int? brandId, int? typeId)
                :base()
           {
            Query
                .Where(i => (!brandId.HasValue || i.BrandId == brandId) &&
                (!typeId.HasValue || i.ProductTypeId == typeId))
                .Paginate(skip, take);
           }
    }
}
