﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LocationVoitureApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LocationVoitureApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoitureController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Voiture>>> getAll()
        {
            using (var context = new projetContext())
            {
                return context.Voitures.Include("Locations").ToList();
            }
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<Voiture>> get(int id)
        {
            using (var context = new projetContext())
            {
                var a = await context.Voitures.FindAsync(id);
                if (a == null) 
                    return NotFound("Voiture not found"); 
                return Ok(a);
            }

        }

        [HttpPost]
        public async Task<ActionResult<List<Voiture>>> addAdmin(Voiture a)
        {
            using (var context = new projetContext())
            {
                context.Voitures.Add(a);
                await context.SaveChangesAsync();
                return Ok(context.Voitures.ToList());
            }

        }


        [HttpPut]
        public async Task<ActionResult<Voiture>> update(Voiture a)
        {
            using (var context = new projetContext())
            {
                context.Voitures.Update(a);
                await context.SaveChangesAsync();
                return Ok(a);
            }

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Voiture>>> delete(int id)
        {
            using (var context = new projetContext())
            {

                var a = await context.Voitures.FindAsync(id);
                if (a == null)
                    return NotFound("Voiture not found");
                
                context.Voitures.Remove(a);
                await context.SaveChangesAsync();
                return Ok(context.Voitures.ToList());
            }

        }

    }
}
