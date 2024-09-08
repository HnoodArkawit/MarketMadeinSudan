using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMadeinSudan.Application.Features.FolderOrderDetails.Commands.DeleteOrderDetails
{
    public class DeleteOrderDetailsCommand : IRequest
    {
        public Guid OrderDetailsId { get; set; }

    }
}
