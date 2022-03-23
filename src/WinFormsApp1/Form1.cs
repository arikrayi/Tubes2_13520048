using Microsoft.Msagl.GraphViewerGdi;
using System.Media;

namespace BingSlamet
{
    public partial class Main : Form
    {
        SoundPlayer backgroundSong = new SoundPlayer("./Resources/newbacksound.wav");
        SoundPlayer errorsound = new SoundPlayer("./Resources/errorParah.wav");
        SoundPlayer klikinput = new SoundPlayer("./Resources/mintaInput.wav");
        SoundPlayer ketemu = new SoundPlayer("./Resources/suaraKetemu.wav");
        SoundPlayer start = new SoundPlayer("./Resources/windowsStartup.wav");
        SoundPlayer click = new SoundPlayer("./Resources/click.wav");

        GViewer viewer = new GViewer();
        public Main()
        {
            start.Play();
            InitializeComponent();
            Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled;
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TextStartingDir.Text.ToString() == "\r\n\r\n")
            {
                klikinput.Play();
            }
            else if (comboBox1.Items[comboBox1.SelectedIndex].ToString() == "BFS")
            {
                click.Play();
                string dir = TextStartingDir.Text;
                string filename = textBox2.Text;
                List<string> vs = new List<string>();
                try
                {
                    Search test = new(dir, filename);
                    test.bfs_search(0);
                    test.makeGraph();
                    ouputPanel.SuspendLayout();
                    ouputPanel.Controls.Add(viewer);
                    ouputPanel.ResumeLayout();
                    ouputPanel.Show();
                    viewer.Graph = test.graph;
                    viewer.Dock = DockStyle.Fill;
                    ketemu.Play();
                    textTimeElapsed.Text = "Time Elapsed: " + test.stopwatch.Elapsed.ToString(@"m\:ss\.ffffff");
                }
                catch { errorsound.Play(); }

            }
            else if (comboBox1.Items[comboBox1.SelectedIndex].ToString() == "DFS")
            {
                click.Play();
                string dir = TextStartingDir.Text;
                string filename = textBox2.Text;
                try
                {
                    Search test = new(dir, filename);
                    test.dfs_search(0);
                    test.makeGraph();
                    ouputPanel.SuspendLayout();
                    ouputPanel.Controls.Add(viewer);
                    ouputPanel.ResumeLayout();
                    ouputPanel.Show();
                    viewer.Graph = test.graph;
                    viewer.Dock = DockStyle.Fill;
                    ketemu.Play();
                    textTimeElapsed.Text = "Time Elapsed: " + test.stopwatch.Elapsed.ToString(@"m\:ss\.ffffff");
                }
                catch { errorsound.Play(); }
            }
            else
            {
                klikinput.Play();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TextStartingDir.Text.ToString() == "\r\n\r\n")
            {
                klikinput.Play();
            }
            else if (comboBox1.Items[comboBox1.SelectedIndex].ToString() == "BFS")
            {
                click.Play();
                string dir = TextStartingDir.Text;
                string filename = textBox2.Text;
                List<string> vs = new List<string>();
                Search test = new(dir, filename);
                try
                {
                    test.bfs_search(1);
                    test.makeGraph();
                    ouputPanel.SuspendLayout();
                    ouputPanel.Controls.Add(viewer);
                    ouputPanel.ResumeLayout();
                    ouputPanel.Show();
                    viewer.Graph = test.graph;
                    viewer.Dock = DockStyle.Fill;
                    ketemu.Play();
                    textTimeElapsed.Text = "Time Elapsed: " + test.stopwatch.Elapsed.ToString(@"m\:ss\.ffffff");
                }
                catch { errorsound.Play(); }
            }
            else if (comboBox1.Items[comboBox1.SelectedIndex].ToString() == "DFS")
            {
                click.Play();
                string dir = TextStartingDir.Text;
                string filename = textBox2.Text;
                try
                {

                    Search test = new(dir, filename);
                    test.dfs_search(1);
                    test.makeGraph();
                    ouputPanel.SuspendLayout();
                    ouputPanel.Controls.Add(viewer);
                    ouputPanel.ResumeLayout();
                    ouputPanel.Show();
                    viewer.Graph = test.graph;
                    viewer.Dock = DockStyle.Fill;
                    ketemu.Play();
                    textTimeElapsed.Text = "Time Elapsed: " + test.stopwatch.Elapsed.ToString(@"m\:ss\.ffffff");
                }
                catch { errorsound.Play(); }
            }
            else
            {
                klikinput.Play();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Items[comboBox1.SelectedIndex].ToString() != "--Select--")
                {
                click.Play();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {}

        private void button3_Click(object sender, EventArgs e)
        {
            click.Play();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                TextStartingDir.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Type Filename")
            {
                textBox2.Text = "";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Type Filename";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void foreground_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void windowsBar_Paint(object sender)
        {

        }
        private bool mouseDown;
        private Point lastLocation;

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Main_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void audioOn_Click(object sender, EventArgs e)
        {
            backgroundSong.Play();
            audioOff.Visible = true;
            audioOn.Visible = false;
        }

        private void audioOff_Click(object sender, EventArgs e)
        {
            backgroundSong.Stop();
            audioOff.Visible = false;
            audioOn.Visible = true;
        }
        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true;

        }
    }
}