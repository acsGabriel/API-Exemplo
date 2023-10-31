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

        private readonly IAlunoInfantilService<AlunoInfantil> _alunoInfantilService;

        public AlunoInfantilController(ILogger<AlunoInfantilController> logger, IAlunoInfantilService<AlunoInfantil> alunoInfantilService)
        {
            _logger = logger;
            _alunoInfantilService = alunoInfantilService;
        }

        [HttpGet("GetAlunosInfantil")]
        public List<AlunoInfantil> Get()
        {
            return _alunoInfantilService.Get();
        }

        [HttpPost("PostAlunoInfantil")]
        public void Post(AlunoInfantil aluno)
        {
            _alunoInfantilService.Post(aluno);
        }

        [HttpPut("PutAlunoInfantil")]
        public void Put(AlunoInfantil aluno)
        {
            _alunoInfantilService.Put(aluno);
        }

        [HttpPatch("PatchAlunoInfantil")]
        public void Patch(AlunoInfantil aluno, string atributo)
        {
            _alunoInfantilService.Patch(aluno, atributo);
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
            return _alunoInfantilService.FirstStudentByAno(ano);
        }
    }
}
