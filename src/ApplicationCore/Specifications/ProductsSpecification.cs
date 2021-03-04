using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Linq;

namespace ApplicationCore.Specifications
{
    public class ProductsSpecification : Specification<Product>
    {
        public ProductsSpecification(params long[] ids)
        {
            Query.Where(p => ids.Contains(p.Id));
        }
    }
}
