using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMadeinSudan.Application.Features.FolderWatchesAndJewelry.Commands.DeleteWatchesAndJewelry
{
    public class DeleteWatchesAndJewelryCommand : IRequest
    {
        public Guid WatchesAndJewelryId { get; set; }

    }
}
