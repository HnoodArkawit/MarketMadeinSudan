using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMadeinSudan.Application.Features.FolderSportAndEntertainment.Commands.DeleteSportAndEntertainment
{
    public class DeleteSportAndEntertainmentCommand : IRequest
    {
        public Guid SportAndEntertainmentId { get; set; }

    }
}
