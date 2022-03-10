using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleTarefas.Data
{
    public class Tarefa : ITarefa1
    {
        public int Id_Tarefa { get; set; }
        public string ds_Titulo { get; set; }
        public string ds_Descricao { get; set; }
        public DateTime dt_Tarefa { get; set; }
        public string hr_Inicio { get; set; }
        public string hr_Fim { get; set; }
        public string cd_Prioridade { get; set; }
        public string tp_Finalizada { get; set; }
    }
}
