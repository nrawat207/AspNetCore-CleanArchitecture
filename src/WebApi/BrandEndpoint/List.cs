using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.BrandEndpoint
{
    public class List : BaseAsyncEndpoint
        .WithoutRequest
        .WithResponse<ListBrandResponse>
    {
        private readonly IRepository<Brand> _brandRepository;
        private readonly IMapper _mapper;

        public List(IRepository<Brand> brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        [HttpGet("api/brands")]
        [SwaggerOperation(
            Summary ="List Brands",
            Description ="List Brands",
            OperationId ="brands.List",
            Tags =new[] {"BrandEnpoints"}
        )]
        public override async Task<ActionResult<ListBrandResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var response = new ListBrandResponse();
            var items = await _brandRepository.ListAllAsync(cancellationToken);
            response.Brands.AddRange(items.Select(_mapper.Map<BrandDto>));

            return response;
        }
    }
}
