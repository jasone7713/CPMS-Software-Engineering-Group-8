using CPMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using Microsoft.Data.SqlClient;

namespace CPMS.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //login redirect
        public IActionResult Login()
        {
            return View();
        }

        //register redirect
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ManageLogin(string UserType, string Username, string Password)
        {
            //if user enters an invalid login error them out (this handles SQL injection cases)
            if(!LoginManager.CheckValidityOfLogin(Username, Password))
            {
                //increment failed login count
                LoginManager.LoginAttempts++;

                return View("LoginError");
            }

            //user has logged in using admin credentials
            if(LoginManager.IsAdmin(Username, Password))
            {
                return RedirectToAction(nameof(Index));
            }

            //login logic section
            string Query = $"SELECT AuthorID FROM Author WHERE EmailAddress = '{Username}' AND Password = '{Password}';";

            //query filename from the paper associated with this paperID
            using (SqlConnection conn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=CPMS.Data;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                SqlCommand command = new SqlCommand(Query, conn);

                conn.Open();

                try
                {
                    //Author check section
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();

                        //if the reader has info in it
                        if (reader.HasRows)
                        {
                            try
                            {
                                if (reader[0] != null)
                                {
                                    //uploade global login information if a match is found in db
                                    LoginManager.Username = Username;
                                    LoginManager.UserType = "Author";
                                    LoginManager.IsLoggedIn = true;
                                    LoginManager.UserId = Convert.ToInt32(reader[0]);

                                    conn.Close();
                                    return RedirectToAction(nameof(Index));
                                }
                            }
                            catch
                            { /*error reading login data*/ }
                        }
                    }

                    //update the query for reviewer
                    Query = $"SELECT ReviewerID FROM Reviewer WHERE EmailAddress = '{Username}' AND Password = '{Password}';";

                    //reviewer check session
                    command = new SqlCommand(Query, conn);

                    //Author check section
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();

                        if (reader.HasRows)
                        {
                            if (reader[0] != null)
                            {
                                //uploade global login information if a match is found in db
                                LoginManager.Username = Username;
                                LoginManager.UserType = "Reviewer";
                                LoginManager.IsLoggedIn = true;
                                LoginManager.UserId = Convert.ToInt32(reader[0]);

                                conn.Close();
                                return RedirectToAction(nameof(Index));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //database connection error
                }

                //if we made it down here no login was found, send err message to user
                ViewBag.LoginMessages = "The username or password you entered is incorrect";

                conn.Close();
            }

            //return RedirectToAction(nameof(Index));
            return View("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}