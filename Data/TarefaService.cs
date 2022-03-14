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
                    con.Comando.CommandText = "SELECT * FROM TAB_TAREFA";

                    SqlDataReader reader = con.EfetuarPesquisa();
                    if (reader != null)
                    {
                        tarefas = new List<Tarefa>();

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
           // tarefa.dt_Tarefa = reader["dt_Tarefa"] == DBNull.Value ? null : (DateTime)reader["dt_Tarefa"];
            tarefa.dt_Tarefa = (DateTime)reader["dt_Tarefa"];
            tarefa.hr_Inicio = Convert.ToString(reader["hr_Inicio"]);
            tarefa.hr_Fim = Convert.ToString(reader["hr_Inicio"]);
            tarefa.cd_Prioridade = reader["cd_Prioridade"].ToString().Trim();
            tarefa.tp_Finalizada = Convert.ToString(reader["tp_Finalizada"]);
        }

        public string GravaTarefa(Tarefa item)
        {
            using (AcessoConexao con = new AcessoConexao())
            {
                if (con.Conectar() == true)
                {
                    if (item.Id_Tarefa == 0)
                    {
                        con.Comando.CommandText = "insert into tab_Tarefa (ds_Titulo,ds_Descricao,dt_Tarefa,hr_Inicio,hr_Fim,cd_Prioridade,tp_Finalizada) values (@dsTitulo, @dsDescricao, @dtTarefa, @hrInicio, @hrFim, @cdPrioridade, @tpFinalizada)";
                    }
                    else
                    {
                        con.Comando.CommandText = "update tab_Tarefa set ds_Titulo=@dsTitulo, ds_Descricao=@dsDescricao, dt_Tarefa=@dtTarefa, hr_Inicio=@hrInicio, hr_Fim=@hrFim, cd_Prioridade=@cdPrioridade, tp_Finalizada=@tpFinalizada where id_Tarefa=@idTarefa";
                    }

                    con.AdicionarParametros("@idTarefa", item.Id_Tarefa, System.Data.SqlDbType.Int);
                    con.AdicionarParametros("@dsTitulo", item.ds_Titulo, System.Data.SqlDbType.VarChar);
                    con.AdicionarParametros("@dsDescricao", item.ds_Descricao, System.Data.SqlDbType.VarChar);
                    if (item.dt_Tarefa == null) { item.dt_Tarefa = DateTime.Now; }
                    con.AdicionarParametros("@dtTarefa", Convert.ToDateTime(item.dt_Tarefa), System.Data.SqlDbType.DateTime);
                    con.AdicionarParametros("@hrInicio", item.hr_Inicio, System.Data.SqlDbType.VarChar);
                    con.AdicionarParametros("@hrFim", item.hr_Fim, System.Data.SqlDbType.VarChar);
                    con.AdicionarParametros("@cdPrioridade", item.cd_Prioridade, System.Data.SqlDbType.VarChar);
                    con.AdicionarParametros("@tpFinalizada", item.tp_Finalizada, System.Data.SqlDbType.VarChar);

                    if (con.ExecutarComando() == false)
                    {
                           return "Não foi possível gravar a tarefa !";
                    }
                    else
                    {
                        con.LimparParametros();
                        return "";
                    }
                }
            }
            return "Não foi possível gravar a tarefa !";
        }

        public Tarefa GetTarefa(int id)
        {
            return tarefas.SingleOrDefault(x => x.Id_Tarefa == id);
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
