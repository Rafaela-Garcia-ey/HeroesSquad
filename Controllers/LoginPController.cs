using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Project.Controllers
{
    public class LoginPController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Logar(string username, string senha)
        {
            MySqlConnection mySqlConnection = new MySqlConnection("server=localhost; database=usuariosdb;uid=root;password=1608");

            await mySqlConnection.OpenAsync();

            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = $"SELECT * FROM usuarios WHERE username = '{username}' AND senha = '{senha}'";

            MySqlDataReader reader = mySqlCommand.ExecuteReader();



            if (await reader.ReadAsync())
            {

                return RedirectToAction("Index", "Heroes");
            }


            return Json(new { Msg = "Usuario nao encontrado" });

        }
    }
}
