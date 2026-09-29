using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Sportolo.Models;

namespace Sportolo.Controllers
{
    [Route("eredmeny")]
    [ApiController]
    public class EredmenyController : ControllerBase
    {
        public string ConnectionString = "server=localhost;port=3306;user=root;password=;database=sportolo13b";
        [HttpGet]
        public object GetAllEredmeny()
        {
            List<Eredmeny> list = new List<Eredmeny>();

            var connector = new MySqlConnection(ConnectionString);

            connector.Open();

            string sql = "SELECT * FROM eredmeny";

            var cmd = new MySqlCommand(sql, connector);

            var datareader = cmd.ExecuteReader();

            while (datareader.Read())
            {
                var result = new Eredmeny
                {
                    Id = datareader.GetInt32(0),
                    Competition = datareader.GetString(1),
                    Description = datareader.GetString(2),
                    ResultTime = datareader.GetDateTime(3),
                    UpdateTime = datareader.GetDateTime(4),
                    SportoloId = datareader.GetInt32(5)
                };
                list.Add(result);
            }


            connector.Close();

            return new { message = "Sikeres lekérdezés.", result = list };
        }
    }
}
