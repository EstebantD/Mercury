﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyectodeaula
{
    public partial class VentanaPrincipal : Form
    {
        public VentanaPrincipal()
        {
            InitializeComponent();
        }

        private void btnRestVent_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestVent.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestVent.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void SubmenRepor_Paint(object sender, PaintEventArgs e)
        {
            SubmenRepor.Visible = true;
        }

        private void btnRepoVent_Click(object sender, EventArgs e)
        {
            SubmenRepor.Visible = false;

        }

        private void btnReporComp_Click(object sender, EventArgs e)
        {
            SubmenRepor.Visible = false;
        }

        private void AbrirFormhijo(object formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormhijo(new Productos());
        }

        private void BtnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormhijo(new Ventas());
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            AbrirFormhijo(new Inicio());
        }

        private void VentanaPrincipal_Load(object sender, EventArgs e)
        {
            btnInicio_Click(null, e);
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
