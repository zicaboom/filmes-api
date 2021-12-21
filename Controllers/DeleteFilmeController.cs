using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

[Route("filmes/delete")]
[ApiController]
public class DeleteFilmeController : ControllerBase
{
    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] string nome)
    {        
        if(!string.IsNullOrEmpty(nome)) return BadRequest("Preencha o nome corretamente");
        try
        {
            var result = await FilmeRepository.Delete(nome);
            return Ok(result);
        }
        catch (Exception e)
        {
             Console.WriteLine(e);
             return BadRequest();
        }
    }
}