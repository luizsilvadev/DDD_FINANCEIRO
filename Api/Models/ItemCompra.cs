using System;
using System.Collections.Generic;

namespace WebFinanceiroApi.Models
{
    public partial class ItemCompra
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public DateTime DataCompra { get; set; }
        public int IdCompra { get; set; }
        public bool? Comprado { get; set; }

        public virtual Compra IdCompraNavigation { get; set; }
    }
}
