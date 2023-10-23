using Swashbuckle.AspNetCore.SwaggerGen;

namespace API_Exemplo.Services
{
    public class AlunoService
    {
        public AlunoService() { }

        public void putAluno(Aluno aluno)
        {
            for (int i = 0; i < Aluno.alunos.Count; i++)
            {
                if (Aluno.alunos[i].nome == aluno.nome)
                {
                    Aluno.alunos[i] = aluno;
                }
            }
        }

        public void deleteAluno(string name)
        {
            for (int i = 0; i < Aluno.alunos.Count; i++)
            {
                if (Aluno.alunos[i].nome == name)
                {
                    Aluno.alunos.Remove(Aluno.alunos[i]);
                }
            }
        }

        public void patchAluno(Aluno aluno)
        {
            for (int i = 0; i < Aluno.alunos.Count; i++)
            {
                if (Aluno.alunos[i].nome == aluno.nome)
                {
                    if (Aluno.alunos[i].curso!= aluno.curso && aluno.periodo == 0)
                    {
                        Aluno.alunos[i].curso = aluno.curso;
                    }
                    else if (Aluno.alunos[i].periodo != aluno.periodo && aluno.curso == "string")
                    {
                        Aluno.alunos[i].periodo = aluno.periodo;
                    }
                }
            }
        }

        private void swap(Aluno[] sort , int menor , int i)
        {
            Aluno temp = sort[i];
            sort[i] = sort[menor];
            sort[menor] = temp;
        }

        public  List<Aluno> sortByName(List<Aluno> alunos) 
        {
            Aluno[] sort= alunos.ToArray();

            for(int i = 0; i < sort.Length - 1 ; i++)
            {
                int menor = i;
                for (int j = i + 1 ; j < sort.Length ; j++)
                {
                    if (sort[j].nome.CompareTo(sort[menor].nome) < 0)
                        menor = j;
                }
                swap(sort , menor , i);
            }

            alunos = sort.ToList();

            return alunos;
        }

        public  Aluno graduate(List<Aluno> alunos)
        {
            Aluno resp = alunos[0];

            for(int i = 0; i < alunos.Count; i++)
            {
                if (alunos[i].periodo > resp.periodo)
                {
                    resp = alunos[i];
                }

            }

            return resp;
        }

        public List<Aluno> getSelectedAlunos(string curso)
        {
            List<Aluno> alunosSelected = new List<Aluno>();

            for (int i = 0; i < Aluno.alunos.Count; i++)
            {
                if (Aluno.alunos[i].curso == curso)
                {
                    alunosSelected.Add(Aluno.alunos[i]);
                }
            }
            return alunosSelected;
        }
    }
}
