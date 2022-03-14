using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ControleTarefas.Data
{
    public class Tarefa : ITarefa1
    {
        public int Id_Tarefa { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Título deve possuir até 50 caracteres")]
        public string? ds_Titulo { get; set; }
        [Required]
        [StringLength(800, ErrorMessage = "Título deve possuir até 800 caracteres")]
        public string? ds_Descricao { get; set; }
        [Required]
        public DateTime dt_Tarefa { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Deve ser preenchida a hora de início da tarefa")]
        public string? hr_Inicio { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Deve ser preenchida a hora de término da tarefa")]
        public string? hr_Fim { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Deve ser selecionado o nível de prioridade")]
        public string? cd_Prioridade { get; set; }
        [Required]
        [StringLength(1, ErrorMessage = "Deve ser marcado se a tarefa foi finalizada")]
        public string? tp_Finalizada { get; set; }
    }
}
