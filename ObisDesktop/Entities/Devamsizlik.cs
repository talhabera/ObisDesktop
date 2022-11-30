using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObisDesktop.Entities
{
    public class Devamsizlik
    {
        public int Id { get; set; }
        public int OgrenciId { get; set; }
        public int DersId { get; set; }
        public int Miktar { get; set; }
    }
}
