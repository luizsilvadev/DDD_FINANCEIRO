using System;
using System.Collections.Generic;

namespace WebFinanceiroApi.Models
{
    public partial class SistemaFinanceiro
    {
        public SistemaFinanceiro()
        {
            Categoria = new HashSet<Categoria>();
            UsuarioSistemaFinanceiro = new HashSet<UsuarioSistemaFinanceiro>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int DiaFechamento { get; set; }
        public bool GerarCopiaDespesa { get; set; }
        public int MesCopia { get; set; }
        public int AnoCopia { get; set; }

        public virtual ICollection<Categoria> Categoria { get; set; }
        public virtual ICollection<UsuarioSistemaFinanceiro> UsuarioSistemaFinanceiro { get; set; }
    }
}
