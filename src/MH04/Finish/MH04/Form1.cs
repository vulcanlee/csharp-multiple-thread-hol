using System.Net;

namespace MH04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = $"·Æ¹«®y¼Ð ({e.X},{e.Y})";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string url = $"https://businessblazor.azurewebsites.net/api/RemoteService/" +
                $"Add/{textBox1.Text}/{textBox2.Text}/{textBox3.Text}";
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync(url);
            label2.Text = result;
        }
    }
}
