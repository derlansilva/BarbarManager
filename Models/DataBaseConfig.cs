using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;

namespace Barbermanager.Models
{
    internal class DataBaseConfig
    {

        private static string dbPath = "Data Source=barbearia.db";


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
                    );";

                command.ExecuteNonQuery();
            }
        }

        // Método auxiliar para pegar a conexão em outras telas
        public static SqliteConnection GetConnection()
        {
            return new SqliteConnection(dbPath);
        }

    }
}
