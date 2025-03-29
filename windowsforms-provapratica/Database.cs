using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace windowsforms_provapratica
{
    public static class Database
    {
        public static bool SalvarUsuario(Usuario usuario)
        {

            string connectionString = "server=localhost;port=3306;user =root;database=ti113_windowsforms";
            MySqlConnection conexao = new MySqlConnection(connectionString);
            conexao.Open();

            string query = "insert into Usuarios (Id, Nome, Telefone)" +
                "values(@Id, @Nome, @Telefone)";
            MySqlCommand cmd = conexao.CreateCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@Id",usuario.Id);
            cmd.Parameters.AddWithValue("@Nome",usuario.Nome);
            cmd.Parameters.AddWithValue("@Telefone",usuario.Telefone);
            int quantidade = cmd.ExecuteNonQuery();
            conexao.Close();
            if (quantidade == 0)
                return false;
            else
                return true;
        }

        public static bool ehTelefone(string telefone)
        {
            string connectionString = "server=localhost;port=3306;user =root;database=ti113_windowsforms";
            MySqlConnection conexao = new MySqlConnection(connectionString);
            conexao.Open();

            string query = "select * from usuarios where Telefone = @Telefone";
            MySqlCommand cmd = conexao.CreateCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@Telefone", telefone);
            MySqlDataReader conteudo = cmd.ExecuteReader();
            if(conteudo.Read())
                return true;
            else 
                return false;  
            
           
        }
        
    }
}
