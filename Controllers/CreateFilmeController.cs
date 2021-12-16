using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

[Route("filmes/create")]
[ApiController]
public class CreateFilmeController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post()
    {        
        using var reader = new StreamReader(HttpContext.Request.Body);

        var body = await reader.ReadToEndAsync();

        try
        {
            var filme = JsonConvert.DeserializeObject<Filme>(body);
            if(filme is null) return BadRequest("Preencha o filme corretamente");
            var result = await FilmeRepository.Create(filme);
            return Ok(result);
        }
        catch (Exception e)
        {
             Console.WriteLine(e);
             return BadRequest();
        }
    }
}