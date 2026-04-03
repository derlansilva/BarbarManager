using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;

namespace Barbermanager.Models
{
    internal class DataBaseConfig
    {

        private static string dbPath = "Data Source=barberManaus.db";


        public static void InicializeBanco()
        {
            using (var connection = new SqliteConnection(dbPath))
            {
                connection.Open();

                var command = connection.CreateCommand();

                // Script para criar as tabelas iniciais
                command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Clientes (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nome TEXT NOT NULL,
                        Telefone TEXT
                    );

                    CREATE TABLE IF NOT EXISTS Servicos (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nome TEXT NOT NULL,
                        Preco REAL ,
                        Tempo TEXT 
                    );

                    CREATE TABLE IF NOT EXISTS Agendamentos (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        ClienteId INTEGER,
                        ServicoId INTEGER,
                        Data TEXT,
                        Horario TEXT,
                        Status TEXT DEFAULT 'Aguardando Confirmação',
                        FOREIGN KEY(ClienteId) REFERENCES Clientes(Id),
                        FOREIGN KEY(ServicoId) REFERENCES Servicos(Id)
                    );
                
                CREATE TABLE IF NOT EXISTS HorariosPadrao (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Hora TEXT NOT NULL UNIQUE
                );
                     ";

                command.ExecuteNonQuery();

                PopularHorariosIniciais(connection);
            }
        }

        // Método auxiliar para pegar a conexão em outras telas
        public static SqliteConnection GetConnection()
        {
            return new SqliteConnection(dbPath);
        }

        private static void PopularHorariosIniciais(SqliteConnection connection)
        {
            // Verifica se já existem horários para não duplicar
            var checkCmd = connection.CreateCommand();
            checkCmd.CommandText = "SELECT COUNT(*) FROM HorariosPadrao";
            long count = (long)checkCmd.ExecuteScalar();

            if (count == 0)
            {
                string[] horas = { "08:00", "09:00", "10:00", "11:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00" };
                foreach (var h in horas)
                {
                    var insertCmd = connection.CreateCommand();
                    insertCmd.CommandText = "INSERT INTO HorariosPadrao (Hora) VALUES (@hora)";
                    insertCmd.Parameters.AddWithValue("@hora", h);
                    insertCmd.ExecuteNonQuery();
                }
            }
        }


    }
}
