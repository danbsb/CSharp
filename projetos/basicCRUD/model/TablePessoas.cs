using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Criado por: Daniel Fontinele da Silva
Data: 22/05/2023
GitHUB: github.com/danbsb
E-mail: daniel.fontinele@gmail.com
*/

namespace basicCRUD.model
{
    public class TablePessoas
    {
        public string id { get; set; }
        public string nome { get; set; }
        public DateTime idade { get; set; }
        public string cpf { get; set; }
        //criado novoCpf para possibilitar o update do CPF
        //vez que o parametrosUpdate = new { cpf = resCPF, cpf = CPF }
        //não permite 2 parametros iguals como acima
        public string novoCpf { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
    }
}
