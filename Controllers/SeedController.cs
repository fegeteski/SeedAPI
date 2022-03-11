using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Models.Context;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        public readonly SeedDbContext dbContext;

        public SeedController(SeedDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(dbContext.Seed);
        }


        [HttpPost]
        public async Task<IActionResult> Post(Seed seed)
        {
            dbContext.Add(seed);
            dbContext.SaveChanges();
            return Ok(seed);

        }

        [HttpPost("SalvarLista")]
        public IActionResult SalvarLista(List<Seed> listOfSeed)
        {
            dbContext.AddRange(listOfSeed);
            dbContext.SaveChanges();
            return Ok(listOfSeed);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(long id)
        {
            var retorno = dbContext.Seed.Find(id);
            return Ok(retorno);
        }

        [HttpGet("GetByType/{Type}")]
        public async Task<IActionResult> GetByType(string type)
        {
            var retorno = dbContext.Seed.Where(x => x.Type == type).ToList();
            return Ok(retorno);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var retorno = dbContext.Seed.Find(id);
            dbContext.Seed.Remove(retorno);
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("DeleteAll")]
        public async Task<IActionResult> DeleteAll()
        {
            var deleteAll = dbContext.Seed.ToList();
            dbContext.Seed.RemoveRange(deleteAll);
            dbContext.SaveChanges();
            return Ok();
        }



        //[HttpPost("Processamento_de_dados")]
        //public IActionResult Processamento_de_dados(List<Seed> lista_de_sementes)
        //{

        //    var num_good =
        //    from s in lista_de_sementes
        //    where ((s.Level) < 1 && (s.Status) == "Good")
        //    select s;

        //    int num_vezes_good = num_good.Count();

        //    var num_ready =
        //    from s in lista_de_sementes
        //    where ((s.Level) == 1)
        //    select s;

        //    int num_vezes_ready = num_ready.Count();

        //    var num_bad =
        //    from s in lista_de_sementes
        //    where ((s.Status) == "Bad")
        //    select s;

        //    int num_vezes_bad = num_bad.Count();

        //    string resultados = ($"Dados Enviados com sucesso \n Sementes Boas: {num_vezes_good}. " +
        //                         $"\n Sementes Ruins: {num_vezes_bad}. \n Sementes Prontas: {num_vezes_ready}.");

        //    return Ok(resultados);
        //}

    }


}

