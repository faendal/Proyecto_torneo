using B_Torneo.Classes;
using System.Globalization;

namespace F_Torneo
{
    public partial class F_principal : Form
    {

        private List<Jugador> l_jugadores;
        private List<Tecnico> l_tecnicos;
        private List<Equipo> l_equipos;
        private static List<Torneo> l_torneos;
        private List<Escenario> l_escenarios;
        private List<byte> cantidad_boletas_vender;

        public F_principal()
        {
            try
            {
                InitializeComponent();
                cantidad_boletas_vender = new List<byte> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                cb_cantidad_boletas.DataSource = cantidad_boletas_vender;
                l_jugadores = new List<Jugador>();
                l_tecnicos = new List<Tecnico>();
                l_equipos = new List<Equipo>();
                l_torneos = new List<Torneo>();
                l_escenarios = new List<Escenario>
                {
                    new Escenario("Estadio Atanasio Girardot", "Medell�n", 42000),
                    new Escenario("Estadio el Camp�n", "Bogot�", 45000)
                };
                cb_Escenario.DataSource = l_escenarios;
                dt_Fecha.CustomFormat = "dd/MM/yyyy hh:mm:ss";
                dt_Fecha.Format = DateTimePickerFormat.Custom;
                b_gol_local.Enabled = false;
                b_gol_visitante.Enabled = false;
                b_anular_local.Enabled = false;
                b_anular_visitante.Enabled = false;
                b_seleccionar_jugador_destacado.Enabled = false;
                b_finalizar_enfrentamiento.Enabled = false;
            }
            catch (Exception error) { throw new Exception("Ocurri� un error en el constructor del formulario\n" + error); }
        }

        // M�todo para cargar jugadores desde un archivo dado
        private static List<Jugador> Cargar_Jugadores(string ruta_archivo)
        {
            // Lista a retornar
            List<Jugador> l_jugadores = new List<Jugador>();
            try
            {
                StreamReader archivo_jugadores = new StreamReader(ruta_archivo);
                string linea = archivo_jugadores.ReadLine();
                string[] arreglo_jugadores;

                // Auxiliares para guardar variables que ir�n como par�metros de los objetos
                DateTime aux_fecha;
                Jugador.l_posiciones aux_posicion;
                ushort aux_numero;

                // Recorrer el archivo
                while (linea != null)
                {
                    arreglo_jugadores = linea.Split('|');

                    // Condiciones necesarias. TryParseExact permite convertir texto en fecha con el formato deseado
                    if (DateTime.TryParseExact(arreglo_jugadores[1], format: "MM/dd/yyyy", null, DateTimeStyles.None, out aux_fecha) &&
                        Enum.TryParse(arreglo_jugadores[2], out aux_posicion) &&
                        ushort.TryParse(arreglo_jugadores[4], out aux_numero) &&
                        arreglo_jugadores.Length == 5)
                    {
                        // Creaci�n de objetos jugador
                        l_jugadores.Add(new Jugador(arreglo_jugadores[0], aux_fecha, arreglo_jugadores[3], aux_numero, aux_posicion));
                    }

                    linea = archivo_jugadores.ReadLine();
                }

                archivo_jugadores.Close();
                return l_jugadores;
            }
            catch (Exception error) { return l_jugadores; }
        }

        // M�todo para cargar la lista de torneos de un archivo dado
        private static List<Torneo> Cargar_Torneos(string ruta_archivo)
        {
            // Lista a retornar
            List<Torneo> l_torneos = new List<Torneo>();
            try
            {
                StreamReader archivo_torneo = new StreamReader(ruta_archivo);
                string linea = archivo_torneo.ReadLine();
                // Recorrido del archivo
                while (linea != null)
                {
                    // Creaci�n de objetos torneo
                    l_torneos.Add(new Torneo(linea));
                    linea = archivo_torneo.ReadLine();
                }

                archivo_torneo.Close();
                return l_torneos;
            }
            catch (Exception error) { return l_torneos; }

        }

