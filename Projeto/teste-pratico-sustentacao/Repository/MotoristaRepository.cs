using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using teste_pratico_sustentacao.Models;

namespace teste_pratico_sustentacao.Repository
{
    public class MotoristaRepository
    {
        public void DeleteById(int id)
        {
            var sql = "DELETE MOTORISTA WHERE ID=:ID";

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
        public List<Motorista> GetAll(string filtro = "")
        {
            var sql = @$"SELECT ID, NOME, SOBRENOME, MARCA, MODELO, PLACA, EIXOS, RUA, NUMERO, CIDADE, ESTADO, CEP, PAIS  FROM MOTORISTA
            WHERE NOME      LIKE '%{filtro}%'
               OR SOBRENOME LIKE '%{filtro}%'
               OR MARCA     LIKE '%{filtro}%'
               OR MODELO    LIKE '%{filtro}%'
               OR PLACA     LIKE '%{filtro}%'
               OR EIXOS     LIKE '%{filtro}%'
               OR RUA       LIKE '%{filtro}%'
               OR NUMERO    LIKE '%{filtro}%'
               OR CIDADE    LIKE '%{filtro}%'
               OR ESTADO    LIKE '%{filtro}%'
               OR CEP       LIKE '%{filtro}%'
               OR PAIS      LIKE '%{filtro}%' ORDER BY ID";
            var listaMotorista = new List<Motorista>();

            using (var conn = new AcessoBanco().Conexao)
            {
                conn.Open();
                using (var cmd = new OracleCommand(sql, conn))
                {

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var motorista = new Motorista();
                            motorista.Id = Convert.ToInt32(reader["ID"].ToString());
                            motorista.Nome = reader["NOME"].ToString();
                            motorista.Sobrenome = reader["SOBRENOME"].ToString();
                            motorista.Marca = reader["MARCA"].ToString();
                            motorista.Modelo = reader["MODELO"].ToString();
                            motorista.Placa = reader["PLACA"].ToString();
                            if (reader["EIXOS"].ToString() != "")
                                motorista.Eixos = Convert.ToInt32(reader["EIXOS"].ToString());
                            else
                                motorista.Eixos = 0;
                            motorista.Rua = reader["RUA"].ToString();
                            motorista.Numero = reader["NUMERO"].ToString();
                            motorista.Cidade = reader["CIDADE"].ToString();
                            motorista.Estado = reader["ESTADO"].ToString();
                            motorista.CEP = reader["CEP"].ToString();
                            motorista.Pais = reader["PAIS"].ToString();

                            listaMotorista.Add(motorista);
                        }
                        conn.Close();
                    }
                }
            }
            return listaMotorista;
        }
        public Motorista GetById(int id)
        {
            var sql = "SELECT ID, NOME, SOBRENOME, MARCA, MODELO, PLACA, EIXOS, RUA, NUMERO, CIDADE, ESTADO, CEP, PAIS FROM MOTORISTA WHERE ID = :ID";
            var motorista = new Motorista();

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
                            motorista.Id = Convert.ToInt32(reader["ID"].ToString());
                            motorista.Nome = reader["NOME"].ToString();
                            motorista.Sobrenome = reader["SOBRENOME"].ToString();
                            motorista.Marca = reader["MARCA"].ToString();
                            motorista.Modelo = reader["MODELO"].ToString();
                            motorista.Placa = reader["PLACA"].ToString();
                            if (reader["EIXOS"].ToString() != "")
                                motorista.Eixos = Convert.ToInt32(reader["EIXOS"].ToString());
                            else
                                motorista.Eixos = 0; motorista.Rua = reader["RUA"].ToString();
                            motorista.Numero = reader["NUMERO"].ToString();
                            motorista.Cidade = reader["CIDADE"].ToString();
                            motorista.Estado = reader["ESTADO"].ToString();
                            motorista.CEP = reader["CEP"].ToString();
                            motorista.Pais = reader["PAIS"].ToString();

                        }
                        conn.Close();
                    }
                }
            }
            return motorista;
        }
        public void Save(Motorista entity)
        {
            using (var conn = new AcessoBanco().Conexao)
            {
                string sql = "INSERT INTO MOTORISTA ( NOME, SOBRENOME, MARCA, MODELO, PLACA, EIXOS, RUA, NUMERO, CIDADE, ESTADO, CEP, PAIS) VALUES (:NOME, :SOBRENOME, :MARCA, :MODELO, :PLACA, :EIXOS, :RUA, :NUMERO, :CIDADE, :ESTADO, :CEP, :PAIS)";
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add(new OracleParameter("NOME", entity.Nome));
                cmd.Parameters.Add(new OracleParameter("SOBRENOME", entity.Sobrenome));
                cmd.Parameters.Add(new OracleParameter("MARCA", entity.Marca));
                cmd.Parameters.Add(new OracleParameter("MODELO", entity.Modelo));
                cmd.Parameters.Add(new OracleParameter("PLACA", entity.Placa));
                cmd.Parameters.Add(new OracleParameter("EIXOS", entity.Eixos));
                cmd.Parameters.Add(new OracleParameter("RUA", entity.Rua));
                cmd.Parameters.Add(new OracleParameter("NUMERO", entity.Numero));
                cmd.Parameters.Add(new OracleParameter("CIDADE", entity.Cidade));
                cmd.Parameters.Add(new OracleParameter("ESTADO", entity.Estado));
                cmd.Parameters.Add(new OracleParameter("CEP", entity.CEP));
                cmd.Parameters.Add(new OracleParameter("PAIS", entity.Pais));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public void Update(Motorista entity)
        {
            using (var conn = new AcessoBanco().Conexao)
            {
                string sql = @"UPDATE MOTORISTA SET NOME=:NOME, SOBRENOME=:SOBRENOME, MARCA=:MARCA, MODELO=:MODELO, PLACA=:PLACA, EIXOS=:EIXOS, RUA=:RUA, NUMERO=:NUMERO, CIDADE=:CIDADE, 
                                                    ESTADO=:ESTADO, CEP=:CEP, PAIS=:PAIS WHERE ID=:ID";
                OracleCommand cmd = new OracleCommand(sql, conn);

                cmd.Parameters.Add(new OracleParameter("NOME", entity.Nome));
                cmd.Parameters.Add(new OracleParameter("SOBRENOME", entity.Sobrenome));
                cmd.Parameters.Add(new OracleParameter("MARCA", entity.Marca));
                cmd.Parameters.Add(new OracleParameter("MODELO", entity.Modelo));
                cmd.Parameters.Add(new OracleParameter("PLACA", entity.Placa));
                cmd.Parameters.Add(new OracleParameter("EIXOS", entity.Eixos));
                cmd.Parameters.Add(new OracleParameter("RUA", entity.Rua));
                cmd.Parameters.Add(new OracleParameter("NUMERO", entity.Numero));
                cmd.Parameters.Add(new OracleParameter("CIDADE", entity.Cidade));
                cmd.Parameters.Add(new OracleParameter("ESTADO", entity.Estado));
                cmd.Parameters.Add(new OracleParameter("CEP", entity.CEP));
                cmd.Parameters.Add(new OracleParameter("PAIS", entity.Pais));
                cmd.Parameters.Add(new OracleParameter("ID", entity.Id));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public bool VerificarPlacaRepetida(string placa)
        {
            var sql = "SELECT COUNT(1) QTD FROM MOTORISTA WHERE PLACA = :PLACA";
            var retorno = false;

            using (var conn = new AcessoBanco().Conexao)
            {
                conn.Open();
                using (var cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("PLACA", placa));
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
        public bool VerificarMotoristaEmViagem(int id)
        {
            var sql = "SELECT COUNT(1) QTD FROM VIAGEM WHERE MOTORISTAID = :MOTORISTAID";
            var retorno = false;

            using (var conn = new AcessoBanco().Conexao)
            {
                conn.Open();
                using (var cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("MOTORISTAID", id));
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
