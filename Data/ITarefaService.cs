using System.Collections.Generic;

namespace ControleTarefas.Data
{
    interface ITarefaService
    {
        List<Tarefa> GetTarefas();

        Tarefa GetTarefa(Guid id);

        void UpdateTarefa(Tarefa tarefa);

        void AddTarefa(Tarefa tarefa);
        
        void DeleteTarefa(Guid id);
    }
}
