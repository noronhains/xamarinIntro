using System;
using SQLite;
namespace AppGasolina
{
    class Abastecimento
    {
        [PrimaryKey, NotNull]
        public int Id { get; set; }
        [MaxLength(10), NotNull]
        public string Data { get; set; }
        [NotNull]
        public double Preco { get; set; }
        [NotNull]
        public double Valor { get; set; }
        [NotNull]
        public double Litro { get; set; }
        [NotNull]
        public double Quilometragem { get; set; }
        [NotNull]
        public string Posto { get; set; }

        public override string ToString()
        {
            return string.Format("{0}- Data: {1} Posto: {2} Valor: {3}", Id, Data, Posto, Valor);
        }

    }
}
