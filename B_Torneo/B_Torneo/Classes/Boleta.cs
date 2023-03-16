using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace B_Torneo.Classes
{
    public class Boleta
    {
        public static ushort numero_boleta = 1;

        private ushort numero;
        public Boleta()
        {
            numero = numero_boleta;
            numero_boleta++;
        }
    }
}
