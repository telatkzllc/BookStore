using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Book
    {
        //Değişkentürü,isim,get,set eklenerek tanımalanacak
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Page { get; set; }
        public int WriterId { get; set; }
        public Writer Writer { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }



    }
}