        // M�todo para cargar los t�cnicos desde un archivo dado
        private static List<Tecnico> Cargar_Tecnico(string ruta_archivo)
        {
            List<Tecnico> l_tecnico = new List<Tecnico>();
            try
            {
                // Listas y auxiliares que ir�n como par�metros de los objetos t�cnico
                StreamReader archivo_tecnico = new StreamReader(ruta_archivo);
                List<Torneo> torneos_ganados = new List<Torneo>();
                List<string> cursos_completados = new List<string>();
                string linea = archivo_tecnico.ReadLine();
                string[] arreglo_tecnico;
                byte cantidad_torneos;
                byte[] indices_torneos;

                // Objeto random para otorgarle al t�cnico una cantidad y tipos de torneos aleatorios
                Random random = new Random();

                // Recorrido del archivo
                while (linea != null)
                {
                    arreglo_tecnico = linea.Split("|");
                    cursos_completados = arreglo_tecnico[1].Split(';').ToList<string>();
                    // Cantidad aleatoria de torneos
                    cantidad_torneos = (byte)random.Next(0, l_torneos.Count);
                    indices_torneos = new byte[cantidad_torneos];

                    // Tipos de torneo aleatorio
                    for (byte i = 0; i < cantidad_torneos; i++) indices_torneos[i] = (byte)random.Next(0, l_torneos.Count - 1);
                    // A�adir torneos a la lista de torneos ganados
                    for (byte i = 0; i < cantidad_torneos; i++) torneos_ganados.Add(l_torneos[indices_torneos[i]]);

                    // Creaci�n de objeto t�cnico
                    l_tecnico.Add(new Tecnico(arreglo_tecnico[0], torneos_ganados, cursos_completados));

                    linea = archivo_tecnico.ReadLine();
                }

                archivo_tecnico.Close();
                return l_tecnico;
            }
            catch (Exception error) { return l_tecnico; }
        }

        // M�todo para obtener la ruta de un archivo
        private static string Obtener_Ruta()
        {
            try
            {
                // Objeto ventana
                OpenFileDialog ventana_archivo;
                do
                {
                    // Solicitud de archivo a trav�s de ventana hasta que la petici�n sea exitosa
                    ventana_archivo = new OpenFileDialog();
                    ventana_archivo.Filter = "TXT | *.txt";
                } while (ventana_archivo.ShowDialog() != DialogResult.OK);

                // Retorno de la ruta del archivo
                return ventana_archivo.FileName;
            }
            catch (Exception error) { throw new Exception("Ocurri� un error obteniendo la ruta\n" + error); }
        }

        // M�todo para comparar jugadores
        private bool Contenido_en_lista(List<Jugador> lista_jugadores, Jugador jugador)
        {
            try
            {
                bool contenido = false;
                // Recorrer la lista de jugadores
                foreach (Jugador jugador_verificar in lista_jugadores)
                {
                    // Verificar que los atributos sean iguales
                    if (jugador_verificar.Nombre == jugador.Nombre &&
                       jugador_verificar.Nacionalidad == jugador.Nacionalidad &&
                       jugador_verificar.F_nacimiento == jugador.F_nacimiento &&
                       jugador_verificar.Numero == jugador.Numero) contenido = true;
                    else contenido = false;
                }
                return contenido;
            }
            catch (Exception error) { throw new Exception("Ocurri� un error verificando la existencia de un objeto en la lista"); }
        }

        // M�todo para controlar jugadores repetidos
        private bool Verificar_Repetidos()
        {
            try
            {
                List<Jugador> jugadores_verificar = lb_Jugadores.Items.Cast<Jugador>().ToList();
                List<Equipo> equipos_verificar = lb_Equipos.Items.Cast<Equipo>().ToList();
                if (equipos_verificar.Count > 0)
                {
                    // Se recorren los equipos previamente registrados
                    foreach (Equipo equipo in equipos_verificar)
                    {
                        // Vemos si un jugador est� contenido en un equipo ya inscrito
                        foreach (Jugador posible_repetido in jugadores_verificar)
                        {
                            if (Contenido_en_lista(equipo.L_jugadores, posible_repetido)) return true;
                        }
                    }
                }
                else return false;
                return false;
            }
            catch (Exception error) { throw new Exception("Ocurri� un error verificando que no haya jugadores repetidos"); }
        }

        // M�todo para controlar nombres de equipo repetidos
        private bool Verificar_Nombres()
        {
            try
            {
                List<Equipo> l_equipos = lb_Equipos.Items.Cast<Equipo>().ToList();
                if(l_equipos.Count > 0)
                {
                    List<string> l_nombres = new List<string>();
                    foreach (Equipo equipo in l_equipos) l_nombres.Add(equipo.Nombre);
                    foreach (string nombre in l_nombres) if (nombre == tb_Equipo.Text.ToUpper()) return true;
                }
                return false;
            }
            catch (Exception error) { throw new Exception("Ocurri� un error controlando los nombres de equipo repetido"); }
        }

