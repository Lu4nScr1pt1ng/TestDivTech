using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;
using TestDivTech.Data;
using TestDivTech.Models;

namespace TestDivTech.Controllers
{
    [Route("v1/[controller]")]
    public class FornecedorController : Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<Fornecedor>>> GetAll(
            [FromServices] DataContext context
            )
        {
            try
            {
                var fornecedores = await context.FORNECEDOR!.AsNoTracking().ToListAsync();
                return Ok(fornecedores);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocorreu um erro interno" });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Fornecedor>> GetOne(
            int id,
            [FromServices] DataContext context
            )
        {
            var fornecedor = await context.FORNECEDOR!.FindAsync(id);

            if(fornecedor == null)
            {
                return NotFound();
            }
            
            return Ok(fornecedor);
        }



        [HttpPost]
        public async Task<ActionResult<List<Fornecedor>>> Post(
            [FromServices] DataContext context,
            [FromBody] Fornecedor fornecedor
            )
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var cnpj = context.FORNECEDOR!.FirstOrDefault(x => x.cnpj == fornecedor.cnpj);
                if (cnpj != null)
                {
                    return BadRequest(new { message = "CNPJ já cadastrado" });
                }

                context.FORNECEDOR!.Add(fornecedor);
                await context.SaveChangesAsync();

                return Ok(fornecedor);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocorreu um erro interno" });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Fornecedor>> Put(
            int id,
            [FromServices] DataContext context,
            [FromBody] Fornecedor fornecedor
            )
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var fornecedorBase = context.FORNECEDOR.Find(id);
                
                if(fornecedorBase == null)
                {
                    return BadRequest(new { message = "Id não encontrado no banco de dados" });
                }

                if(fornecedor.cnpj != fornecedorBase.cnpj)
                {
                    return BadRequest(new { message = "O CNPJ não são iguais" });
                }

                fornecedorBase.cnpj = fornecedor.cnpj;
                fornecedorBase.nome = fornecedor.nome;
                fornecedorBase.especialidade = fornecedor.especialidade;

                try
                {
                    await context.SaveChangesAsync();
                } 
                catch(Exception ex)
                {
                    return BadRequest(new { message = "Ocorreu um erro interno" });
                }




                return Ok(fornecedorBase);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocorreu um erro interno" });
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Fornecedor>> Delete(
            int id,
            [FromServices] DataContext context
            )
        {
            var fornecedor = await context.FORNECEDOR!.FindAsync(id);

            if (fornecedor == null)
            {
                return NotFound();
            }

            context.FORNECEDOR!.Remove(fornecedor);

            try
            {

                await context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = "Ocorreu um erro interno" });
            }

            return NoContent();
        }




    }
}
