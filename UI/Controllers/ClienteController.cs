using PagedList;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Web.Mvc;
using UI.API;

namespace UI.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        public APICliente adminCliente = new APICliente();

        public bool Login()
        {
            string token = null;
            if(Session["token"] == null)
            {
                token = adminCliente.getTokenToka();
                if (string.IsNullOrEmpty(token))
                    return false;
                Session["token"] = token;
            }
            else
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(Session["token"].ToString());
                var expirdate = jwtToken.ValidTo;

                if (expirdate < DateTime.UtcNow)
                {
                    token = adminCliente.getTokenToka();
                    if (string.IsNullOrEmpty(token))
                        return false;
                    Session["token"] = token;
                }
            }
            return true;
        }

        // GET: Cliente
        public ActionResult Index(int? PageNo)
        {
            var auth = Login();

            var list = adminCliente.get(Session["token"].ToString());

            if (!auth)
                ViewBag.Error = "Hay un problema de autenticación";

            return View(list.ToPagedList(PageNo ?? 1, 20));
        }

        public FileResult GenerateExcel(int PageNo = 1)
        {
            Login();
            var report = adminCliente.generateExcel(PageNo, Session["token"].ToString());
            return File(report.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ListaClientes.xlsx");
        }
    }
}