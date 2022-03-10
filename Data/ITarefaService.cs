using System.Collections.Generic;

namespace ControleTarefas.Data
{
    interface ITarefaService
    {
        List<Tarefa> GetTarefas();

        Tarefa GetTarefa(int id);

        void UpdateTarefa(Tarefa tarefa);

        void AddTarefa(Tarefa tarefa);
        
        void DeleteTarefa(int id);
    }
}
