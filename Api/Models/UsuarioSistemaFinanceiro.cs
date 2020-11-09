using System;
using System.Collections.Generic;

namespace WebFinanceiroApi.Models
{
    public partial class UsuarioSistemaFinanceiro
    {
        public int Id { get; set; }
        public string EmailUsuario { get; set; }
        public bool Administrador { get; set; }
        public bool SistemaAtual { get; set; }
        public int IdSistema { get; set; }

        public virtual SistemaFinanceiro IdSistemaNavigation { get; set; }
    }
}
