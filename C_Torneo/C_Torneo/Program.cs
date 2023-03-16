using System.IO;
using System.Globalization;
using B_Torneo.Classes;
using System.Security.Cryptography;

namespace C_Torneo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Jugador> l_jugadores1 = Cargar_Jugadores("C:\\Prog\\UPB\\Objetos\\5-Torneo\\C_Torneo\\C_Torneo\\Files\\jugador1.txt");
                List<Jugador> l_jugadores2 = Cargar_Jugadores("C:\\Prog\\UPB\\Objetos\\5-Torneo\\C_Torneo\\C_Torneo\\Files\\jugador2.txt");
                List<Torneo> l_torneos = Cargar_Torneos("C:\\Prog\\UPB\\Objetos\\5-Torneo\\C_Torneo\\C_Torneo\\Files\\torneos.txt");
                List<Tecnico> l_tecnicos = Cargar_Tecnico("C:\\Prog\\UPB\\Objetos\\5-Torneo\\C_Torneo\\C_Torneo\\Files\\tecnico1.txt", l_torneos);

                Console.WriteLine("Jugadores: \n");

                Console.WriteLine("\n1: \n");

                if (l_jugadores1.Count == 0) Console.WriteLine("Error en la carga de los jugadores");
                else foreach (Jugador jugador in l_jugadores1) Console.WriteLine(jugador.Nombre);

                Console.WriteLine("\n2: \n");

                if (l_jugadores2.Count == 0) Console.WriteLine("Error en la carga de los jugadores");
                else foreach (Jugador jugador in l_jugadores2) Console.WriteLine(jugador.Nombre);

                Console.WriteLine("\nTorneos: \n");

                if (l_torneos.Count == 0) Console.WriteLine("Error en la carga de los torneos");
                else foreach (Torneo torneo in l_torneos) Console.WriteLine(torneo.Nombre);

                Console.WriteLine("\nTécnicos: \n");

                if (l_tecnicos.Count == 0) Console.WriteLine("Error en la carga de los técnicos");
                else foreach (Tecnico tecnico in l_tecnicos) Console.WriteLine(tecnico.Nombre);

                Equipo colombia = new Equipo("Colombia", Cargar_Jugadores("C:\\Prog\\UPB\\Objetos\\5-Torneo\\C_Torneo\\C_Torneo\\Files\\jugador1.txt"), l_tecnicos[0]);
                Equipo inglaterra = new Equipo("Inglaterra", Cargar_Jugadores("C:\\Prog\\UPB\\Objetos\\5-Torneo\\C_Torneo\\C_Torneo\\Files\\jugador2.txt"), l_tecnicos[1]);
                Escenario wembley = new Escenario("Wembley", "Inglarerra", 80000);
                Enfrentamiento Fecha1 = new Enfrentamiento(colombia, inglaterra, DateTime.Now.AddDays(1), wembley);

                Console.WriteLine(Fecha1.Local.Nombre + " vs " + Fecha1.Visitante.Nombre);
                Fecha1.Anotar_Gol_Local();
                Fecha1.Anotar_Gol_Local();
                Fecha1.Anotar_Gol_Visitante();
                Console.WriteLine(Fecha1.Goles_local + " vs " + Fecha1.Goles_visitante);
                Fecha1.Finalizar_partido();
                Fecha1.Elegir_Destacado();
                Console.WriteLine("El jugador destacado fue: " + Fecha1.Mvp.Nombre);
            }
            catch (Exception error) { Console.WriteLine("Ocurrió un problema en el main\n" + error); }
        }

        private static List<Jugador> Cargar_Jugadores(string ruta_archivo)
        {
            List<Jugador> l_jugadores = new List<Jugador>();
            try
            {
                StreamReader archivo_jugadores = new StreamReader(ruta_archivo);
                string linea = archivo_jugadores.ReadLine();
                string[] arreglo_jugadores;
                DateTime aux_fecha;
                Jugador.l_posiciones aux_posicion;
                ushort aux_numero;

                while (linea != null) 
                {
                    arreglo_jugadores = linea.Split('|');
                    
                    if (DateTime.TryParseExact(arreglo_jugadores[1], format:"MM/dd/yyyy", null, DateTimeStyles.None, out aux_fecha) && 
                        Enum.TryParse(arreglo_jugadores[2], out aux_posicion) &&
                        ushort.TryParse(arreglo_jugadores[4], out aux_numero) &&
                        arreglo_jugadores.Length == 5)
                    {
                        l_jugadores.Add(new Jugador(arreglo_jugadores[0], aux_fecha, arreglo_jugadores[3], aux_numero, aux_posicion));
                    }
                    
                    linea = archivo_jugadores.ReadLine();
                }

                archivo_jugadores.Close();
                return l_jugadores;
            }
            catch (FileNotFoundException error) { return l_jugadores; }
            catch (Exception error) { return l_jugadores; }
        }

        private static List<Torneo> Cargar_Torneos(string ruta_archivo)
        {
            List<Torneo> l_torneos = new List<Torneo>();
            try
            {
                StreamReader archivo_torneo = new StreamReader(ruta_archivo);
                string linea = archivo_torneo.ReadLine();
                while (linea != null) 
                {
                    l_torneos.Add(new Torneo(linea));
                    linea = archivo_torneo.ReadLine();
                }

                archivo_torneo.Close();
                return l_torneos;
            }
            catch(Exception error) { return l_torneos; }
            
        }

        private static List<Tecnico> Cargar_Tecnico(string ruta_archivo, List<Torneo> l_torneos) 
        {
            List<Tecnico> l_tecnico = new List<Tecnico>();
            try
            {
                StreamReader archivo_tecnico = new StreamReader(ruta_archivo);
                List<Torneo> torneos_ganados = new List<Torneo>();
                List<string> cursos_completados = new List<string>();
                string linea = archivo_tecnico.ReadLine();
                string[] arreglo_tecnico;
                string[] arreglo_cursos;
                DateTime aux_fecha;
                Random random = new Random();
                byte cantidad_torneos;
                byte[] indices_torneos;

                while (linea != null) 
                {
                    arreglo_tecnico = linea.Split("|");
                    arreglo_cursos = arreglo_tecnico[2].Split(';');

                    for (byte i = 0; i < arreglo_cursos.Length; i++) cursos_completados.Add(arreglo_cursos[i]);
                    
                    cantidad_torneos = (byte) random.Next(0, l_torneos.Count);
                    indices_torneos = new byte[cantidad_torneos];
                    for (byte i = 0; i < cantidad_torneos; i++) indices_torneos[i] = (byte)random.Next(0, l_torneos.Count - 1);
                    for (byte i = 0; i < cantidad_torneos; i++) torneos_ganados.Add(l_torneos[indices_torneos[i]]);

                    if (DateTime.TryParseExact(arreglo_tecnico[1], format: "dd/MM/yyyy", null, DateTimeStyles.None, out aux_fecha))
                        l_tecnico.Add(new Tecnico(arreglo_tecnico[0], aux_fecha, torneos_ganados, cursos_completados));
                    
                    linea = archivo_tecnico.ReadLine();
                }

                archivo_tecnico.Close();
                return l_tecnico;
            }
            catch (Exception error) { return l_tecnico; }
        }
    }
}