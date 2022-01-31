using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Data.SqlClient;
using System.Configuration;
using static Conexion.Conexionbd;
using static Conexion.Excel;



namespace Conexion
{
    public partial class Exportar : Form
    {

        
        
        public Exportar()
        {
            InitializeComponent();
        }

        string Valor = (string)Instalacion.GetValor();
        private void Form1_Load(object sender, EventArgs e)
        {
            Funciones F = new Funciones();

            switch (Valor.ToLower())
            {
                case "casavictor":
                    cmb.Items.Add("Seleccione opcion");
                    cmb.Items.Add("Pedidos de clientes");
                    cmb.SelectedItem = cmb.Items[0];
                    return;
                case "candies":
                    cmb.Items.Add("Seleccione opcion");
                    cmb.Items.Add("Listado de articulos");
                    cmb.SelectedItem = cmb.Items[0];
                    return;
                case "richam":
                    cmb.Items.Add("Seleccione opcion");
                    cmb.Items.Add("Listado clientes");
                    cmb.Items.Add("Listado proveedores");
                    cmb.SelectedItem = cmb.Items[0];
                    lbllista.Visible = false;
                    lbldesde.Visible = false;
                    lblhasta.Visible = false;
                    mtxtdesde.Visible = false;
                    mtxthasta.Visible = false;
                    txtlista.Visible = false;
                    return;
                case "casaosvaldo":
                    cmb.Items.Add("Seleccione opcion");
                    cmb.Items.Add("Listado");
                    cmb.SelectedItem = cmb.Items[0];
                    lbllista.Visible = false;
                    lbldesde.Visible = false;
                    lblhasta.Visible = false;
                    mtxtdesde.Visible = false;
                    mtxthasta.Visible = false;
                    txtlista.Visible = false;
                    return;
                case "brm":
                    cmb.Items.Add("Seleccione opcion");
                    F.Llenarcombo(cmb);
                    cmb.SelectedItem = cmb.Items[0];
                    lbllista.Visible = false;
                    lbldesde.Visible = false;
                    lblhasta.Visible = false;
                    mtxtdesde.Visible = false;
                    mtxthasta.Visible = false;
                    txtlista.Visible = false;
                    return;
                case "komsa":
                    cmb.Items.Add("Seleccione opcion");
                    cmb.Items.Add("Stock Valorizado");
                    cmb.SelectedItem = cmb.Items[0];
                    lbllista.Visible = false;
                    lbldesde.Visible = false;
                    txtlista.Visible = false;
                    mtxtdesde.Visible = false;   
                    return;
                case "procopias":
                    cmb.Items.Add("Seleccione opcion");
                    cmb.Items.Add("Control Precio Minimo");
                    cmb.SelectedItem = cmb.Items[0];
                    lbllista.Visible = false;
                    lbldesde.Visible = false;
                    txtlista.Visible = false;
                    mtxtdesde.Visible = false;
                    lblhasta.Visible = false;
                    mtxthasta.Visible = false;
                    Btnexportar.Visible = false;
                    return;
                case "veneta":
                    cmb.Items.Add("Seleccione opcion");
                    cmb.Items.Add("Historico de Cotizaciones");
                    cmb.SelectedItem = cmb.Items[0];
                    lbllista.Visible = false;
                    lbldesde.Visible = false;
                    txtlista.Visible = false;
                    mtxtdesde.Visible = false;
                    lblhasta.Visible = false;
                    mtxthasta.Visible = false;
                    Btnexportar.Visible = false;
                    return;
                case "moutex":
                    cmb.Items.Add("Seleccione opcion");
                    cmb.Items.Add("SaldoDolarUltimoMov");
                    cmb.SelectedItem = cmb.Items[0];
                    lbllista.Visible = false;
                    lbldesde.Visible = false;
                    txtlista.Visible = false;
                    mtxtdesde.Visible = false;
                    lblhasta.Visible = false;
                    mtxthasta.Visible = false;
                    Btnexportar.Visible = false;
                    return;
                case "grievas":
                    cmb.Items.Add("Seleccione opcion");
                    cmb.Items.Add("Dias Promedio de Pago - Clientes");
                    cmb.SelectedItem = cmb.Items[0];
                    lbllista.Visible = false;
                    lbldesde.Visible = false;
                    lblhasta.Visible = false;
                    txtlista.Visible = false;
                    cmb.TabIndex = 0;
                    mtxtdesde.TabIndex = 1;
                    mtxthasta.TabIndex = 2;
                    return;
                default:
                    MessageBox.Show("No se encuentra la instalacion");
                    Close();
                    break;

            }
        }


       
        private void Btnexportar_Click(object sender, EventArgs e)
        {
            Excel ex = new Excel();

            ex.ExportarDataGridViewExcel(grilla);
            
        }
       

