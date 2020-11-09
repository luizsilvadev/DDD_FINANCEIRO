using System;
using System.Collections.Generic;

namespace WebFinanceiroApi.Models
{
    public partial class Compra
    {
        public Compra()
        {
            ItemCompra = new HashSet<ItemCompra>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public int IdCategoria { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual ICollection<ItemCompra> ItemCompra { get; set; }
    }
}
