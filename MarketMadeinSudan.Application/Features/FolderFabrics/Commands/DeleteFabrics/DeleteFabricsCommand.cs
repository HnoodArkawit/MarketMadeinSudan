using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMadeinSudan.Application.Features.FolderFabrics.Commands.DeleteFabrics
{
    public class DeleteFabricsCommand : IRequest
    {
        public Guid FabricsId { get; set; }

    }
}