        private void Btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnprocesar_Click(object sender, EventArgs e)
        {
            Funciones F = new Funciones();
          
            switch (Valor.ToLower())
            {
                case "casavictor":
                    if (cmb.SelectedIndex == 0)
                    {
                        MessageBox.Show("Seleccione una opcion");
                    }
                    else if (cmb.SelectedIndex == 1)
                    {
                        string store = "sp_pedidos_de_clientes";
                        F.Pedidosdeclientes(mtxtdesde, mtxthasta, grilla, store);
                    }
                    return;
                case "candies":
                    if (cmb.SelectedIndex == 0)
                    {
                        MessageBox.Show("Seleccione una opcion");
                    }
                    else if (cmb.SelectedIndex == 1)
                    {
                        F.Listaarticulos(txtlista, grilla);
                    }
                    return;
                case "richam":
                    if(cmb.SelectedIndex == 0)
                    {
                        MessageBox.Show("Seleccione una opcion");
                    }
                    else if (cmb.SelectedIndex == 1)
                    {
                        string spclientes = "SP_LISTA_CLIENTES";
                        F.Llenargrid(grilla, spclientes);
                    }
                    else if(cmb.SelectedIndex == 2)
                    {
                        string splista = "SP_LISTA_PROVEEDORES";
                        F.Llenargrid(grilla, splista);
                    }
                    return;
                case "casaosvaldo":
                    if (cmb.SelectedIndex == 0)
                    {
                        MessageBox.Show("Seleccione una opcion");
                    }
                    else if (cmb.SelectedIndex == 1)
                    {
                        string sposvaldo = "SP_INFO_CASAOSVALDO";
                        F.Llenargrid(grilla, sposvaldo);
                    }
                    return;
                case "brm":
                    if(cmb.SelectedIndex == 0)
                    {
                        MessageBox.Show("Seleccione una opcion");
                    }
                    else 
                    {
                        string spbrm = "LISTA_PROVEEDORES_BRM";
                        F.Llenargrid(grilla, spbrm, cmb);
                    }
                    return;
                case "grievas":
                    if (cmb.SelectedIndex == 0)
                    {
                        MessageBox.Show("Seleccione una opcion");
                    }
                    else if (cmb.SelectedIndex == 1)
                    {
                        string store = "Dias_Promedio_de_Pago_grievas";
                        F.Pedidosdeclientes(mtxtdesde, mtxthasta, grilla, store);
                    }
                    return;
                case "procopias":
                   
                    if (cmb.SelectedIndex == 0)
                    {
                        MessageBox.Show("Seleccione una opcion");
                    }
                    else if (cmb.SelectedIndex == 1)
                    {
                        string store = "sp_ControlPrecioMinimo";                
                        F.ControlPrecioMinimo(grilla,store);
                        btnprocesar.Visible = false;
                        Btnsalir.Focus();
                        
                    }
                    return;
                case "veneta":
                    if (cmb.SelectedIndex == 0)
                    {
                        MessageBox.Show("Seleccione una opcion");
                    }
                    else if (cmb.SelectedIndex == 1)
                    {
                        btnprocesar.BackColor = Color.Red;
                        btnprocesar.Text = "PROCESANDO...";
                        string store = "sp_HistoricoDolar";
                        F.HistoricoDolar(grilla, store);
                        btnprocesar.Visible = false;
                        Btnsalir.Focus();
                    }
                    return;
                case "moutex":
                    if (cmb.SelectedIndex == 0)
                    {
                        MessageBox.Show("Seleccione una opcion");
                    }
                    else if (cmb.SelectedIndex == 1)
                    {
                        string store = "sp_SaldoDolarUltimoMov";
                        F.SaldoDolarUltimoMov(grilla, store);
                        btnprocesar.Visible = false;
                        Btnsalir.Focus();
                    }
                    return;
                case "komsa":
                    if (cmb.SelectedIndex == 0)
                    {
                        MessageBox.Show("Seleccione una opcion");
                    }
                    else if (cmb.SelectedIndex == 1)
                    {
                        string store = "sp_StkValorizadoaFecha";                 ///maty
                        F.stkvalorizado(mtxthasta, grilla, store);
                     }
                    return;

                   
            }

            btnprocesar.Text = "Terminado";
        }




        private void grilla_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(grilla.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void txtdesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {

                e.Handled = true;

                return;
            }
        }

        private void txthasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {

                e.Handled = true;

                return;
            }
        }

        private void cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Valor.ToLower())
            {
                case "casavictor":
                    if (cmb.SelectedIndex == 1)
                    {
                        mtxtdesde.Visible = true;
                        lbldesde.Visible = true;
                        mtxthasta.Visible = true;
                        lblhasta.Visible = true;
                        mtxtdesde.Focus();
                    }
                    else
                    {
                        mtxtdesde.Visible = false;
                        mtxtdesde.Text = "";
                        lbldesde.Visible = false;
                        mtxthasta.Visible = false;
                        mtxthasta.Text = "";
                        lblhasta.Visible = false;
                        lbllista.Visible = false;
                        txtlista.Visible = false;
                    }
                    return;
                case "candies":
                    if (cmb.SelectedIndex == 1)
                    {
                        lbllista.Visible = true;
                        txtlista.Visible = true;
                        txtlista.Focus();
                    }
                    else
                    {
                        mtxtdesde.Visible = false;
                        mtxtdesde.Text = "";
                        lbldesde.Visible = false;
                        mtxthasta.Visible = false;
                        mtxthasta.Text = "";
                        lblhasta.Visible = false;
                        lbllista.Visible = false;
                        txtlista.Visible = false;
                    }
                    return;         
            }
        }

        private void txtlista_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {

                e.Handled = true;

                return;
            }
        }

        private void txtlista_Leave(object sender, EventArgs e)
        {
            int cuantos0 = 3;
            string zeros;
            zeros = new string('0', Convert.ToInt32(cuantos0));

            txtlista.Text = string.Format("{0:" + zeros + "}", Convert.ToInt32(txtlista.Text));
            btnprocesar.Focus();
        }

        private void Exportar_Load(object sender, EventArgs e)
        {

        }

        private void grilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
