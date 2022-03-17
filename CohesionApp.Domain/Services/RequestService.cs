using AutoMapper;
using CohesionApp.Data.Entities;
using CohesionApp.Data.Enums;
using CohesionApp.Data.Repositories;
using CohesionApp.Domain.Dtos;
using CohesionApp.Domain.Exceptions;
using CohesionApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CohesionApp.Domain.Services
{
    public class RequestService : IRequestService
    {
        private readonly IServiceRequestRepository _serviceRequestRepository;
        private readonly IMapper _mapper;
        public RequestService(IServiceRequestRepository serviceRequestRepository, IMapper mapper)
        {
            _serviceRequestRepository = serviceRequestRepository;
            _mapper = mapper;
        }

        public async Task CreateRequest(CreateRequestDto dto)
        {
            var request = _mapper.Map<CreateRequestDto, ServiceRequest>(dto);
            request.Id = Guid.NewGuid();
            request.CreatedBy = "Noe";
            request.CreatedDate = DateTime.Now;

            await _serviceRequestRepository.Create(request);
        }

        public async Task UpdateRequest(UpdateRequestDto dto)
        {
            var request = await _serviceRequestRepository.GetById(dto.Id);

            if (request == null)
                throw new NotFoundException("Service request not found");

            request.BuildingCode = dto.BuildingCode;
            request.Description = dto.Description;
            request.CurrentStatus = dto.CurrentStatus;
            request.LastModifiedBy = "Noe";
            request.LastModifiedDate = DateTime.Now;

            await _serviceRequestRepository.Update(request);
        }

        public async Task DeleteRequest(Guid id)
        {
            var request = await _serviceRequestRepository.GetById(id);

            if (request == null)
                throw new NotFoundException("Service request not found");

            await _serviceRequestRepository.Remove(request);
        }

        public async Task<RequestDto> GetRequestById(Guid id)
        {
           var request = await _serviceRequestRepository.GetById(id);

            if (request == null)
                throw new NotFoundException("Service request not found");

            return _mapper.Map<ServiceRequest, RequestDto>(request);
        }

        public async Task<List<RequestDto>> GetAllRequests()
        {
            var requests = await _serviceRequestRepository.GetAll();
            return _mapper.Map<List<ServiceRequest>,List<RequestDto>>(requests);
        }
    }
}
