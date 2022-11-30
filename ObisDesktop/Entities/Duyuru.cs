using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObisDesktop.Entities
{
    public class Duyuru
    {
        public int Id { get; set; }
        public int BolumId { get; set; }
        public int DersId { get; set; }
        public DateTime Tarih { get; set; }
        public string Mesaj { get; set; }
    }
}
