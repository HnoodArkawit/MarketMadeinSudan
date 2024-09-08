using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMadeinSudan.Application.Features.FolderAspires.Commands.GetAspiresList
{
    public class GetAspiresListQuery : IRequest<List<GetAspiresListViewModel>>
    {

    }
}
