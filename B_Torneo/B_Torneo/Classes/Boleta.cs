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
        private ushort numero;
        
        public Boleta(ushort numero)
        {
            Numero = numero;
        }

        public ushort Numero { get => numero; private set => numero = value; }
    }
}
