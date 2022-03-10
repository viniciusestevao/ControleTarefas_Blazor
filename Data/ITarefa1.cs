
namespace ControleTarefas.Data
{
    public interface ITarefa1
    {
        string cd_Prioridade { get; set; }
        string ds_Descricao { get; set; }
        string ds_Titulo { get; set; }
        DateTime dt_Tarefa { get; set; }
        string hr_Fim { get; set; }
        string hr_Inicio { get; set; }
        int Id_Tarefa { get; set; }
        string tp_Finalizada { get; set; }
    }
}