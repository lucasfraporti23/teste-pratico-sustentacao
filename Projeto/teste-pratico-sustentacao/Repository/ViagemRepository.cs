using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using teste_pratico_sustentacao.Models;

namespace teste_pratico_sustentacao.Repository
{
    public class ViagemRepository
    {

        public void DeleteById(int id)
        {
            var sql = "DELETE VIAGEM WHERE ID=:ID";

            using (var conn = new AcessoBanco().Conexao)
            {
                conn.Open();
                using (var cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("ID", id));
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
        }
        public List<ViagemAuxiliar> GetAll(string filtro = "")
        {
            var sql = @$"SELECT V.Id, V.DATAVIAGEM, V.LOCALENTREGA, V.LOCALSAIDA, V.KM,(M.NOME ||' '|| M.SOBRENOME) NOME, M.PLACA, V.MOTORISTAID  FROM VIAGEM V
                         INNER JOIN MOTORISTA M ON M.ID = V.MOTORISTAID
               WHERE DATAVIAGEM   LIKE '%{filtro}%'
                  OR LOCALENTREGA LIKE '%{filtro}%'
                  OR LOCALSAIDA   LIKE '%{filtro}%'
                  OR KM           LIKE '%{filtro}%'
                  OR NOME         LIKE '%{filtro}%'
                  OR PLACA        LIKE '%{filtro}%' ORDER BY ID";

            var listaViagem = new List<ViagemAuxiliar>();

            using (var conn = new AcessoBanco().Conexao)
            {
                conn.Open();
                using (var cmd = new OracleCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var viagem = new ViagemAuxiliar();
                            viagem.Id = Convert.ToInt32(reader["ID"].ToString());
                            viagem.DataViagem = Convert.ToDateTime(reader["DATAVIAGEM"].ToString());
                            viagem.LocalEntrega = reader["LOCALENTREGA"].ToString();
                            viagem.LocalSaida = reader["LOCALSAIDA"].ToString();
                            viagem.Km = Convert.ToInt32(reader["KM"].ToString());
                            viagem.Nome = reader["NOME"].ToString();
                            viagem.Placa = reader["PLACA"].ToString();
                            viagem.MotoristaId = Convert.ToInt32(reader["MOTORISTAID"].ToString());

                            listaViagem.Add(viagem);
                        }
                        conn.Close();
                    }
                }
            }
            return listaViagem;
        }
        public ViagemAuxiliar GetById(int id)
        {
            var sql = @$"SELECT V.ID, V.DATAVIAGEM, V.LOCALENTREGA, V.LOCALSAIDA, V.KM, (M.NOME ||' '|| M.SOBRENOME) NOME, M.PLACA, V.MOTORISTAID  FROM VIAGEM V
                         INNER JOIN MOTORISTA M ON M.ID = V.MOTORISTAID WHERE V.ID = :ID";
            var viagem = new ViagemAuxiliar();

            using (var conn = new AcessoBanco().Conexao)
            {
                conn.Open();
                using (var cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("ID", id));
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            viagem.Id = Convert.ToInt32(reader["ID"].ToString());
                            viagem.DataViagem = Convert.ToDateTime(reader["DATAVIAGEM"].ToString());
                            viagem.LocalEntrega = reader["LOCALENTREGA"].ToString();
                            viagem.LocalSaida = reader["LOCALSAIDA"].ToString();
                            viagem.Km = Convert.ToInt32(reader["KM"].ToString());
                            viagem.Nome = reader["NOME"].ToString();
                            viagem.Placa = reader["PLACA"].ToString();
                            viagem.MotoristaId = Convert.ToInt32(reader["MOTORISTAID"].ToString());

                        }
                        conn.Close();
                    }
                }
            }
            return viagem;
        }
        public void Save(Viagem entity)
        {
            using (var conn = new AcessoBanco().Conexao)
            {
                string sql = "INSERT INTO VIAGEM (DATAVIAGEM, LOCALENTREGA, LOCALSAIDA, KM, MOTORISTAID) VALUES (:DATAVIAGEM, :LOCALENTREGA, :LOCALSAIDA, :KM, :MOTORISTAID)";
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add(new OracleParameter("DATAVIAGEM", entity.DataViagem));
                cmd.Parameters.Add(new OracleParameter("LOCALENTREGA", entity.LocalEntrega));
                cmd.Parameters.Add(new OracleParameter("LOCALSAIDA", entity.LocalSaida));
                cmd.Parameters.Add(new OracleParameter("KM", entity.Km));
                cmd.Parameters.Add(new OracleParameter("MOTORISTAID", entity.MotoristaId));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public void Update(Viagem entity)
        {
            using (var conn = new AcessoBanco().Conexao)
            {
                string sql = @"UPDATE VIAGEM SET DATAVIAGEM=:DATAVIAGEM, LOCALENTREGA=:LOCALENTREGA, LOCALSAIDA=:LOCALSAIDA, KM=:KM, MOTORISTAID=:MOTORISTAID WHERE ID=:ID";
                OracleCommand cmd = new OracleCommand(sql, conn);

                cmd.Parameters.Add(new OracleParameter("DATAVIAGEM", entity.DataViagem));
                cmd.Parameters.Add(new OracleParameter("LOCALENTREGA", entity.LocalEntrega));
                cmd.Parameters.Add(new OracleParameter("LOCALSAIDA", entity.LocalSaida));
                cmd.Parameters.Add(new OracleParameter("KM", entity.Km));
                cmd.Parameters.Add(new OracleParameter("MOTORISTAID", entity.MotoristaId));
                cmd.Parameters.Add(new OracleParameter("ID", entity.Id));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public bool MotoristaValido(int motoristaId)
        {
            var sql = "SELECT COUNT(1) QTD FROM MOTORISTA WHERE ID = :ID";
            var retorno = false;

            using (var conn = new AcessoBanco().Conexao)
            {
                conn.Open();
                using (var cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("ID", motoristaId));
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var quantidade = Convert.ToInt32(reader["QTD"].ToString());
                            retorno = (quantidade > 0);
                        }
                        conn.Close();
                    }
                }
            }

            return retorno;
        }
    }
}

