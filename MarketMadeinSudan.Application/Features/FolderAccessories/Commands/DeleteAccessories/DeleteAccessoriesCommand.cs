using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMadeinSudan.Application.Features.FolderAccessories.Commands.DeleteAccessories
{
    public class DeleteAccessoriesCommand : IRequest
    {
        public Guid AccessoriesId { get; set; }

    }
}
