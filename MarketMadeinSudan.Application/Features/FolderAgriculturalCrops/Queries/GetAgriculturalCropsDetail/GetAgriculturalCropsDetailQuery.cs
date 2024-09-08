using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderAgriculturalCrops.Queries.GetAgriculturalCropsDetail
{
    public class GetAgriculturalCropsDetailQuery : IRequest<GetAgriculturalCropsDetailViewModel>
    {
        public Guid AgriculturalCropsId { get; set; }
    }
}
