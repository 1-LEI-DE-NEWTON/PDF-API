using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_API.Domain.Entities
{
    public class PDF
    {
        //Criando a classe para a API receber os arquivos PDFs
        public string FileName { get; set; } 
        public IFormFile Pdf { get; set; }
        public int Id { get; set; }
        public int SetorId { get; set; }
        public int LotacaoId { get; set; }
    }

    
}
