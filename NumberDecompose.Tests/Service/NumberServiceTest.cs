using NumberDecompose.Business.Interface;
using NumberDecompose.Business.Service;
using NumberDecompose.CrossCutting.Exceptions;
using NumberDecompose.Data.Context;
using NumberDecompose.Data.Interface;
using NumberDecompose.Data.Repository;
using NumberDecompose.Tests.Helper;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace NumberDecompose.Tests.Service
{
    public class NumberServiceTest
    {
        private INumberService _numberService;
        private INumberRepository _numberRepository;
        private DataContext _dataContext;

        [SetUp]
        public void Setup()
        {
            _dataContext = new DataContext();
            _numberRepository = new NumberRepository(_dataContext);
            _numberService = new NumberService(_numberRepository);
        }

        [Test]
        public void Deve_retornar_primo_falso_quando_numero_for_zero()
        {
            var result = _numberService.IsPrime(0);
            Assert.AreEqual(result, false);
        }

        [Test]
        public void Deve_retornar_primo_verdadeiro_quando_numero_for_dois()
        {
            var result = _numberService.IsPrime(2);
            Assert.AreEqual(result, true);
        }

        [Test]
        public void Deve_retornar_primo_falso_quando_numero_for_par_e_maior_que_dois()
        {
            var result = _numberService.IsPrime(4);
            Assert.AreEqual(result, false);
        }

        [Test]
        public void Deve_retornar_primo_verdadeiro_quando_numero_for_um()
        {
            var result = _numberService.IsPrime(1);
            Assert.AreEqual(result, true);
        }

        [Test]
        public void Deve_retornar_primo_verdadeiro_quando_numero_for_tres()
        {
            var result = _numberService.IsPrime(3);
            Assert.AreEqual(result, true);
        }

        [Test]
        public void Deve_retornar_lista_de_numeros_primos_corretamente()
        {
            var listResult = _numberService.GetPrimes(TestHelper.GetNumbersList());

            Assert.IsTrue(listResult.Any());
            Assert.AreEqual(listResult, new List<int> { 1, 3, 5 });
        }

        [Test]
        public void Deve_retornar_lista_vazia()
        {
            var listResult = _numberService.GetPrimes(TestHelper.GetEmptyList());

            Assert.IsFalse(listResult.Any());
            Assert.AreEqual(listResult, new List<int>());
        }

        [Test]
        public void Deve_retornar_lista_de_divisores_corretamente()
        {
            var listResult = _numberService.GetDividers(45);

            Assert.IsTrue(listResult.Any());
            Assert.AreEqual(listResult, new List<int> { 1, 3, 5, 9, 15, 45 });
        }

        [Test]
        public void Deve_retornar_excecao_quando_numero_for_menor_que_zero()
        {
            var ex = Assert.Throws<EntityValidationException>(() => _numberService.GetDividers(-1));

            Assert.That(ex.Message == "Informe um valor inteiro, positivo e maior que zero.");
        }

        [Test]
        public void Deve_retornar_excecao_quando_numero_for_igual_a_zero()
        {
            var ex = Assert.Throws<EntityValidationException>(() => _numberService.GetDividers(0));

            Assert.That(ex.Message == "Informe um valor inteiro, positivo e maior que zero.");
        }

        [Test]
        public void Deve_retornar_objeto_corretamente_para_numero_45()
        {
            var dto = _numberService.Decompose(45);

            Assert.IsNotNull(dto);
            Assert.AreEqual(dto.Value, 45);

            Assert.IsTrue(dto.Divisors.Any());
            Assert.AreEqual(dto.Divisors, new List<int> { 1, 3, 5, 9, 15, 45 });

            Assert.IsTrue(dto.PrimeDivisors.Any());
            Assert.AreEqual(dto.PrimeDivisors, new List<int> { 1, 3, 5 });
        }

        [Test]
        public void Deve_retornar_objeto_corretamente_para_numero_64()
        {
            var dto = _numberService.Decompose(64);

            Assert.IsNotNull(dto);
            Assert.AreEqual(dto.Value, 64);

            Assert.IsTrue(dto.Divisors.Any());
            Assert.AreEqual(dto.Divisors, new List<int> { 1, 2, 4, 8, 16, 32, 64 });

            Assert.IsTrue(dto.PrimeDivisors.Any());
            Assert.AreEqual(dto.PrimeDivisors, new List<int> { 1, 2 });
        }
    }
}