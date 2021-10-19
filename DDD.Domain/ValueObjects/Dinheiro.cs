using DDD.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.ValueObjects
{
    public sealed class Dinheiro : ValueObject<Dinheiro>
    {
        public decimal Valor { get; set; }

        public Dinheiro(decimal valor)
        {
            if (valor >= 0)
                Valor = valor;
            else
                throw new InvalidOperationException("Erro na atribuição do valor de dinheiro");
        }

        public static Dinheiro operator +(Dinheiro valor1, Dinheiro valor2)
        {
            var soma = new Dinheiro(valor1.Valor + valor2.Valor);
            return soma;
        }

        public static Dinheiro operator -(Dinheiro valor1, Dinheiro valor2)
        {
            if (valor1.Valor < valor2.Valor)
                throw new InvalidOperationException("Operação inválida");
            else
                return new Dinheiro(valor1.Valor - valor2.Valor);
        }

        protected override bool EqualsCore(Dinheiro other)
        {
            return Valor == other.Valor;
        }

        protected override decimal GetHashCodeCore()
        {
            decimal hashCode = Valor.GetHashCode();
            return hashCode;
        }
    }
}
