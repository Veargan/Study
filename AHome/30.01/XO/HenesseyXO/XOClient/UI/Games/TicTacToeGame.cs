using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XOClient.Api;
using XOClient.Sessions;

namespace XOClient.UI.Games
{
    public partial class TicTacToeGame : Form
    {
        private string unit = null;
        private Session session;
        private PlayerTurn turn;
        private Button[] buttons;

        public TicTacToeGame(TcpClient client)
        {
            InitializeComponent();
            buttons = this.Controls[0].Controls.OfType<Button>().ToArray();
            buttons = buttons.Reverse().ToArray();
            session = new Session(client, new EventHandler(init_eventListener),
                new EventHandler(turn_eventListener));
        }

        private void OnTileClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (unit != null)
            {
                if (turn == PlayerTurn.TURN)
                {
                    string number = btn.Name.Replace("B_", "");
                    session.Send(new TTTpacket(turn, unit, int.Parse(number), null, null));
                }
            }
        }

        private void init_eventListener(object sender, EventArgs e)
        {
            TTTpacket packet = sender as TTTpacket;
            unit = packet.Unit;
            turn = packet.Turn;
            this.toolStripShape.Text = unit;
        }

        private void turn_eventListener(object sender, EventArgs e)
        {
            TTTpacket packet = sender as TTTpacket;
            if (packet.GameResult != null)
            {
                MessageBox.Show(packet.GameResult, "Game Over!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            else
            {
                Refresh(packet);
            }
        }

        private void Refresh(TTTpacket packet)
        {
            this.turn = packet.Turn;
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    for (int i = 0; i < packet.Matrix.Length; i++)
                    {
                        buttons[i].Text = packet.Matrix[i];
                    }
                    this.toolStripTurn.Text = packet.Turn.ToString();
                }));
            }
        }
    }
}
