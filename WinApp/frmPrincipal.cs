using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services.BaseService;
using WinApp.Domain.Observer;

namespace WinApp
{
    public partial class frmPrincipal : Form
    {
        private static List<IFormObserver> formularios = new List<IFormObserver>();

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            foreach (var item in LanguageService.GetInstance().GetIdiomasDisponibles())
            {
                cmbIdioma.Items.Add(item);
            } 
        }

        private void listadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListadoClientes frmListadoClientes = new frmListadoClientes();
            frmListadoClientes.MdiParent = this;
            frmListadoClientes.Show();

            formularios.Add(frmListadoClientes);
        }

        public static void Detach(IFormObserver formulario)
        {
            formularios.Remove(formulario);
            //formularios.RemoveAll(o => o.Name == formulario.Name);
        }

        public void Notify()
        {
            foreach (IFormObserver formulario in formularios)
            {
                formulario.Update(this);
            }            
        }

        private void cmbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            CultureInfo culture = (CultureInfo)cmbIdioma.SelectedItem;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture.Name);
            Notify();
        }
    }
}
