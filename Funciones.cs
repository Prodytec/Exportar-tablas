using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Data.SqlClient;
using System.Configuration;
using static Conexion.Conexionbd;
using System.Data;

namespace Conexion
{
    class Funciones
    {
        public void Pedidosdeclientes(MaskedTextBox desde, MaskedTextBox Hasta, DataGridView datagrid, string store)
        {
            //llamo al store
            
            SqlConnection cnn = DbConnection.getDBConnection();
            SqlDataAdapter da = new SqlDataAdapter(store, cnn);
            DataSet ds = new DataSet();

            //parametros
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Desde", desde.Text.ToString());
            da.SelectCommand.Parameters.AddWithValue("@Hasta", Hasta.Text.ToString());
            da.Fill(ds, "store");
            cnn.Close();

            //mostrar en tabla
            datagrid.DataSource = ds;
            datagrid.DataMember = "store";

        }

        public void Listaarticulos(TextBox Lista, DataGridView datagrid)
        {
            //llamo al store
            string store;
            store = "sp_Lista_articulos";
            SqlConnection cnn = DbConnection.getDBConnection();
            SqlDataAdapter da = new SqlDataAdapter(store, cnn);
            DataSet ds = new DataSet();

            //parametros
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@lista", Lista.Text.ToString());
            da.Fill(ds, "store");
            cnn.Close();

            //mostrar en tabla
            datagrid.DataSource = ds;
            datagrid.DataMember = "store";

        }

        public void Llenargrid(DataGridView datagrid, string store)
        {
            SqlConnection cnn = DbConnection.getDBConnection();
            SqlDataAdapter da = new SqlDataAdapter(store, cnn);
            DataSet ds = new DataSet();

            da.Fill(ds, "store");
            cnn.Close();

            //mostrar en tabla
            datagrid.DataSource = ds;
            datagrid.DataMember = "store";
        }

        public void Llenargrid(DataGridView datagrid, string store, ComboBox combo)
        {
            SqlConnection cnn = DbConnection.getDBConnection();
            SqlDataAdapter da = new SqlDataAdapter(store, cnn);
            DataSet ds = new DataSet();

            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@idproveedor", combo.SelectedValue.ToString());
            da.Fill(ds, "store");
            cnn.Close();

            //mostrar en tabla
            datagrid.DataSource = ds;
            datagrid.DataMember = "store";
        }

        public void Llenarcombo(ComboBox combo)
        {
            string consulta = "select Nombre, idproveedor from proveedores order by Nombre";
            SqlConnection cnn = DbConnection.getDBConnection();
            SqlDataAdapter da = new SqlDataAdapter(consulta, cnn);
            DataTable lista = new DataTable();
            da.Fill(lista);

            combo.DisplayMember = "Nombre";
            combo.ValueMember = "idproveedor";
            combo.DataSource = lista;
        }
    }
}
