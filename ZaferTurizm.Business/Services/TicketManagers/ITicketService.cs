using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Business.Services.GenericCrudManagers;
using ZaferTurizm.DTOs;
using ZaferTurizm.DTOs.TicketAllDtos;

namespace ZaferTurizm.Business.Services.TicketManagers
{
    public interface ITicketService: ICrudService<TicketDto,TicketSummary>
    {
    }
}
