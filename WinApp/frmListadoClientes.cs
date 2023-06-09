using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Implementations;
using Services.Extensions;
using WinApp.Domain.Observer;

namespace WinApp
{
    public partial class frmListadoClientes : Form, IFormObserver
    {
        public frmListadoClientes()
        {
            InitializeComponent();
        }

        private void frmListadoClientes_Load(object sender, EventArgs e)
        {
            dgvClientes.DataSource = new ClienteService().GetAll();
            Update(this);
        }

        private void frmListadoClientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPrincipal.Detach(this);
        }

        public void Update(Form form)
        {
            lblTitulo.Text = "Listado de Clientes".Traducir();
        }
    }
}
