using DDD.Domain.ValueObjects;
using FluentAssertions;
using System;
using Xunit;

namespace DDD.Tests
{
    public class DinheiroTest
    {
        [Fact]
        public void SumShouldReturnSuccess()
        {
            var dinheiro1 = new Dinheiro(10);
            var dinheiro2 = new Dinheiro(20);
            var soma = dinheiro1 + dinheiro2;

            soma.Valor.Should().Be(30);
        }

        [Fact]
        public void SubtractShouldReturnSuccess()
        {
            var dinheiro1 = new Dinheiro(20);
            var dinheiro2 = new Dinheiro(10);
            var soma = dinheiro1 - dinheiro2;

            soma.Valor.Should().Be(10);
        }

        [Fact]
        public void SubtractShouldReturnError()
        {
            var dinheiro1 = new Dinheiro(10);
            var dinheiro2 = new Dinheiro(20);

            Action action = () => CalcularDiferenca(dinheiro1, dinheiro2);
            action.Should().Throw<InvalidOperationException>();
        }

        private void CalcularDiferenca(Dinheiro dinheiro1, Dinheiro dinheiro2)
        {
            var dinheiro = dinheiro1 - dinheiro2;
        }

        [Fact]
        public void SameInstanceShouldReturnSuccess()
        {
            var dinheiro1 = new Dinheiro(10);
            var dinheiro2 = new Dinheiro(10);


            dinheiro1.Should().Be(dinheiro2);
            dinheiro1.GetHashCode().Should().Be(dinheiro2.GetHashCode());
        }

        // Theory: teste com uso de parâmetros
        [Theory]
        [InlineData(-10)]
        public void ShouldNotInstanciateNegativeValue(decimal valor)
        {
            Action action = () => new Dinheiro(valor);
            action.Should().Throw<InvalidOperationException>();
        }
    }
}
