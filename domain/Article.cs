using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class Article
    {
        public int Id { get; set; }
        [DisplayName("Codigo")]
        public string Code { get; set; }
        [DisplayName("Nombre")]
        public string Name { get; set; }
        [DisplayName("Descrpción")]
        public string Description { get; set; }
        [DisplayName("Marca")]
        public Brand Brand { get; set; }
        [DisplayName("Categoria")]
        public Category Category { get; set; }
        [DisplayName("Foto")]
        public string UrlPicture { get; set; }
        [DisplayName("Precio")]
        public decimal Price { get; set; }

    }
}
