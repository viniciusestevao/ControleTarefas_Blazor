using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace ControleTarefas.Data
{
    public class TarefaService: ITarefaService
    {
        private List<Tarefa> tarefas = new List<Tarefa>
        {

        };

       public List<Tarefa> GetTarefas()
        {
            using (AcessoConexao con = new AcessoConexao())
            {
                if (con.Conectar() == true)
                {
                    con.Comando.CommandText = "SELECT * FROM TBL_TAREFA ";

                    SqlDataReader reader = con.EfetuarPesquisa();
                    if (reader != null)
                    { 
                        while (reader.Read())
                        {
                            Tarefa t = null;
                            CarregarDados(ref reader, ref t);
                            tarefas.Add(t);
                            t = null;
                        }
                        reader.Close();
                        reader.Dispose();
                        reader = null;
                    }
                    

                    if (tarefas.Count.Equals(0))
                    {
                        return new List<Tarefa>{
                                new Tarefa() 
                            };
                    }
                }
                else
                {
                    return new List<Tarefa>();
                }
            }
             return tarefas;
        }

        private void CarregarDados(ref SqlDataReader reader, ref Tarefa tarefa)
        {
            tarefa = new Tarefa();
            tarefa.Id_Tarefa = Convert.ToSByte(reader["id_Tarefa"]);
            tarefa.ds_Titulo = reader["ds_Titulo"].ToString();
            tarefa.ds_Descricao = reader["ds_Descricao"].ToString().Trim();
            tarefa.dt_Tarefa = Convert.ToDateTime(reader["dt_Tarefa"]);
            tarefa.hr_Inicio = Convert.ToString(reader["hr_Inicio"]);
            tarefa.hr_Fim = Convert.ToString(reader["hr_Inicio"]);
            tarefa.cd_Prioridade = reader["cd_Prioridade"].ToString().Trim();
            tarefa.tp_Finalizada = Convert.ToString(reader["tp_Finalizada"]);
        }

        public void UpdateTarefa(Tarefa item)
        {
            using (AcessoConexao con = new AcessoConexao())
            {
                if (con.Conectar() == true)
                {
                    //foreach (Tarefa item in tarefas)
                    //{
                        con.Comando.CommandText = "update tab_Tarefa set ds_Titulo=@dsTitulo, ds_Descricao=@dsDescricao, dt_Tarefa=@dtTarefa, hr_Inicio=@hrInicio, hr_Fim=@hrFim, cd_Prioridade=@cdPrioridade, tp_Finalizada=@tpFinalizada where id_Tarefa=@idTarefa";
                        con.AdicionarParametros("@idTarefa", item.Id_Tarefa, System.Data.SqlDbType.Int);
                        con.AdicionarParametros("@dsTitulo", item.ds_Titulo, System.Data.SqlDbType.VarChar);
                        con.AdicionarParametros("@dsDescricao", item.ds_Descricao, System.Data.SqlDbType.VarChar);
                        con.AdicionarParametros("@dtTarefa", item.dt_Tarefa, System.Data.SqlDbType.DateTime);
                        con.AdicionarParametros("@hrInicio", item.hr_Inicio, System.Data.SqlDbType.Time);
                        con.AdicionarParametros("@hrFim", item.hr_Fim, System.Data.SqlDbType.Time);
                        con.AdicionarParametros("@cdPrioridade", item.cd_Prioridade, System.Data.SqlDbType.VarChar);
                        con.AdicionarParametros("@tpFinalizada", item.tp_Finalizada, System.Data.SqlDbType.Int);

                        if (con.ExecutarComando() == false)
                        {
                         //   return false;
                        }
                        con.LimparParametros();
                    //}
                }
            }
        }

        public Tarefa GetTarefa(int id)
        {
            return tarefas.SingleOrDefault(x => x.Id_Tarefa == id);
        }

        public void AddTarefa(Tarefa tarefa)
        {
            tarefas.Add(tarefa);
        }

        public void DeleteTarefa(int id)
        {
            using (AcessoConexao con = new AcessoConexao())
            {
                if (con.Conectar() == true)
                {
                    con.Comando.CommandText = "delete tab_Tarefa where id_Tarefa=@idTarefa";
                    con.AdicionarParametros("@idTarefa", id, System.Data.SqlDbType.Int);

                    if (con.ExecutarComando() == false)
                    {
                      //  return false;
                    }
                    con.LimparParametros();

                    var tarefa = GetTarefa(id);
                    tarefas.Remove(tarefa);
                }

            }
        }

     
    }
}
