using API_Exemplo.Interfaces.Services;
using API_Exemplo.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Exemplo.Controllers
{
    [ApiController]
    [Route("[Controller]")] //FAZ A CONEXÃO COM O SERVIDOR WEB
    public class AlunoInfantilController : ControllerBase
    {
        private readonly ILogger<AlunoInfantilController> _logger;

        private readonly IAlunoInfantilService _alunoInfantilService;

        public AlunoInfantilController(ILogger<AlunoInfantilController> logger, IAlunoInfantilService alunoInfantilService)
        {
            _logger = logger;
            _alunoInfantilService = alunoInfantilService;

        }

        [HttpGet("GetAlunosInfantil")]
        public List<AlunoInfantil> Get()
        {
            return _alunoInfantilService.Get();
        }

        [HttpPost("PostAlunosInfantil")]
        public void Post(AlunoInfantil aluno)
        {
            _alunoInfantilService.Post(aluno);
        }

        [HttpPut("PutAlunoInfantil")]
        public bool Put(AlunoInfantil aluno)
        {
            _alunoInfantilService.Put(aluno);
            return true;
        }

        [HttpPatch("PatchAlunoInfantil")]
        public bool Patch(AlunoInfantil aluno, string atributo)
        {
            _alunoInfantilService.Patch(aluno, atributo);
            return true;
        }

        [HttpDelete("DeleteAlunoInfantil")]
        public void Delete(string nome)
        {
            _alunoInfantilService.Delete(nome);
        }

        [HttpGet]
        [Route("GetSelectedAlunosInfantil")]
        public List<AlunoInfantil> GetSelectedAlunos(int ano)
        {
            return _alunoInfantilService.GetSelectedAlunos(ano);
        }

        [HttpGet]
        [Route("Names")]
        public List<string> Names()
        {
            return _alunoInfantilService.Names();
        }

        [HttpGet]
        [Route("FirstStudent")]
        public AlunoInfantil FirstStudent(int ano)
        {
            return _alunoInfantilService.FirstStudent(ano);
        }
    }
}
