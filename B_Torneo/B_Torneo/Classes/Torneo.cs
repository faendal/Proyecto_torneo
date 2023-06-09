﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Torneo.Classes
{
    public class Torneo
    {
        public readonly static byte nro_max_jugadores = 20;
        public readonly static DateTime f_inicio = new DateTime(2023, 3, 1);
        public readonly static DateTime f_final = new DateTime(2023, 12, 1);

        private string nombre;
        private List<Enfrentamiento> l_enfrentamientos;

        public Torneo(string nombre)
        {
            Nombre = nombre;
            L_enfrentamientos = new List<Enfrentamiento>();
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

        public List<Enfrentamiento> L_enfrentamientos { get => l_enfrentamientos; set => l_enfrentamientos = value; }

        public override string ToString()
        {
            return Nombre;
        }

    }
}