        // M�todo del bot�n cargar torneos
        private void b_cargar_torneos_Click(object sender, EventArgs e)
        {
            try
            {
                // Carga de los torneos desde archivo
                MessageBox.Show("Seleccione el archivo de los torneos");
                l_torneos = Cargar_Torneos(Obtener_Ruta());
                if (l_torneos.Count > 0)
                {
                    // Para cada torneo, se inicializa la lista de enfrentamientos con uno "ficticio" por defecto.
                    foreach (Torneo torneo in l_torneos)
                    {
                        torneo.L_enfrentamientos = new List<Enfrentamiento> { new Enfrentamiento(new Equipo("Local"), new Equipo("Visitante")) };
                    }
                    // Se inicializa el combobox con el valor por defecto
                    cb_torneos.DataSource = l_torneos;
                    cb_torneos.SelectedIndex = 0;
                }
            }
            catch (Exception error) { throw new Exception("Ocurri� un error cargando los torneos\n" + error); }
        }

        // M�todo del bot�n para cargar jugadores
        private void b_Cargar_Jugadores_Click(object sender, EventArgs e)
        {
            try
            {
                l_jugadores = Cargar_Jugadores(Obtener_Ruta());
                lb_Jugadores.DataSource = l_jugadores;
            }
            catch (Exception error) { throw new Exception("Ocurri� un error cargando los jugadores\n" + error); }
        }

        // M�todo del bot�n para cargar los t�cnicos
        private void b_Cargar_tecnico_Click(object sender, EventArgs e)
        {
            try
            {
                if (l_torneos.Count > 0)
                {
                    MessageBox.Show("Seleccione el archivo de los t�cnicos");
                    l_tecnicos = Cargar_Tecnico(Obtener_Ruta());
                    lb_Tecnicos.DataSource = l_tecnicos;
                }
                else MessageBox.Show("Seleccione primero un archivo v�lido de torneos");

                if (l_tecnicos.Count > 0) b_Cargar_tecnico.Enabled = false;
            }
            catch (Exception error) { throw new Exception("Ocurri� un error cargando los t�cnicos\n" + error); }
        }

