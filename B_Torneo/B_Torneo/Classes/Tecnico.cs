using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Torneo.Classes
{
    public class Tecnico
    {
        private string nombre;
        private List<Torneo> l_torneos;
        private List<string> l_cursos;

        public Tecnico(string nombre, List<Torneo> l_torneos, List<string> l_cursos)
        {
            Nombre = nombre;
            this.l_torneos = l_torneos;
            L_cursos = l_cursos;
        }

        public string Nombre
        {
            get => nombre.ToUpper();
            set
            {
                if (!String.IsNullOrEmpty(value) || !String.IsNullOrWhiteSpace(value)) nombre = value.ToUpper();
                else throw new Exception("Debe ingresar un nombre válido");
            }
        }

        public List<string> L_cursos { get => l_cursos; set => l_cursos = value; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
