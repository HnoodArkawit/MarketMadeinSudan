using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMadeinSudan.Application.Features.FolderAspires.Commands.DeleteAspires
{
    public class DeleteAspiresCommand : IRequest
    {
        public Guid AspiresId { get; set; }

    }
}
