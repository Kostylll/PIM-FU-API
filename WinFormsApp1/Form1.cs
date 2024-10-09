using Microsoft.Data.SqlClient;
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
            LoadDataToGridView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public async Task<List<ColaboradorRequest>> GetColaboradoresAsync()
        {
            var colaboradorViewList = new List<ColaboradorRequest>();

            string connectionString = "Data Source=localhost;Database=PIMAPIdb;Trusted_Connection=True;Trust Server Certificate = true;";

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT CPF, NOME, DATA_NASCIMENTO, EMAIL, ENDEREÇO, TELEFONE FROM Colaboradores";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var colabViewModel = new ColaboradorRequest();

                            colabViewModel.CPF = reader["CPF"].ToString();
                            colabViewModel.Nome = reader["Nome"].ToString();
                            colabViewModel.Data_Nascimento = reader["DATA_NASCIMENTO"].ToString();
                            colabViewModel.Email = reader["EMAIL"].ToString();
                            colabViewModel.Endereco = reader["ENDEREÇO"].ToString();
                            colabViewModel.Telefone = reader["TELEFONE"].ToString();

                            colaboradorViewList.Add(colabViewModel);
                        }
                    }
                }
            }
            return colaboradorViewList;
        }

        private async void LoadDataToGridView()
        {
          
            var colaboradores = await GetColaboradoresAsync();

     
            dataGridView1.DataSource = colaboradores.Select(c => new
            {
                c.Nome,
                c.Email,
                c.CPF,
                c.Telefone,
                Data_Nascimento = c.Data_Nascimento,  
            }).ToList();
        }



    }
}
