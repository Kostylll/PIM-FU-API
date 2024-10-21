using Microsoft.Data.SqlClient;
using PIMAPI.Application.Abstraction.Domain.Request;
using PIMAPI.Application.Form;
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


        public async void LoadDataToGridView()
        {

            var colaboradores = await GetColaboradoresAsync();


            dataGridView1.DataSource = colaboradores.Select(c => new
            {
                c.Id,
                c.Nome,
                c.Email,
                c.CPF,
                c.Telefone,
                c.Endereco,
                Data_Nascimento = c.Data_Nascimento,
            }).ToList();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;

                string id = dataGridView1.Rows[rowIndex].Cells["ID"].Value.ToString();

                DialogResult result = MessageBox.Show("Tem certeza que deseja deletar este colaborador?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    RemoverColaborador(id);

                    Form1 form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                    form1?.LoadDataToGridView();


                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um colaborador para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }






        public async Task<bool> RemoverColaborador(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id), "Id cannot be null or empty.");
            }

            string connectionString = "Data Source=localhost;Database=PIMAPIdb;Trusted_Connection=True;Trust Server Certificate=true;";
            string deleteQuery = "DELETE FROM Colaboradores WHERE ID = @id";

            bool success = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                try
                {
                    using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@Id", id);
                        int rowsAffected = await deleteCommand.ExecuteNonQueryAsync();
                        success = rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {

                    Console.WriteLine($"Error removing collaborator: {ex.Message}");
                    throw;
                }
            }

            return success;
        }



        public async Task<List<ColaboradorRequest>> GetColaboradoresAsync()
        {
            var colaboradorViewList = new List<ColaboradorRequest>();

            string connectionString = "Data Source=localhost;Database=PIMAPIdb;Trusted_Connection=True;Trust Server Certificate = true;";

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT ID, CPF, NOME, DATA_NASCIMENTO, EMAIL, ENDEREÇO, TELEFONE FROM Colaboradores";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var colabViewModel = new ColaboradorRequest();

                            colabViewModel.Id = reader["Id"].ToString();
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

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            if (this.Controls.OfType<UserControl1>().Any())
            {
                return;
            }

            UserControl1 userControl1 = new UserControl1();



            this.Controls.Add(userControl1);

            int x = (this.Width - userControl1.Width) / 2;
            int y = (this.Height - userControl1.Height) / 2;
            userControl1.Location = new Point(x, y);

            userControl1.BringToFront();
            userControl1.Show();
        }
    }
}
