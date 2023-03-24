namespace Asimov_Student_Manager

{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void tryConnexion(Object sender, EventArgs e)
        {
            static async Task Main(string[] args)
            {
                using var httpClient = new HttpClient();
                var url = "";
                var response = await httpClient.GetAsync(url);
                var responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
        }
    }
}