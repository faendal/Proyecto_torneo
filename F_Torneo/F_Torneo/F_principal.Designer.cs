namespace F_Torneo
{
    partial class F_principal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gb_equipos = new GroupBox();
            lb_Tecnicos = new ListBox();
            lb_Jugadores = new ListBox();
            b_Crear_Equipo = new Button();
            b_Cargar_tecnico = new Button();
            b_Cargar_Jugadores = new Button();
            tb_Equipo = new TextBox();
            label1 = new Label();
            gb_enfrentamientos = new GroupBox();
            b_crear_enfrentamiento = new Button();
            cb_Escenario = new ComboBox();
            label3 = new Label();
            dt_Fecha = new DateTimePicker();
            lb_Equipos = new ListBox();
            label2 = new Label();
            gb_controles = new GroupBox();
            b_anular_visitante = new Button();
            b_gol_visitante = new Button();
            b_anular_local = new Button();
            b_gol_local = new Button();
            label5 = new Label();
            label4 = new Label();
            cb_enfrentamientos = new ComboBox();
            gb_Info_Enfrentamiento = new GroupBox();
            tb_marcador_visitante = new TextBox();
            tb_nombre_visitante = new TextBox();
            tb_marcador_local = new TextBox();
            tb_nombre_local = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            b_finalizar_enfrentamiento = new Button();
            gb_final_enfrentamiento = new GroupBox();
            label10 = new Label();
            tb_mvp = new TextBox();
            b_seleccionar_jugador_destacado = new Button();
            gb_equipos.SuspendLayout();
            gb_enfrentamientos.SuspendLayout();
            gb_controles.SuspendLayout();
            gb_Info_Enfrentamiento.SuspendLayout();
            gb_final_enfrentamiento.SuspendLayout();
            SuspendLayout();
            // 
            // gb_equipos
            // 
            gb_equipos.Controls.Add(lb_Tecnicos);
            gb_equipos.Controls.Add(lb_Jugadores);
            gb_equipos.Controls.Add(b_Crear_Equipo);
            gb_equipos.Controls.Add(b_Cargar_tecnico);
            gb_equipos.Controls.Add(b_Cargar_Jugadores);
            gb_equipos.Controls.Add(tb_Equipo);
            gb_equipos.Controls.Add(label1);
            gb_equipos.Location = new Point(83, 28);
            gb_equipos.Name = "gb_equipos";
            gb_equipos.Size = new Size(341, 612);
            gb_equipos.TabIndex = 0;
            gb_equipos.TabStop = false;
            gb_equipos.Text = "Equipos";
            // 
            // lb_Tecnicos
            // 
            lb_Tecnicos.FormattingEnabled = true;
            lb_Tecnicos.ItemHeight = 20;
            lb_Tecnicos.Location = new Point(29, 372);
            lb_Tecnicos.Name = "lb_Tecnicos";
            lb_Tecnicos.Size = new Size(286, 104);
            lb_Tecnicos.TabIndex = 7;
            // 
            // lb_Jugadores
            // 
            lb_Jugadores.FormattingEnabled = true;
            lb_Jugadores.ItemHeight = 20;
            lb_Jugadores.Location = new Point(29, 179);
            lb_Jugadores.Name = "lb_Jugadores";
            lb_Jugadores.Size = new Size(286, 104);
            lb_Jugadores.TabIndex = 6;
            // 
            // b_Crear_Equipo
            // 
            b_Crear_Equipo.Location = new Point(29, 515);
            b_Crear_Equipo.Name = "b_Crear_Equipo";
            b_Crear_Equipo.Size = new Size(286, 29);
            b_Crear_Equipo.TabIndex = 5;
            b_Crear_Equipo.Text = "Crear Equipo";
            b_Crear_Equipo.UseVisualStyleBackColor = true;
            b_Crear_Equipo.Click += b_Crear_Equipo_Click;
            // 
            // b_Cargar_tecnico
            // 
            b_Cargar_tecnico.Location = new Point(29, 315);
            b_Cargar_tecnico.Name = "b_Cargar_tecnico";
            b_Cargar_tecnico.Size = new Size(286, 29);
            b_Cargar_tecnico.TabIndex = 4;
            b_Cargar_tecnico.Text = "Cargar Técnico";
            b_Cargar_tecnico.UseVisualStyleBackColor = true;
            b_Cargar_tecnico.Click += b_Cargar_tecnico_Click;
            // 
            // b_Cargar_Jugadores
            // 
            b_Cargar_Jugadores.Location = new Point(29, 122);
            b_Cargar_Jugadores.Name = "b_Cargar_Jugadores";
            b_Cargar_Jugadores.Size = new Size(286, 29);
            b_Cargar_Jugadores.TabIndex = 3;
            b_Cargar_Jugadores.Text = "Cargar Jugadores";
            b_Cargar_Jugadores.UseVisualStyleBackColor = true;
            b_Cargar_Jugadores.Click += b_Cargar_Jugadores_Click;
            // 
            // tb_Equipo
            // 
            tb_Equipo.Location = new Point(29, 75);
            tb_Equipo.Name = "tb_Equipo";
            tb_Equipo.Size = new Size(286, 27);
            tb_Equipo.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 35);
            label1.Name = "label1";
            label1.Size = new Size(140, 20);
            label1.TabIndex = 0;
            label1.Text = "Nombre del Equipo";
            // 
            // gb_enfrentamientos
            // 
            gb_enfrentamientos.Controls.Add(b_crear_enfrentamiento);
            gb_enfrentamientos.Controls.Add(cb_Escenario);
            gb_enfrentamientos.Controls.Add(label3);
            gb_enfrentamientos.Controls.Add(dt_Fecha);
            gb_enfrentamientos.Controls.Add(lb_Equipos);
            gb_enfrentamientos.Controls.Add(label2);
            gb_enfrentamientos.Location = new Point(501, 28);
            gb_enfrentamientos.Name = "gb_enfrentamientos";
            gb_enfrentamientos.Size = new Size(395, 388);
            gb_enfrentamientos.TabIndex = 1;
            gb_enfrentamientos.TabStop = false;
            gb_enfrentamientos.Text = "Enfrentamientos";
            // 
            // b_crear_enfrentamiento
            // 
            b_crear_enfrentamiento.Location = new Point(22, 340);
            b_crear_enfrentamiento.Name = "b_crear_enfrentamiento";
            b_crear_enfrentamiento.Size = new Size(354, 29);
            b_crear_enfrentamiento.TabIndex = 5;
            b_crear_enfrentamiento.Text = "Crear Enfrentamiento";
            b_crear_enfrentamiento.UseVisualStyleBackColor = true;
            b_crear_enfrentamiento.Click += b_crear_enfrentamiento_Click;
            // 
            // cb_Escenario
            // 
            cb_Escenario.FormattingEnabled = true;
            cb_Escenario.Location = new Point(22, 282);
            cb_Escenario.Name = "cb_Escenario";
            cb_Escenario.Size = new Size(354, 28);
            cb_Escenario.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 249);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 3;
            label3.Text = "Escenario";
            // 
            // dt_Fecha
            // 
            dt_Fecha.Location = new Point(22, 202);
            dt_Fecha.Name = "dt_Fecha";
            dt_Fecha.Size = new Size(354, 27);
            dt_Fecha.TabIndex = 2;
            // 
            // lb_Equipos
            // 
            lb_Equipos.FormattingEnabled = true;
            lb_Equipos.ItemHeight = 20;
            lb_Equipos.Location = new Point(22, 75);
            lb_Equipos.Name = "lb_Equipos";
            lb_Equipos.SelectionMode = SelectionMode.MultiSimple;
            lb_Equipos.Size = new Size(354, 104);
            lb_Equipos.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 35);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 1;
            label2.Text = "Equipos";
            // 
            // gb_controles
            // 
            gb_controles.Controls.Add(b_anular_visitante);
            gb_controles.Controls.Add(b_gol_visitante);
            gb_controles.Controls.Add(b_anular_local);
            gb_controles.Controls.Add(b_gol_local);
            gb_controles.Controls.Add(label5);
            gb_controles.Controls.Add(label4);
            gb_controles.Controls.Add(cb_enfrentamientos);
            gb_controles.Location = new Point(501, 422);
            gb_controles.Name = "gb_controles";
            gb_controles.Size = new Size(395, 218);
            gb_controles.TabIndex = 2;
            gb_controles.TabStop = false;
            gb_controles.Text = "Controles de Enfrentamiento";
            // 
            // b_anular_visitante
            // 
            b_anular_visitante.Location = new Point(218, 175);
            b_anular_visitante.Name = "b_anular_visitante";
            b_anular_visitante.Size = new Size(158, 29);
            b_anular_visitante.TabIndex = 6;
            b_anular_visitante.Text = "Anular Gol";
            b_anular_visitante.UseVisualStyleBackColor = true;
            b_anular_visitante.Click += b_anular_visitante_Click;
            // 
            // b_gol_visitante
            // 
            b_gol_visitante.Location = new Point(22, 175);
            b_gol_visitante.Name = "b_gol_visitante";
            b_gol_visitante.Size = new Size(158, 29);
            b_gol_visitante.TabIndex = 5;
            b_gol_visitante.Text = "Anotar Gol";
            b_gol_visitante.UseVisualStyleBackColor = true;
            b_gol_visitante.Click += b_gol_visitante_Click;
            // 
            // b_anular_local
            // 
            b_anular_local.Location = new Point(218, 103);
            b_anular_local.Name = "b_anular_local";
            b_anular_local.Size = new Size(158, 29);
            b_anular_local.TabIndex = 4;
            b_anular_local.Text = "Anular Gol";
            b_anular_local.UseVisualStyleBackColor = true;
            b_anular_local.Click += b_anular_local_Click;
            // 
            // b_gol_local
            // 
            b_gol_local.Location = new Point(22, 103);
            b_gol_local.Name = "b_gol_local";
            b_gol_local.Size = new Size(158, 29);
            b_gol_local.TabIndex = 3;
            b_gol_local.Text = "Anotar Gol";
            b_gol_local.UseVisualStyleBackColor = true;
            b_gol_local.Click += b_gol_local_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 152);
            label5.Name = "label5";
            label5.Size = new Size(180, 20);
            label5.TabIndex = 2;
            label5.Text = "Acciones Equipo Visitante";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 80);
            label4.Name = "label4";
            label4.Size = new Size(158, 20);
            label4.TabIndex = 1;
            label4.Text = "Acciones Equipo Local";
            // 
            // cb_enfrentamientos
            // 
            cb_enfrentamientos.FormattingEnabled = true;
            cb_enfrentamientos.Location = new Point(22, 35);
            cb_enfrentamientos.Name = "cb_enfrentamientos";
            cb_enfrentamientos.Size = new Size(354, 28);
            cb_enfrentamientos.TabIndex = 0;
            cb_enfrentamientos.SelectedIndexChanged += cb_enfrentamientos_SelectedIndexChanged;
            // 
            // gb_Info_Enfrentamiento
            // 
            gb_Info_Enfrentamiento.Controls.Add(tb_marcador_visitante);
            gb_Info_Enfrentamiento.Controls.Add(tb_nombre_visitante);
            gb_Info_Enfrentamiento.Controls.Add(tb_marcador_local);
            gb_Info_Enfrentamiento.Controls.Add(tb_nombre_local);
            gb_Info_Enfrentamiento.Controls.Add(label9);
            gb_Info_Enfrentamiento.Controls.Add(label8);
            gb_Info_Enfrentamiento.Controls.Add(label7);
            gb_Info_Enfrentamiento.Controls.Add(label6);
            gb_Info_Enfrentamiento.Location = new Point(962, 28);
            gb_Info_Enfrentamiento.Name = "gb_Info_Enfrentamiento";
            gb_Info_Enfrentamiento.Size = new Size(317, 400);
            gb_Info_Enfrentamiento.TabIndex = 3;
            gb_Info_Enfrentamiento.TabStop = false;
            gb_Info_Enfrentamiento.Text = "Información del Enfrentamiento";
            // 
            // tb_marcador_visitante
            // 
            tb_marcador_visitante.Location = new Point(16, 351);
            tb_marcador_visitante.Name = "tb_marcador_visitante";
            tb_marcador_visitante.Size = new Size(280, 27);
            tb_marcador_visitante.TabIndex = 7;
            // 
            // tb_nombre_visitante
            // 
            tb_nombre_visitante.Location = new Point(16, 256);
            tb_nombre_visitante.Name = "tb_nombre_visitante";
            tb_nombre_visitante.Size = new Size(280, 27);
            tb_nombre_visitante.TabIndex = 6;
            // 
            // tb_marcador_local
            // 
            tb_marcador_local.Location = new Point(16, 165);
            tb_marcador_local.Name = "tb_marcador_local";
            tb_marcador_local.Size = new Size(280, 27);
            tb_marcador_local.TabIndex = 5;
            // 
            // tb_nombre_local
            // 
            tb_nombre_local.Location = new Point(16, 75);
            tb_nombre_local.Name = "tb_nombre_local";
            tb_nombre_local.Size = new Size(280, 27);
            tb_nombre_local.TabIndex = 4;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(16, 220);
            label9.Name = "label9";
            label9.Size = new Size(125, 20);
            label9.TabIndex = 3;
            label9.Text = "Nombre Visitante";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(16, 47);
            label8.Name = "label8";
            label8.Size = new Size(103, 20);
            label8.TabIndex = 2;
            label8.Text = "Nombre Local";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(16, 315);
            label7.Name = "label7";
            label7.Size = new Size(134, 20);
            label7.TabIndex = 1;
            label7.Text = "Marcador Visitante";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 131);
            label6.Name = "label6";
            label6.Size = new Size(112, 20);
            label6.TabIndex = 0;
            label6.Text = "Marcador Local";
            // 
            // b_finalizar_enfrentamiento
            // 
            b_finalizar_enfrentamiento.Location = new Point(16, 41);
            b_finalizar_enfrentamiento.Name = "b_finalizar_enfrentamiento";
            b_finalizar_enfrentamiento.Size = new Size(280, 29);
            b_finalizar_enfrentamiento.TabIndex = 8;
            b_finalizar_enfrentamiento.Text = "Finalizar Enfrentamiento";
            b_finalizar_enfrentamiento.UseVisualStyleBackColor = true;
            b_finalizar_enfrentamiento.Click += b_finalizar_enfrentamiento_Click;
            // 
            // gb_final_enfrentamiento
            // 
            gb_final_enfrentamiento.Controls.Add(label10);
            gb_final_enfrentamiento.Controls.Add(tb_mvp);
            gb_final_enfrentamiento.Controls.Add(b_seleccionar_jugador_destacado);
            gb_final_enfrentamiento.Controls.Add(b_finalizar_enfrentamiento);
            gb_final_enfrentamiento.Location = new Point(962, 434);
            gb_final_enfrentamiento.Name = "gb_final_enfrentamiento";
            gb_final_enfrentamiento.Size = new Size(317, 206);
            gb_final_enfrentamiento.TabIndex = 9;
            gb_final_enfrentamiento.TabStop = false;
            gb_final_enfrentamiento.Text = "Final del Enfrentamiento";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(16, 140);
            label10.Name = "label10";
            label10.Size = new Size(257, 20);
            label10.TabIndex = 11;
            label10.Text = "El Jugador destacado del partido fue:";
            // 
            // tb_mvp
            // 
            tb_mvp.Location = new Point(16, 163);
            tb_mvp.Name = "tb_mvp";
            tb_mvp.Size = new Size(280, 27);
            tb_mvp.TabIndex = 10;
            // 
            // b_seleccionar_jugador_destacado
            // 
            b_seleccionar_jugador_destacado.Location = new Point(16, 91);
            b_seleccionar_jugador_destacado.Name = "b_seleccionar_jugador_destacado";
            b_seleccionar_jugador_destacado.Size = new Size(280, 29);
            b_seleccionar_jugador_destacado.TabIndex = 9;
            b_seleccionar_jugador_destacado.Text = "Seleccionar Jugador Destacado";
            b_seleccionar_jugador_destacado.UseVisualStyleBackColor = true;
            b_seleccionar_jugador_destacado.Click += b_seleccionar_jugador_destacado_Click;
            // 
            // F_principal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1374, 665);
            Controls.Add(gb_final_enfrentamiento);
            Controls.Add(gb_Info_Enfrentamiento);
            Controls.Add(gb_controles);
            Controls.Add(gb_enfrentamientos);
            Controls.Add(gb_equipos);
            Name = "F_principal";
            Text = "Form1";
            gb_equipos.ResumeLayout(false);
            gb_equipos.PerformLayout();
            gb_enfrentamientos.ResumeLayout(false);
            gb_enfrentamientos.PerformLayout();
            gb_controles.ResumeLayout(false);
            gb_controles.PerformLayout();
            gb_Info_Enfrentamiento.ResumeLayout(false);
            gb_Info_Enfrentamiento.PerformLayout();
            gb_final_enfrentamiento.ResumeLayout(false);
            gb_final_enfrentamiento.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gb_equipos;
        private ListBox lb_Tecnicos;
        private ListBox lb_Jugadores;
        private Button b_Crear_Equipo;
        private Button b_Cargar_tecnico;
        private Button b_Cargar_Jugadores;
        private TextBox tb_Equipo;
        private Label label1;
        private GroupBox gb_enfrentamientos;
        private ListBox lb_Equipos;
        private Label label2;
        private Button b_crear_enfrentamiento;
        private ComboBox cb_Escenario;
        private Label label3;
        private DateTimePicker dt_Fecha;
        private GroupBox gb_controles;
        private Button b_anular_visitante;
        private Button b_gol_visitante;
        private Button b_anular_local;
        private Button b_gol_local;
        private Label label5;
        private Label label4;
        private ComboBox cb_enfrentamientos;
        private GroupBox gb_Info_Enfrentamiento;
        private TextBox tb_marcador_visitante;
        private TextBox tb_nombre_visitante;
        private TextBox tb_marcador_local;
        private TextBox tb_nombre_local;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Button b_finalizar_enfrentamiento;
        private GroupBox gb_final_enfrentamiento;
        private TextBox tb_mvp;
        private Button b_seleccionar_jugador_destacado;
        private Label label10;
    }
}