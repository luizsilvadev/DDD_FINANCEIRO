using System;
using System.Collections.Generic;

namespace WebFinanceiroApi.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Compra = new HashSet<Compra>();
            Despesa = new HashSet<Despesa>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdSistema { get; set; }

        public virtual SistemaFinanceiro IdSistemaNavigation { get; set; }
        public virtual ICollection<Compra> Compra { get; set; }
        public virtual ICollection<Despesa> Despesa { get; set; }
    }
}
