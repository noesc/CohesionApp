using AutoMapper;
using CohesionApp.Data.Entities;
using CohesionApp.Data.Repositories;
using CohesionApp.Domain.Dtos;
using CohesionApp.Domain.Exceptions;
using CohesionApp.Domain.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CohesionApp.Tests
{
    public class RequestServiceTest
    {
        private readonly Mock<IServiceRequestRepository> _serviceRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private RequestService _service;

        public RequestServiceTest()
        {
            _serviceRepositoryMock = new Mock<IServiceRequestRepository>();
            _mapperMock = new Mock<IMapper>();
            
        }

        [Fact]
        public void GetRequestById_throw_exception_when_request_not_found()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            _serviceRepositoryMock.Setup(x => x.GetById(id)).ReturnsAsync((ServiceRequest)null);
            _service = new RequestService(_serviceRepositoryMock.Object, _mapperMock.Object);

            //Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() =>_service.GetRequestById(id));
        }

        [Fact]
        public async void GetRequestById_should_return_request()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            string buildingCode = "TST";
            var request = new ServiceRequest() { Id = id, BuildingCode = buildingCode };
            var dto = new RequestDto() { BuildingCode = buildingCode };
            _serviceRepositoryMock.Setup(x => x.GetById(id)).ReturnsAsync(request);
            _mapperMock.Setup(x => x.Map<ServiceRequest, RequestDto>(request)).Returns(dto);
            _service = new RequestService(_serviceRepositoryMock.Object, _mapperMock.Object);

            //Act
            var result = await _service.GetRequestById(id);

            //Assert
            _serviceRepositoryMock.Verify(x => x.GetById(It.IsAny<Guid>()), Times.Once);
            _mapperMock.Verify(x => x.Map<ServiceRequest, RequestDto>(It.IsAny<ServiceRequest>()), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(request.BuildingCode, dto.BuildingCode);
        }
    }
}
