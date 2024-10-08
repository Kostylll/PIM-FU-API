using PIMAPI.Application.Abstraction.Domain.Request;
using PIMAPI.Application.Interfaces;
using PIMAPI.Application.Services;
using System.ComponentModel;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private ColaboradorService _cobService;
        public Form1()
        {
            InitializeComponent();
            _cobService = new ColaboradorService();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

      


    }
}
