using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

[Route("filmes")]
[ApiController]
public class FilmesController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            List<Filme> result = await FilmeRepository.FindAll();
            return Ok(result);
        }
        catch (Exception e)
        {
             Console.WriteLine(e);
             return BadRequest();
        }
    }
}