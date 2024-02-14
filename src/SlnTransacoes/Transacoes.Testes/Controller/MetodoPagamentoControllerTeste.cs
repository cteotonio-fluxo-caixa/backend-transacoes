using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacoes.API.Controllers;
using Transacoes.API.Models.Request;
using Transacoes.API.Models.Response;
using Transacoes.Aplicacao.DTOs;
using Transacoes.Aplicacao.Servicos;

namespace Transacoes.Testes.Controller
{
    public class MetodoPagamentoControllerTeste
    {
        private readonly MetodoPagamentoController _controller;
        private readonly Mock<IMetodoPagamentoAppService> _mockMetodoPagamentoAppService;
        private readonly Mock<IMapper> _mockMapper;

        public MetodoPagamentoControllerTeste()
        {
            _mockMetodoPagamentoAppService = new Mock<IMetodoPagamentoAppService>();
            _mockMapper = new Mock<IMapper>();
            _controller = new MetodoPagamentoController(_mockMetodoPagamentoAppService.Object, _mockMapper.Object);
        }

        [Theory(DisplayName ="Registrar Método de Pagamento Válido - Ok Result")]
        [InlineData("PIX", "Método de pagamento PIX")]
        public async Task Registrar_MetodoPagamentoValido_OkResult(string nome, string descricao)
        {
            // Arrange
            var metodoPagamentoAppServiceMock = new Mock<IMetodoPagamentoAppService>();
            var mapperMock = new Mock<IMapper>();

            var controller = new MetodoPagamentoController(metodoPagamentoAppServiceMock.Object, mapperMock.Object);

            var metodoPagamentoRequest = new MetodoPagamentoRequest { Nome = nome, Descricao = descricao };
            var metodoPagamentoDTO = new MetodoPagamentoDTO { Nome = nome, Descricao = descricao };
            var metodoPagamentoResponse = new MetodoPagamentoResponse { Nome = nome, Descricao = descricao };

            mapperMock.Setup(m => m.Map<MetodoPagamentoDTO>(metodoPagamentoRequest)).Returns(metodoPagamentoDTO);
            metodoPagamentoAppServiceMock.Setup(s => s.RegistrarMetodoPagamento(metodoPagamentoDTO)).Verifiable();
            mapperMock.Setup(m => m.Map<MetodoPagamentoResponse>(metodoPagamentoDTO)).Returns(metodoPagamentoResponse);

            // Act
            var result = await controller.RegistrarMetodoPagamento(metodoPagamentoRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<MetodoPagamentoResponse>(okResult.Value);
            Assert.Equal(nome, returnValue.Nome);
            Assert.Equal(descricao, returnValue.Descricao);

            metodoPagamentoAppServiceMock.Verify(s => s.RegistrarMetodoPagamento(metodoPagamentoDTO), Times.Once);
        }
    }
}
