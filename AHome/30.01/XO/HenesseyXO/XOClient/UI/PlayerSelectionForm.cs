using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XOClient.API;
using XOClient.UI.Games;

namespace XOClient.UI
{
    public partial class PlayerSelectionForm : Form
    {
        private string name;
        private ClientApi clientApi;
        private TicTacToeGame game;

        public PlayerSelectionForm()
        {
            InitializeComponent();
            CB_GameSelection.SelectedIndex = 0;
        }

        private void B_Connection_Click(object sender, EventArgs e)
        {
            NameDialog dlg = new NameDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                name = dlg.Nickname;
            }
            dlg.Dispose();
            StatusBar_PlayerName.Text += name;
            clientApi = new ClientApi(new EventHandler(FreePlayersListChanged),
                new EventHandler(InviteOccurHandler), new EventHandler(SuccessOccurHandler));
            StatusBar_Label.Text = "Connection acquared.";
            clientApi.SendClientName(name);
        }

        private void B_Invite_Click(object sender, EventArgs e)
        {
            string message = "invite:";
            try
            {
                message += LB_FreePlayers.SelectedItem as string;
            }
            catch (Exception ex)
            {
                // return;
                throw ex.InnerException;
            }
            clientApi.SendInviteRequest(message);
        }

        private void FreePlayersListChanged(object sender, EventArgs e)
        {
            string[] messages = sender as string[];
            if (this.LB_FreePlayers.InvokeRequired)
            {
                this.LB_FreePlayers.Invoke(new Action(() =>
                {
                    this.LB_FreePlayers.Items.Clear();
                    this.LB_FreePlayers.Items.AddRange(messages);
                }));
            }
        }

        private void InviteOccurHandler(object sender, EventArgs e)
        {
            string response = String.Empty;
            string message = sender as string;
            var result = MessageBox.Show(String.Format("Player {0} wants to play with you", message),
                "Invite", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                response = "yes:";
            }
            else
            {
                response = "no:";
            }
            response += name + "," + message;
            clientApi.InviteResponse(response);
        }

        private void SuccessOccurHandler(object sender, EventArgs e)
        {
            if ((sender as string).Equals("yes"))
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        this.Visible = false;
                    }));
                }
                game = new TicTacToeGame(clientApi.Client);
                game.ShowDialog();
                game.Dispose();
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Connection denied.", "Response");
            }
        }
    }
}
