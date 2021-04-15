using System;
using System.Collections.Generic;
using System.Text;

namespace BuscaCEP.Models
{
    class CEPModel
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string ddd { get; set; }
    }
}
