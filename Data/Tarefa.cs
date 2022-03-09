namespace ControleTarefas.Data
{
    public class Tarefa
    {
        public Guid id_Tarefa { get; set; }
        public string ds_Titulo { get; set; }
        public string ds_Descricao { get; set; }
        public string dt_Tarefa { get; set; }
        public string hr_Inicio { get; set; }
        public string hr_Fim { get; set; }
        public string cd_Prioridade { get; set; }
        public Boolean tp_Finalizada { get; set; }
    }
}
