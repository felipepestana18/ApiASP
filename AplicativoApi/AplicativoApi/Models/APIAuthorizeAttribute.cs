using Plugin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace AplicativoApi.Models
{
    internal class APIAuthorizeAttribute : AuthorizeAttribute
    {
        private CadastrosContext context = new CadastrosContext();

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (Authorize(actionContext))
            {
                return;
            }

            HandleUnauthorizedRequest(actionContext);
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            base.HandleUnauthorizedRequest(actionContext);
        }

        private bool Authorize(HttpActionContext actionContext)
        {
            try
            {
                if (actionContext.Request.Headers.Contains("token"))
                {
                    bool tokenvalido = false;

                    var token = actionContext.Request.Headers.GetValues("token").First();
                    if (!string.IsNullOrEmpty(token))
                    {
                        Guid guid = new Guid(token);
                        tokenvalido = (context.Usuarios.Where(r => r.Token == guid).Count() > 0);
                    }

                    return tokenvalido;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}