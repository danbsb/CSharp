using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basicCRUD.model
{
    public class TablePessoas
    {
        public string id { get; set; }
        public string nome { get; set; }
        public DateTime idade { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
    }
}
