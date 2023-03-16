﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Torneo.Classes
{
    public class Enfrentamiento
    {
        private Equipo local;
        private Equipo visitante;
        private Jugador mvp;
        private DateTime fecha_hora;
        private byte goles_local;
        private byte goles_visitante;
        private Escenario escenario;
        private bool finalizado;

        public Enfrentamiento(Equipo local, Equipo visitante, DateTime fecha_hora, Escenario escenario)
        {
            this.local = local;
            Visitante = visitante;
            Fecha_hora = fecha_hora;
            this.escenario = escenario;
            finalizado = false;

            goles_local = 0;
            goles_visitante = 0;
        }

        public Enfrentamiento(Equipo local, Equipo visitante)
        {
            this.local = local;
            Visitante = visitante;
        }

        public DateTime Fecha_hora
        {
            get => fecha_hora;
            set
            {
                if (value >= Torneo.f_inicio && value <= Torneo.f_final) fecha_hora = value;
                else throw new Exception("La fecha ingresada está por fuera de las fechas permitidas en el torneo");
            }
        }

        public byte Goles_local { get => goles_local; }
        public byte Goles_visitante { get => goles_visitante; }
        public Jugador Mvp { get => mvp; }
        public bool Finalizado { get => finalizado; }
        public Equipo Local { get => local; }

        public Equipo Visitante
        {
            get => visitante;

            private set
            {
                if (value == local) throw new Exception("Un equipo no se puede enfentrar a sí mismo");
                else visitante = value;
            }
        }

        public void Anotar_Gol_Local()
        {
            try { goles_local++; }
            catch (Exception error) { throw new Exception("Ocurrió un error sumando un gol al local\n" + error); }
        }

        public void Anotar_Gol_Visitante()
        {
            try { goles_visitante++; }
            catch (Exception error) { throw new Exception("Ocurrió un error sumando un gol al visitante\n" + error); }
        }

        public void Anular_Gol_Local()
        {
            try 
            {
                if (goles_local > 0) goles_local--;
                else throw new Exception("No se puede anular goles si no se han anotado");
            }
            catch (Exception error) { throw new Exception("Ocurrió un error quitando un gol al local\n" + error); }
        }

        public void Anular_Gol_Visitante()
        {
            try
            {
                if (goles_visitante > 0) goles_visitante--;
                else throw new Exception("No se puede anular goles si no se han anotado");
            }
            catch (Exception error) { throw new Exception("Ocurrió un error quitando un gol al visitante\n" + error); }
        }

        public void Elegir_Destacado()
        {
            try
            {
                Random random = new Random();
                if (finalizado)
                {
                    if (goles_visitante > goles_local) mvp = visitante.L_jugadores[random.Next(0, Torneo.nro_max_jugadores)];
                    else if (goles_visitante < goles_local) mvp = local.L_jugadores[random.Next(0, Torneo.nro_max_jugadores)];
                    else
                    {
                        if (random.Next(0, 2) == 0) mvp = visitante.L_jugadores[random.Next(0, Torneo.nro_max_jugadores)];
                        else mvp = local.L_jugadores[random.Next(0, Torneo.nro_max_jugadores)];
                    }
                }
                else throw new Exception("Hasta que no finalice el partido no se puede elegir destacado");
            }
            catch (Exception error) { throw new Exception("Ocurrió un error eligiendo al jugador destacado\n" + error); }
        }

        public void Finalizar_partido()
        {
            try { if (!finalizado) finalizado = true; }
            catch (Exception error) { throw new Exception("Ocurrio un error finalizando el partido\n" + error); }
        }
        public override string ToString()
        {
            return Local.Nombre + " vs. " + Visitante.Nombre;
        }
    }
}
