using System;
using System.Collections.Generic;

namespace WebFinanceiroApi.Models
{
    public partial class Sugestao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string DescricaoSugestao { get; set; }
        public string EmailUsuario { get; set; }
    }
}
