namespace windowsforms_provapratica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            CriarNovoUsuario();
            
        }
        private bool Validacao()
        {
            if(string.IsNullOrEmpty(txtNome.Text))
            {
                MessageBox.Show("Informe o seu nome por favor");
                return false;
            }
            return true;
        }

        private bool ValidarTelefone()
        {
            if (string.IsNullOrEmpty(txtTelefone.Text))
            {
                MessageBox.Show("Informe o número de telefone por favor");
                return false;
            }
            return true;
        }
       public bool CriarNovoUsuario()
       {
            Usuario novoUsuario = new Usuario();
            //atribuir nome para o novoUsuario
            novoUsuario.Nome = txtNome.Text;
            
            //telefone
            string phone = txtTelefone.Text.Replace("(","");
            phone = phone.Replace(")", "");
            phone = phone.Replace("-", "");
            novoUsuario.Telefone = phone;

            if(!Validacao() || !ValidarTelefone())
            {
                return false;
            }
            bool existetelefone = Database.ehTelefone(txtTelefone.Text);
            if (existetelefone)
            {
                MessageBox.Show("Já existe esse telefone");
                return false;
            }

                bool sucesso = Database.SalvarUsuario(novoUsuario);
            if (sucesso)
            { 
                MessageBox.Show("Salvo com sucesso", "resposta",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
                MessageBox.Show("Erro ao salvar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return sucesso;

       } 


    }
}
