using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMadeinSudan.Application.Features.FolderPublishers.Commands.DeletePublishers
{
    public class DeletePublishersCommand : IRequest
    {
        public Guid PublishersId { get; set; }

    }
}
