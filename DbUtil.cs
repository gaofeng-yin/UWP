using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace garraf 
{
    class DbUtil
    {
        static DbUtil instance = null;
        SQLiteConnection conn = null;
        private DbUtil()
        {
            // open connection
            this.conn = new SQLiteConnection(DbUtil.getDbPath());
            // init tables
            this.conn.CreateTable<Fornecedor>();
            this.conn.CreateTable<Encomenda>();
            this.conn.CreateTable<EncomendaDetalhe>();
            this.conn.CreateTable<Cliente>();
            this.conn.CreateTable<Reservas>();
            this.conn.CreateTable<Colaborador>();
            this.conn.CreateTable<Produto>();
            this.conn.CreateTable<TipoProduto>();
        }

        public static DbUtil getInstance()
        {
            if (instance == null)
            {
                instance = new DbUtil();
            }
            return instance;
        }

        public static string getDbPath()
        {
            return Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "database.db");
        }

        public SQLiteConnection getConnection()
        {
            return this.conn;
        }

    }
    
    public class Fornecedor
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public String Nome { get; set; }
        public override string ToString()
        {
            return this.Nome;
        }
    }

    public class TipoProduto
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public String Nome { get; set; }
        public override string ToString()
        {
            return this.Nome;
        }
    }

    public class Produto
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public String Nome { get; set; }
        public Double Preco { get; set; }
        public int IdTipo { get; set; }
        public override string ToString()
        {
            return this.Nome + "  " + this.Preco.ToString() + "€";
        }
    }
    
    public class Encomenda
    {
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public int FornecedorID { get; set; }
    public String Data { get; set; }
    }

    public class EncomendaDetalhe
    {
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public String NomeCliente { get; set; }
    public String Morada { get; set; }
    public int EncomendaID { get; set; }
    public int ProdutosID { get; set; }
    public double PrecoTotal { get; set; }
    public override string ToString()
    {
        return this.NomeCliente;
    }
    }

    // TODO
    public class Cliente
    {
    [PrimaryKey, AutoIncrement]
    public int IDCliente { get; set; }
    public String Nome { get; set; }
    public String Morada { get; set; }
    public int CodigPostal { get; set; }
    public int Telemovel { get; set; }
    }

    public class Reservas
    {
    [PrimaryKey, AutoIncrement]
    public int IdReserva { get; set; }
    public int NumeroMesa { get; set; }
    public String NomeCliente { get; set; }
    }
    
    public class Colaborador
    {
    [PrimaryKey, AutoIncrement]
    public int IdColaborador { get; set; }
    public String Genero { get; set; }
    }
}

  