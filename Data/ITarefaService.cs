using System.Collections.Generic;

namespace ControleTarefas.Data
{
    interface ITarefaService
    {
        List<Tarefa> GetTarefas();

        Tarefa GetTarefa(int id);

        string GravaTarefa(Tarefa tarefa);

        void DeleteTarefa(int id);
    }
}
