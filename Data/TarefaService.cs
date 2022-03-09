using System.Collections.Generic;

namespace ControleTarefas.Data
{
    public class TarefaService: ITarefaService
    {
        private List<Tarefa> tarefas = new List<Tarefa>
        {
            new Tarefa
            {
                id_Tarefa = Guid.NewGuid(),
                ds_Titulo = "Tarefa 01"
            },
            new Tarefa
            {
                id_Tarefa = Guid.NewGuid(),
                ds_Titulo = "Tarefa 02"
            }
        };

       public List<Tarefa> GetTarefas()
        {
            return tarefas;
        }

        public Tarefa GetTarefa(Guid id)
        {
            return tarefas.SingleOrDefault(x => x.id_Tarefa == id);
        }

        public void UpdateTarefa(Tarefa tarefa)
        {
            var getOldTarefa = GetTarefa(tarefa.id_Tarefa);
            getOldTarefa.ds_Titulo = tarefa.ds_Titulo;
            getOldTarefa.ds_Descricao = tarefa.ds_Descricao;
            getOldTarefa.dt_Tarefa = tarefa.dt_Tarefa;
            getOldTarefa.hr_Inicio = tarefa.hr_Inicio;
            getOldTarefa.hr_Fim = tarefa.hr_Fim;
            getOldTarefa.tp_Finalizada = tarefa.tp_Finalizada;
        }

        public void AddTarefa(Tarefa tarefa)
        {
            var id = Guid.NewGuid();
            tarefa.id_Tarefa = id;
            tarefas.Add(tarefa);
        }

        public void DeleteTarefa(Guid id)
        {
            var tarefa = GetTarefa(id);
            tarefas.Remove(tarefa);
        }

    }
}
