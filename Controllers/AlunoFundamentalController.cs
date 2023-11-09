using API_Exemplo.Interfaces.Services;
using API_Exemplo.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Exemplo.Controllers
{
    [ApiController]
    [Route("[Controller]")] //FAZ A CONEXÃO COM O SERVIDOR WEB
    public class AlunoFundamentalController : ControllerBase
    {
        //INJEÇÃO DE DEPENDÊNCIAS
        private readonly ILogger<AlunoFundamentalController> _logger;

        private readonly IAlunoFundamentalService<AlunoFundamental> _alunoFundamentalService;

        public AlunoFundamentalController(ILogger<AlunoFundamentalController> logger, IAlunoFundamentalService<AlunoFundamental> alunoFundamentalService)
        {
            _logger = logger;
            _alunoFundamentalService = alunoFundamentalService;

        }

        //METODOS
        [HttpGet("GetAlunosFundamental")]
        public List<AlunoFundamental> Get() 
        {
            return _alunoFundamentalService.Get();
        }

        [HttpPost("PostAlunoFundamental")]
        public void Post(AlunoFundamental aluno) 
        {
            _alunoFundamentalService.Post(aluno);
        }

        [HttpDelete("DeleteAlunoFundamental")]
        public void Delete(string nome)
        {
            _alunoFundamentalService.Delete(nome);
        }

        [HttpPut("PutAlunoFundamental")]
        public void Put(AlunoFundamental aluno) 
        {
            _alunoFundamentalService.Put(aluno);
        }

        [HttpPatch("PatchAlunoFundamental")]
        public void Patch(AlunoFundamental aluno , string atributo)
        {
            _alunoFundamentalService.Patch(aluno , atributo);
        }

        [HttpGet]
        [Route("GetSelectedAlunosFundamental")]
        public List<AlunoFundamental> GetSelectedAlunos(int ano)
        {
            return _alunoFundamentalService.GetSelectedAlunos(ano);
        }

        [HttpGet]
        [Route("Names")]
        public List<string> Names()
        {
            return _alunoFundamentalService.Names();
        }

        [HttpGet]
        [Route("FirstStudent")]
        public AlunoFundamental FirstStudent(int ano) 
        {
            return _alunoFundamentalService.FirstStudentByAno(ano);  
        }

    }
}
