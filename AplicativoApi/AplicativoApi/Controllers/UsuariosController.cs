using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Threading.Tasks;
using Plugin.Controllers;
using PluginApi.Models;
using System.Data.Entity;
using AplicativoApi.Models;
using System.Web.Http.Description;

namespace PluginApi.Controllers
{
    public class UsuariosController : ApiController
    {
        private UsuariosContext context = new UsuariosContext();

        public IEnumerable<Usuarios> Get(string todos)
        {
            return context.Usuario;
        }

        [APIAuthorize]
        public IEnumerable<UsuariosDTO> Get()
        {
            return context.Usuario.Select(r => new UsuariosDTO()
            {
                Nome = r.Nome,
                Email = r.Email,
            });
        }

        [APIAuthorize]
        public Usuarios Get(int id)
        {
            return context.Usuario.Find(id);
        }
        [ResponseType(typeof(AutentificacaoDTO))]
        public async Task<IHttpActionResult> Get(string Email, string Senha)
        {

            var usuario = await context.Usuario.Where(r => r.Email == Email && r.Senha == Senha).FirstOrDefaultAsync();

            if (usuario == null)
            {
                return NotFound();
            }
            var retorno = new AutentificacaoDTO()
            {
                id = usuario.id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Token = usuario.Token
            };

            return Ok(retorno);


        }


        public void Post([FromBody]Usuarios usuario)
        {
            usuario.Token = Guid.NewGuid();
            context.Usuario.Add(usuario);
            context.SaveChanges();
        }

        [APIAuthorize]
        public void Put([FromBody]Usuarios usuario)
        {
            context.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

       // [APIAuthorize]
       // public void Delete(int id)
       // {
        //    Artigo ArtigoRelacionado = context.Artigos.FirstOrDefault(a => a.idAutor == id);
         //   Comentario ComentarioRelacionado = context.Comentarios.FirstOrDefault(c => c.idAutor == id);

//            if (ArtigoRelacionado != null || ComentarioRelacionado != null)
  //              return;

    //        Usuario usuario = context.Usuarios.Find(id);
      //      context.Usuarios.Remove(usuario);
        //    context.SaveChanges();
        //}
    }

}

