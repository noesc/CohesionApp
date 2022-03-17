using CohesionApp.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CohesionApp.Domain.Interfaces
{
    public interface IRequestService
    {
        Task CreateRequest(CreateRequestDto dto);
        Task UpdateRequest(UpdateRequestDto dto);
        Task DeleteRequest(Guid id);
        Task<RequestDto> GetRequestById(Guid id);
        Task<List<RequestDto>> GetAllRequests();

    }
}