        // M�todo del bot�n para crear un equipo teniendo nombre, jugadores y t�cnicos cargados
        private void b_Crear_Equipo_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificaci�n de la integridad de los requisitos para crear un equipo
                if (lb_Jugadores.Items.Cast<Jugador>().ToList().Count() > 0 &&
                    lb_Tecnicos.SelectedItems.Count == 1 &&
                    tb_Equipo.Text.Length > 0 &&
                    !string.IsNullOrEmpty(tb_Equipo.Text) &&
                    !string.IsNullOrWhiteSpace(tb_Equipo.Text) &&
                    !Verificar_Repetidos() &&
                    !Verificar_Nombres())
                {
                    // Creaci�n del equipo
                    l_equipos.Add(new Equipo(tb_Equipo.Text,
                                             lb_Jugadores.Items.Cast<Jugador>().ToList(),
                                             (Tecnico)lb_Tecnicos.SelectedItem));

                    lb_Equipos.DataSource = null;
                    lb_Equipos.DataSource = l_equipos;

                    tb_Equipo.Clear();
                    lb_Jugadores.DataSource = null;
                    l_tecnicos.RemoveAt(lb_Tecnicos.SelectedIndex);
                    lb_Tecnicos.DataSource = null;
                    lb_Tecnicos.DataSource = l_tecnicos;
                }
                else
                {
                    MessageBox.Show("No se cumplen los requisitos para inscribir el equipo.\n" +
                                     "Valide que la lista de jugadores se haya cargado y no tenga jugadores previamente inscritos" +
                                     ", que haya seleccionado un t�cnico y que el equipo tenga un nombre, y que este no est� repetido");
                    lb_Jugadores.DataSource = null;
                }


            }
            catch (Exception error) { throw new Exception("Ocurri� un error creando el equipo\n" + error); }
        }

        // M�todo del bot�n para crear un enfrentamiento entre dos equipos en una fecha y un con un escenario
        private void b_crear_enfrentamiento_Click(object sender, EventArgs e)
        {
            try
            {
                if (cb_torneos.SelectedIndex > 0)
                {
                    List<Equipo> l_equipos_seleccionados = new List<Equipo>();
                    Enfrentamiento partido;

                    // Verificaci�n de que se encuentren dos equipos seleccionados
                    if (lb_Equipos.SelectedItems.Count != 2) MessageBox.Show("Debe seleccionar dos equipos");
                    else if (dt_Fecha.Value <= DateTime.Now.AddDays(1)) MessageBox.Show("La fecha del partido debe ser por lo menos un d�a despu�s de la fecha actual");
                    else
                    {
                        l_equipos_seleccionados = lb_Equipos.SelectedItems.Cast<Equipo>().ToList();

                        // Creaci�n del enfrentamiento y adici�n a la lista de enfrentamientos
                        partido = new Enfrentamiento(l_equipos_seleccionados[0],
                                                     l_equipos_seleccionados[1],
                                                     dt_Fecha.Value,
                                                     (Escenario)cb_Escenario.SelectedItem,
                                                     (Torneo)cb_torneos.SelectedItem);
                        ((Torneo)cb_torneos.SelectedItem).L_enfrentamientos.Add(partido);

                        cb_enfrentamientos.DataSource = null;
                        cb_enfrentamientos.DataSource = ((Torneo)cb_torneos.SelectedItem).L_enfrentamientos;
                        cb_enfrentamientos.SelectedIndex = 0;
                    }
                }
                else MessageBox.Show("Seleccione un torneo v�lido");
            }
            catch (Exception error) { throw new Exception("Ocurri� un error creando el enfrentamiento\n" + error); }
        }

        // M�todo del bot�n para anotar un gol al local
        private void b_gol_local_Click(object sender, EventArgs e)
        {
            try
            {
                ((Enfrentamiento)cb_enfrentamientos.SelectedItem).Anotar_Gol_Local();
                tb_marcador_local.Text = ((Enfrentamiento)cb_enfrentamientos.SelectedItem).Goles_local.ToString();
            }
            catch (Exception error) { throw new Exception("Ocurri� un error anotando gol local\n" + error); }
        }

        // M�todo del bot�n para anular un gol al local
        private void b_anular_local_Click(object sender, EventArgs e)
        {
            try
            {
                ((Enfrentamiento)cb_enfrentamientos.SelectedItem).Anular_Gol_Local();
                tb_marcador_local.Text = ((Enfrentamiento)cb_enfrentamientos.SelectedItem).Goles_local.ToString();
            }
            catch (Exception error) { throw new Exception("Ocurri� un error anulando gol local\n" + error); }
        }

        // M�todo del bot�n para anotar un gol al visitante
        private void b_gol_visitante_Click(object sender, EventArgs e)
        {
            try
            {
                ((Enfrentamiento)cb_enfrentamientos.SelectedItem).Anotar_Gol_Visitante();
                tb_marcador_visitante.Text = ((Enfrentamiento)cb_enfrentamientos.SelectedItem).Goles_visitante.ToString();
            }
            catch (Exception error) { throw new Exception("Ocurri� un error anotando gol visitante\n" + error); }
        }

        // M�todo del bot�n para anular un gol al visitante
        private void b_anular_visitante_Click(object sender, EventArgs e)
        {
            try
            {
                ((Enfrentamiento)cb_enfrentamientos.SelectedItem).Anular_Gol_Visitante();
                tb_marcador_visitante.Text = ((Enfrentamiento)cb_enfrentamientos.SelectedItem).Goles_visitante.ToString();
            }
            catch (Exception error) { throw new Exception("Ocurri� un error anulando gol visitante\n" + error); }
        }

        // M�todo del bot�n para finalizar el partido
        private void b_finalizar_enfrentamiento_Click(object sender, EventArgs e)
        {
            try
            {
                ((Enfrentamiento)cb_enfrentamientos.SelectedItem).Finalizar_partido();

                // Si el partido termina, el bot�n para finalizar se desactiva
                if (((Enfrentamiento)cb_enfrentamientos.SelectedItem).Finalizado == true)
                {
                    b_gol_local.Enabled = false;
                    b_gol_visitante.Enabled = false;
                    b_anular_local.Enabled = false;
                    b_anular_visitante.Enabled = false;
                    b_finalizar_enfrentamiento.Enabled = false;
                }
            }
            catch (Exception error) { throw new Exception("Ocurri� un error finalizando el partido\n" + error); }
        }

        // M�todo del bot�n para escoger el jugador destacado
        private void b_seleccionar_jugador_destacado_Click(object sender, EventArgs e)
        {
            ((Enfrentamiento)cb_enfrentamientos.SelectedItem).Elegir_Destacado();
            tb_mvp.Text = ((Enfrentamiento)cb_enfrentamientos.SelectedItem).Mvp.ToString();

            // Si ya se eligi� un jugador destacado, el bot�n se desactiva
            if (!string.IsNullOrEmpty(((Enfrentamiento)cb_enfrentamientos.SelectedItem).Mvp.Nombre) ||
                !string.IsNullOrWhiteSpace(((Enfrentamiento)cb_enfrentamientos.SelectedItem).Mvp.Nombre))
            { b_seleccionar_jugador_destacado.Enabled = false; }
        }

        // M�todo que se emplea cuando se hace cambio de objeto seleccionado en la caja de enfrentamientos
        private void cb_enfrentamientos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cb_enfrentamientos.SelectedIndex > 0)
                {
                    Enfrentamiento partido = (Enfrentamiento)cb_enfrentamientos.SelectedItem;
                    if (partido.Finalizado)
                    {
                        b_finalizar_enfrentamiento.Enabled = false;
                        b_gol_local.Enabled = false;
                        b_gol_visitante.Enabled = false;
                        b_anular_local.Enabled = false;
                        b_anular_visitante.Enabled = false;
                        if (partido.Mvp != null) b_seleccionar_jugador_destacado.Enabled = false;
                        else b_seleccionar_jugador_destacado.Enabled = true;
                    }
                    else
                    {
                        b_gol_local.Enabled = true;
                        b_gol_visitante.Enabled = true;
                        b_anular_local.Enabled = true;
                        b_anular_visitante.Enabled = true;
                        b_finalizar_enfrentamiento.Enabled = true;
                        b_seleccionar_jugador_destacado.Enabled = true;
                        tb_enfrentamiento_boleteria.Text = partido.ToString() + " en el estadio " + partido.Escenario.ToString();
                        cb_taquillas.DataSource = partido.Escenario.L_taquillas;
                    }
                    tb_marcador_local.Text = partido.Goles_local.ToString();
                    tb_marcador_visitante.Text = partido.Goles_visitante.ToString();
                    tb_nombre_local.Text = partido.Local.Nombre;
                    tb_nombre_visitante.Text = partido.Visitante.Nombre;
                    if (partido.Finalizado && partido.Mvp != null) tb_mvp.Text = partido.Mvp.ToString();
                }
                else
                {
                    tb_marcador_local.Clear();
                    tb_marcador_visitante.Clear();
                    tb_nombre_local.Clear();
                    tb_nombre_visitante.Clear();
                    tb_mvp.Clear();
                    b_seleccionar_jugador_destacado.Enabled = false;
                    b_finalizar_enfrentamiento.Enabled = false;
                    b_gol_local.Enabled = false;
                    b_gol_visitante.Enabled = false;
                    b_anular_local.Enabled = false;
                    b_anular_visitante.Enabled = false;
                }
            }
            catch (Exception error) { throw new Exception("Ocurri� un error mostrando la informaci�n del enfrentamiento"); }
        }

        // M�todo que se emplea cuando se hace cambio de objeto seleccionado en la caja de torneos
        private void cb_torneos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cb_enfrentamientos.DataSource = ((Torneo)cb_torneos.SelectedItem).L_enfrentamientos;
                cb_enfrentamientos.SelectedIndex = 0;
            }
            catch (Exception error) { throw new Exception("Ocurri� un error cambiando la informaci�n de los torneos"); }
        }

        // M�todo del bot�n para comprar boletas
        private void b_comprar_boletas_Click(object sender, EventArgs e)
        {
            try
            {
                if (cb_enfrentamientos.SelectedIndex > 0)
                {
                    Enfrentamiento partido = (Enfrentamiento)cb_enfrentamientos.SelectedItem;
                    byte taquilla_compra = (byte)cb_taquillas.SelectedIndex;
                    byte cantidad_boletas = (byte)cb_cantidad_boletas.SelectedItem;
                    if (!partido.Finalizado)
                    {
                        MessageBox.Show(partido.Escenario.L_taquillas[taquilla_compra].Vender_boleta(cantidad_boletas, partido));
                    }
                    else MessageBox.Show("El partido para el que intenta comprar las boletas ya finaliz�");
                }
            }
            catch (Exception error) { throw new Exception("Ocurri� un error durante la venta de boletas\n" + error); }
        }
    }
}