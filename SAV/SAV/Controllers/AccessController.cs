using SAV.BaseDatos;
using SAV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SAV.Controllers
{
    public class AccessController : Controller
    {

        private SAVEntities db = new SAVEntities();
        public ActionResult Index()
        {
            return View();
        }

        //Registar usuario 
        public ActionResult Registrar()
        {

           Usuario oUsuario = new Usuario();

            return View(oUsuario);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrar([Bind(Exclude = "IsEmailVerified,ActivationCode")]Usuario oUsuario)
        {
            string message = "";
            bool Status = false;
            if (ModelState.IsValid)
            {

                #region //Email ya existe
                var isExist = IsEmailExist(oUsuario.Email);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "El correo electronico ya existe");
                    return View(oUsuario);
                }
                #endregion
                USUARIO user = new USUARIO();
                Persona per = new Persona();

                #region Generate Activation Code 
                user.ActivationCode = Guid.NewGuid();
                #endregion


            
                user.Email = oUsuario.Email;

                #region  Password Hashing 
                user.CONTASENA = Crypto.Hash(oUsuario.CONTASENA);
                
                #endregion

                user.COD_ROL = "CL";
                user.ESTADO = true;

                db.USUARIO.Add(user);
                db.SaveChanges();

                //persona
                per.PRIMER_NOM = oUsuario.PRIMER_NOM;
                per.SEGUNDO_NOM = oUsuario.SEGUNDO_NOM;
                per.PRIMER_APELLIDO = oUsuario.PRIMER_APELLIDO;
                per.SEGUNDO_APELLIDO = oUsuario.SEGUNDO_APELLIDO;
                per.TEL_FIJO = oUsuario.TEL_FIJO;
                per.TEL_MOVIL = oUsuario.TEL_MOVIL;
                per.DIRECCION = oUsuario.DIRECCION;
                per.ID_Persona = user.ID_USUARIO;


                db.Persona.Add(per);
                db.SaveChanges();
                //Send Email to User
              //  SendVerificationLinkEmail(user.Email, user.ActivationCode.ToString());

                message = "Se ha registrado exitosamente " +
                        " el email: " + user.Email;
                Status = true;
                //  oUsuario.MensajeExito = "Se ha Registrado con exito";

                ViewBag.Message = message;
                ViewBag.Status = Status;
                return View(oUsuario);
            }
            else
            {
                message = "Invalid Request";
            }
            
            return View();
        }

        //verificando que no esxitas el email
        [NonAction]
        public bool IsEmailExist(string Email)
        {
            using (SAVEntities db = new SAVEntities())
            {
                var v = db.USUARIO.Where(a => a.Email == Email).FirstOrDefault();
          
                return v != null;
            }
        }
        //Vericar cuenta  

        [HttpGet]
        public ActionResult VerifyAccount(string id)
        {
            bool Status = false;
            using (SAVEntities db = new SAVEntities())
            {
                db.Configuration.ValidateOnSaveEnabled = false; // This line I have added here to avoid 
                                                                // Confirm password does not match issue on save changes
                var v = db.USUARIO.Where(a => a.ActivationCode == new Guid(id)).FirstOrDefault();
                if (v != null)
                {
                    v.ESTADO = true;
                    db.SaveChanges();
                    Status = true;
                }
                else
                {
                    ViewBag.Message = "Invalid Request";
                }
            }
            ViewBag.Status = Status;
            return View();
        }

        //iniciar sesion 

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //Login POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin login, string ReturnUrl = "")
        {
            string message = "";
            using (SAVEntities db = new SAVEntities())
            {
                var v = db.USUARIO.Where(a => a.Email == login.EmailID).FirstOrDefault();
                if (v != null)
                {
                   
                    if (string.Compare(Crypto.Hash(login.Password), v.CONTASENA) == 0)
                    {
                        int timeout = login.RememberMe ? 525600 : 20; // 525600 min = 1 year
                        var ticket = new FormsAuthenticationTicket(login.EmailID, login.RememberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);


                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        message = "Crendenciales invalidas";
                    }
                }
                else
                {
                    message = "Crendenciales invalidas";
                }
            }
            ViewBag.Message = message;
            return View();
        }


        //cerrar sesion
        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Access");
        }

        //Olvide contraseña

     public ActionResult olvidePassword()
        {

            return View();
        }

        [HttpPost]
        public ActionResult olvidePassword(string Email)
        {
            //verifir el email
            //generar Reset password
            //mandar email

            String message = "";
            bool satatus = false;
            using (SAVEntities db = new SAVEntities())
            {
                var account = db.USUARIO.Where(a => a.Email == Email).FirstOrDefault();
                if(account != null)
                {
                    //manda el email para el reset de contaseña
                    String resetCode = Guid.NewGuid().ToString();
                    SendVerificationLinkEmail(account.Email, resetCode, "ResetContra");
                    account.ReseteoContraCode = resetCode;
                    //this line i have added here to avoid confirm password noit match issue, as we had added a confrmir password property
                    //in our class User model 
                    db.Configuration.ValidateOnSaveEnabled = false;

                    db.SaveChanges();
                    message = "Link para resetear su contraseña a sido enviado a su email";

                }
                else
                {
                    message = "Email no encontrado";
                }
            }
            ViewBag.Message = message;
            return View();
        }


        public ActionResult ResetContra(string id)
        {
            using (SAVEntities db = new SAVEntities())
            {
                var user = db.USUARIO.Where(a => a.ReseteoContraCode == id).FirstOrDefault();
                if (user != null)
                {
                    ResetContraModel model = new ResetContraModel();
                    model.ResetCode = id;
                    return View(model);
                }
                else
                {
                    return HttpNotFound();
                }
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetContra(ResetContraModel model)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                using (SAVEntities db = new SAVEntities())
                {
                    var user = db.USUARIO.Where(a => a.ReseteoContraCode == model.ResetCode).FirstOrDefault();
                    if(user != null)
                    {
                        user.CONTASENA = Crypto.Hash(model.NuevaContra);
                        user.ReseteoContraCode = "";
                        db.Configuration.ValidateOnSaveEnabled = false;
                        db.SaveChanges();
                        message = "Nueva contraseña actulizada con exito";
                    }

                }
            }
            else
            {
                message = "algo invalido";
            }
            ViewBag.Message = message;
            return View(model);
        }


        //mandar email para activacion y  el reset de contraseña
        [NonAction]
        public void SendVerificationLinkEmail(string emailID, string activationCode, string emailfor = "VerifyAccount")
        {
            var verifyUrl = "/Access/"+ emailfor + "/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("valenovoan@gmail.com", "Dotnet Awesome");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "********"; // Replace with actual password

            string subject = "";
            string body = "";
            if(emailfor== "VerifyAccount")
            {
                subject = "Your account is successfully created!";

                body = "<br/><br/>We are excited to tell you that your Dotnet Awesome account is" +
                    " successfully created. Please cl ick on the below link to verify your account" +
                    " <br/><br/><a href='" + link + "'>" + link + "</a> ";
            }
            else if(emailfor== "ResetContra")
            {
                subject = "Reset contraseña";
                body = "Hola, <br/> vamos a resetear su contraseña, porfavor has click en el link:<a href='"+ link + " '> Reset contraseña</a>";
            }


            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
               
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);




        }


    }
}