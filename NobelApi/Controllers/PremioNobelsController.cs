using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using NobelApi.Models;

namespace NobelApi.Controllers
{
    /// <summary>
    /// Controlador para gerir a tabela PremioNobel
    /// </summary>
    public class PremioNobelsController : ApiController
    {
        private NobelEntities1 db = new NobelEntities1();
        /// <summary>
        /// Método para extrair a lista de Prémios Nobel
        /// </summary>
        /// <returns></returns>
        // GET: api/PremioNobels
        public IQueryable<PremioNobelDTO> GetPremioNobel()
        {
            return db.PremioNobel.Select(p => new PremioNobelDTO()
            {
                Ano = p.Ano,
                Categoria = new CategoriaDTO()
                {
                    CategoriaId = p.Categoria.CategoriaId,
                    Nome = p.Categoria.Nome
                },
                Motivacao = p.Motivacao,
                PremioNobelId = p.PremioNobelId,
                Titulo = p.Titulo
            }).OrderBy(p => p.Ano);
        }
        /// <summary>
        /// Método para recolher a informação específica de um Prémio Nobel {id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/PremioNobels/5
        [ResponseType(typeof(PremioNobel))]
        public IHttpActionResult GetPremioNobel(int id)
        {
            if (!PremioNobelExists(id))
            {
                return NotFound();
            }
            PremioNobelDetailsDTO premioNobel = db.PremioNobel
                .Include("Categoria").Include("Laureado")
                .Where(p => p.PremioNobelId == id).Select(p => new PremioNobelDetailsDTO()
                {
                    Ano = p.Ano,
                    Motivacao = p.Motivacao,
                    PremioNobelId = p.PremioNobelId,
                    Titulo = p.Titulo,
                    Categoria = new CategoriaDTO()
                    {
                        CategoriaId = p.Categoria.CategoriaId,
                        Nome = p.Categoria.Nome
                    },
                    Individuo = p.Laureado.Where(xxx => xxx.LaureadoTipo == "I").Select(r => new LaureadoIndividuoDTO()
                    {
                        DataMorte = r.LaureadoIndividuo.DataMorte,
                        DataNascimento = r.LaureadoIndividuo.DataNascimento,
                        LaureadoId = r.LaureadoId,
                        Nome = r.LaureadoIndividuo.Nome,
                        Sexo = r.LaureadoIndividuo.Sexo
                    }).ToList(),
                    Organizacao = p.Laureado.Where(xxx => xxx.LaureadoTipo == "O").Select(r => new LaureadoOrganizacaoDTO()
                    {
                        LaureadoId = r.LaureadoId,
                        Nome = r.LaureadoOrganizacao.Nome
                    }).ToList()
                }).FirstOrDefault();
            if (premioNobel == null)
            {
                return NotFound();
            }

            return Ok(premioNobel);
        }

        // PUT: api/PremioNobels/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutPremioNobel(int id, PremioNobel premioNobel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != premioNobel.PremioNobelId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(premioNobel).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PremioNobelExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/PremioNobels
        //[ResponseType(typeof(PremioNobel))]
        //public IHttpActionResult PostPremioNobel(PremioNobel premioNobel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.PremioNobel.Add(premioNobel);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = premioNobel.PremioNobelId }, premioNobel);
        //}

        // DELETE: api/PremioNobels/5
        //[ResponseType(typeof(PremioNobel))]
        //public IHttpActionResult DeletePremioNobel(int id)
        //{
        //    PremioNobel premioNobel = db.PremioNobel.Find(id);
        //    if (premioNobel == null)
        //    {
        //        return NotFound();
        //    }

        //    db.PremioNobel.Remove(premioNobel);
        //    db.SaveChanges();

        //    return Ok(premioNobel);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PremioNobelExists(int id)
        {
            return db.PremioNobel.Count(e => e.PremioNobelId == id) > 0;
        }
    }
}