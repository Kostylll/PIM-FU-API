using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using PIMAPI.Application.Abstraction.Domain.Request;
using WinFormsApp1;
using Azure;
using Microsoft.Data.SqlClient;

namespace PIMAPI.Application.Form
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

            UserControl1 userControl1 = new UserControl1();
            this.Controls.Add(userControl1);

            string nome = textBox1.Text;
            string email = textBox2.Text;
            string cpf = FormatarCPF(textBox3.Text);
            string telefone = FormatarCelular(textBox4.Text);
            string endereço = textBox5.Text;
            string data_Nascimento = textBox6.Text;


            var dadosForm = new ColaboradorRequest
            {
                Nome = nome,
                Email = email,
                CPF = cpf,
                Data_Nascimento = data_Nascimento,
                Endereco = endereço,
                Telefone = telefone,
                Senha = cpf
            };

            AdicionarColaborador(dadosForm);


            this.Parent.Controls.Remove(this);
        }

        public string FormatarCPF(string cpf)
        {
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            if (cpf.Length != 11)
            {

                return cpf;
            }

            return $"{cpf.Substring(0, 3)}.{cpf.Substring(3, 3)}.{cpf.Substring(6, 3)}-{cpf.Substring(9, 2)}";
        }
        public string FormatarCelular(string celular)
        {
            celular = new string(celular.Where(char.IsDigit).ToArray());


            if (celular.Length != 11)
            {
                return celular;
            }


            return $"({celular.Substring(0, 2)}) {celular.Substring(2, 5)}-{celular.Substring(7, 4)}";
        }

        public async Task<bool> AdicionarColaborador(ColaboradorRequest request)
        {
            string sqlCommand = "INSERT INTO Colaboradores (Nome, Data_Nascimento, CPF, Email, Endereço, Telefone, Senha) VALUES (@Nome, @Data_Nascimento, @CPF, @Email, @Endereço, @Telefone, @CPF)";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@Nome", request.Nome },
                { "@Data_Nascimento", request.Data_Nascimento },
                { "@CPF", request.CPF },
                { "@Email", request.Email },
                { "@Endereço" , request.Endereco },
                { "@Telefone", request.Telefone },
                { "@Senha",request.CPF ?? (object)DBNull.Value },


            };
            return await AdicionarAsync(sqlCommand, parameters);
        }

        public async Task<bool> AdicionarAsync(string sqlCommand, Dictionary<string, object> parameters)
        {
            var cnn = "Data Source=localhost;Database=PIMAPIdb;Trusted_Connection=True;Trust Server Certificate = true;";
            try
            {
                using (SqlConnection conn = new SqlConnection(cnn))
                {
                    SqlCommand cmd = new SqlCommand(sqlCommand, conn);
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                    }

                    await conn.OpenAsync();
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro ao adicionar: " + ex.Message);
                return false;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
