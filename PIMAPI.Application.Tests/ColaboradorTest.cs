using Moq;
using PIMAPI.Application.Abstraction.Domain.DTO;
using PIMAPI.Application.Abstraction.Domain.Request;
using PIMAPI.Application.Infra.Data.Repository;
using PIMAPI.Application.Interfaces;
using PIMAPI.Application.Services;

namespace PIMAPI.Application.Tests
{

    public class ColaboradorTest
    {
        private readonly IColaboradorService _service;
        private readonly Mock<IColaboradorRepository> _repository;

        public ColaboradorTest()
        {
            _service = new ColaboradorService();
            _repository = new Mock<IColaboradorRepository>();
        }

        [Fact]
        public async Task RegisterColaboratorTest()
        {
            var colaboratorRequest = new ColaboradorRequest
            {
                Nome = "Teste Nome",
                Email = "teste@email.com",
                CPF = "12345678901",
                Telefone = "1234567890",
                Data_Nascimento = "07122003",
                Endereco = "Rua Teste"
            };

            var colaboratorRepositoryMock = new Mock<IColaboradorRepository>();
            colaboratorRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Colaboradores>())).Returns(Task.CompletedTask);
            colaboratorRepositoryMock.Setup(repo => repo.SaveChangesAsync()).Returns(Task.CompletedTask);

            var colaboratorService = new ColaboradorService(colaboratorRepositoryMock.Object);

            // Act
            var result = await colaboratorService.RegisterColaborator(colaboratorRequest);

            // Assert
            Assert.Equal(1, result);
        }
    }
}