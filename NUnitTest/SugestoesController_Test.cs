using WebFinanceiroApi;
using WebFinanceiroApi.Controllers;
using WebFinanceiroApi.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebFinanceiroApi.NUnitTest
{
    [TestFixture]
    public class SugestoesController_Test
    {
        private SugestoesController sugestoesController;

        private readonly FINANCEIROContext _context;

        [SetUp]
        public void Setup()
        {
            sugestoesController = new SugestoesController(_context);
        }

        [TestCase(1)]
        public void GetSugestoesById_Passe(int id)
        {
            //Padrão AAA:
            //Arrange
            var resultado = sugestoesController.GetSugestao(id).GetAwaiter().GetResult();

            //Act
            var nome = resultado.Value.Nome;

            //Assert
            Assert.IsTrue(nome.Length > 0);
        }

        [Test]
        public void Test1()
        {
            //Padrão AAA:
            //Arrange
            var resultado = sugestoesController.GetSugestao().Result;
            //Act
            var nome = resultado.Result.ToString();

            //Assert
            Assert.IsTrue(nome.Length > 0);
        }
    }
}