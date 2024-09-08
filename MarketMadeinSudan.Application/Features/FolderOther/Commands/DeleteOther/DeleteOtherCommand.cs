using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMadeinSudan.Application.Features.FolderOther.Commands.DeleteOther
{
    public class DeleteOtherCommand : IRequest
    {
        public Guid OtherId { get; set; }

    }
}
