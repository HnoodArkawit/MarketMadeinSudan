using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMadeinSudan.Application.Features.FolderAgriculturalCrops.Commands.DeleteAgriculturalCrops
{
    public class DeleteAgriculturalCropsCommand : IRequest
    {
        public Guid AgriculturalCropsId { get; set; }

    }
}
