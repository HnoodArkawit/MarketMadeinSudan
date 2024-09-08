using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMadeinSudan.Application.Features.FolderHouseholdProducts.Commands.DeleteHouseholdProducts
{
    public class DeleteHouseholdProductsCommand : IRequest
    {
        public Guid HouseholdProductsId { get; set; }

    }
}
