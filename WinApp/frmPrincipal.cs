using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services.BaseService;

namespace WinApp
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            foreach (var item in LanguageService.GetInstance().GetIdiomasDisponibles())
            {
                cmbIdioma.Items.Add(item.DisplayName);
            } 
        }

        private void listadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListadoClientes frmListadoClientes = new frmListadoClientes();
            frmListadoClientes.MdiParent = this;
            frmListadoClientes.Show();
        }
    }
}
