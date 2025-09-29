using System;
using System.Windows.Forms;
using System.IO;
using JarvisReiven.Properties;

namespace JarvisReiven
{
    public partial class Customize : Form
    {
        StreamReader sr;

        public Customize()
        {
            InitializeComponent();
            txtGmail.Text = Settings.Default.GmailUser;
            txtPassword.Text = Settings.Default.GmailPassword;
            sr = new StreamReader(frmMain.scpath); txtShellCommands.Text = sr.ReadToEnd(); sr.Close();
            sr = new StreamReader(frmMain.srpath); txtShellResponse.Text = sr.ReadToEnd(); sr.Close();
            sr = new StreamReader(frmMain.slpath); txtShellLocation.Text = sr.ReadToEnd(); sr.Close();
            sr = new StreamReader(frmMain.webcpath); txtWebCommands.Text = sr.ReadToEnd(); sr.Close();
            sr = new StreamReader(frmMain.webrpath); txtWebResponse.Text = sr.ReadToEnd(); sr.Close();
            sr = new StreamReader(frmMain.weblpath); txtWebURL.Text = sr.ReadToEnd(); sr.Close();
            sr = new StreamReader(frmMain.socpath); txtSocialCommands.Text = sr.ReadToEnd(); sr.Close();
            sr = new StreamReader(frmMain.sorpath); txtSocialResponse.Text = sr.ReadToEnd(); sr.Close();
            
            txtName.Text = Settings.Default.User.ToString(); txtWOEID.Text = Settings.Default.WOEID.ToString();
            if (Settings.Default.Temperature.ToString() == "f")
            { rbFahrenheit.Checked = true; }
            else if (Settings.Default.Temperature.ToString() == "c")
            { rbCelsius.Checked = true; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = File.CreateText(frmMain.scpath))
                { sw.Write(txtShellCommands.Text); sw.Close(); }
            using (StreamWriter sw = File.CreateText(frmMain.srpath))
                { sw.Write(txtShellResponse.Text); sw.Close(); }
            using (StreamWriter sw = File.CreateText(frmMain.slpath))
                { sw.Write(txtShellLocation.Text); sw.Close(); }
            using (StreamWriter sw = File.CreateText(frmMain.webcpath))
                { sw.Write(txtWebCommands.Text); sw.Close(); }
            using (StreamWriter sw = File.CreateText(frmMain.webrpath))
                { sw.Write(txtWebResponse.Text); sw.Close(); }
            using (StreamWriter sw = File.CreateText(frmMain.weblpath))
                { sw.Write(txtWebURL.Text); sw.Close(); }
            using (StreamWriter sw = File.CreateText(frmMain.socpath))
                { sw.Write(txtSocialCommands.Text); sw.Close(); }
            using (StreamWriter sw = File.CreateText(frmMain.sorpath))
                { sw.Write(txtSocialResponse.Text); sw.Close(); }
            
            if (txtName.Text == String.Empty)
            { Settings.Default.User = frmMain.userName; txtName.Text = frmMain.userName; }
            else { Settings.Default.User = txtName.Text; }
            if (txtWOEID.Text == String.Empty)
            { Settings.Default.WOEID = "AOXX0008"; txtWOEID.Text = "AOXX0008"; }
            else { Settings.Default.WOEID = txtWOEID.Text; }
            if (rbFahrenheit.Checked == true)
            { Settings.Default.Temperature = "f"; }
            else if (rbCelsius.Checked == true)
            { Settings.Default.Temperature = "c"; }
            Settings.Default.GmailUser = txtGmail.Text;
            Settings.Default.GmailPassword = txtPassword.Text;
            Settings.Default.Save();
        }

        private void lblHelp_MouseEnter(object sender, EventArgs e)
        {
            txtHelp.Visible = true;
            if (tabCommands.SelectedTab == tabUser)
            { txtHelp.Text = "Um WOEID é um 'Identificador de Regiãos'. Isso permite que o programa saiba em que regisão você está, para assim poder dizer como está o tempo dessa localidade. Voce pode achar o WOEID da sua região clicando na ligação abaixo. Por exemplo, o WOEID de Angola (Luanda) é: AOXX0008"; }
            else
            { txtHelp.Text = "Isso lhe permite criar comandos, cada comando deve estar na sua própria linha igual ao exemplo. As respostas devem estar na mesma linha do seu comando (na caixa em frente). Linhas de espaço em branco (sem resposta) causará erros. Quando terminar, click em Salvar e diga 'Actualizar Comando'."; }
        }

        private void lblHelp_MouseLeave(object sender, EventArgs e)
        {
            txtHelp.Visible = false;
        }

        private void txtWOEIDSearch_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://woeid.rosselliot.co.nz/");
        }

        private void btnFileBrowse_Click(object sender, EventArgs e)
        {
            DialogResult dr = oFDSelectFile.ShowDialog();
            if (dr == DialogResult.OK)
            {
                using (StreamWriter sw = File.CreateText(frmMain.slpath))
                { sw.Write(txtShellLocation.Text); sw.Write(oFDSelectFile.FileName); sw.Close(); }
                sr = new StreamReader(frmMain.slpath);
                txtShellLocation.Text = sr.ReadToEnd();
                sr.Close();
            }
        }
    }
}
