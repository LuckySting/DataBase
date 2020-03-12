using System;

namespace DataBase
{
    /// <summary>
    /// Интерфейс описывает вывод информации от коннектора
    /// </summary>
    interface DataBaseOutput
    {
        /// <summary>
        /// Вводит информацию
        /// </summary>
        /// <param name="message">Сообщение для вывода</param>
        public void output(String message);
    }

    /// <summary>
    /// Интверфейс описывает взаимодействие с базой данных
    /// </summary>
    interface DataBaseConnector
    {
        /// <summary>
        /// Подключение к базе данных
        /// </summary>
        /// <param name="login">Логин для входа</param>
        /// <param name="pass">Пароль для входа</param>
        /// <param name="dbPath">Путь к серверу базы данных</param>
        /// <returns>Код ошибки</returns>
        public int connect(String login, String pass, String dbPath);

        /// <summary>
        /// Создать пользователя
        /// </summary>
        /// <param name="login">Логин нового пользователя</param>
        /// <param name="pass">Пароль нового пользователя</param>
        /// <returns>Код ошибки</returns>
        public int createUser(String login, String pass);

        /// <summary>
        /// Создание базы данных
        /// </summary>
        /// <param name="dbName">Название новой базы данных</param>
        /// <returns>Код ошибки</returns>
        public int createDatabase(String dbName);

        /// <summary>
        /// Показать список баз данных
        /// </summary>
        /// <param name="output">Переменная для результата</param>
        /// <returns>Код ошибки</returns>
        public int showDatabases(ref String[] output);

        /// <summary>
        /// Использовать базу данных
        /// </summary>
        /// <param name="dbName">Имя базы данных</param>
        /// <returns>Код ошибки</returns>
        public int use(String dbName);

        /// <summary>
        /// Создать таблицу
        /// </summary>
        /// <param name="tableName">Имя новой таблицы</param>
        /// <returns>Код ошибки</returns>
        public int createTable(String tableName);

        /// <summary>
        /// Показать таблицы в базе данных
        /// </summary>
        /// <param name="output">Переменная для вывода</param>
        /// <returns>Код ошибки</returns>
        public int showTables(ref String[] output);

        /// <summary>
        /// Переименовать таблицу
        /// </summary>
        /// <param name="tableName">Старое имя</param>
        /// <param name="newName">Новое имя</param>
        /// <returns>Код ошибки</returns>
        public int renameTable(String tableName, String newName);

        /// <summary>
        /// Удалить таблицу
        /// </summary>
        /// <param name="tableName">Имя таблицы</param>
        /// <returns>Код ошибки</returns>
        public int dropTable(String tableName);

        /// <summary>
        /// Вставить данные в таблицу
        /// </summary>
        /// <param name="tableName">Имя таблицы</param>
        /// <param name="values">Значения для вставки</param>
        /// <returns>Код ошибки</returns>
        public int insert(String tableName, String[] values);

        /// <summary>
        /// Обновить значения в таблице
        /// </summary>
        /// <param name="tableName">Имя таблицы</param>
        /// <param name="values">Значения</param>
        /// <param name="where">Выражение поиска</param>
        /// <returns>Код ошибки</returns>
        public int update(String tableName, String[] values, String where = null);

        /// <summary>
        /// Выбрать значения из таблицы
        /// </summary>
        /// <param name="tableName">Имя таблицы</param>
        /// <param name="columns">Колонки</param>
        /// <param name="where">Выражение поиска</param>
        /// <returns>Код ошибки</returns>
        public int select(String tableName, String columns, String where = null);

        /// <summary>
        /// Удалить строки
        /// </summary>
        /// <param name="tableName">Имя таблицы</param>
        /// <param name="where">Выражение поиска</param>
        /// <returns>Код ошибки</returns>
        public int delete(String tableName, String where = null);
    }

    /// <summary>
    /// Вывод в консоль
    /// </summary>
    class ConsoleOutput : DataBaseOutput
    {
        public void output (String message)
        {
            Console.WriteLine(message);
        }
    }

    /// <summary>
    /// Класс для работы с базой данных
    /// </summary>
    class DataBase
    {
        private DataBaseConnector connector;
        private DataBaseOutput output;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="connector">Коннектор базы данных</param>
        /// <param name="output">Класс вывода</param>
        public DataBase (DataBaseConnector connector, DataBaseOutput output)
        {
            this.connector = connector;
            this.output = output;
        }

        public int connect(String login, String pass, String dbPath)
        {
            int code = this.connector.connect(login, pass, dbPath);
            this.output.output(code.ToString());
            return code;
        }

        public int createUser(String login, String pass)
        {
            int code = this.connector.createUser(login, pass);
            this.output.output(code.ToString());
            return code;
        }

        public int createDatabase(String dbName)
        {
            int code = this.connector.createDatabase(dbName);
            this.output.output(code.ToString());
            return code;
        }

        public int showDatabases(ref String[] output)
        {
            String[] databases = { };
            int code = this.connector.showDatabases(ref databases);
            this.output.output(code.ToString());
            this.output.output(String.Join("\n", databases));
            return code;
        }

        public int use(String dbName)
        {
            int code = this.connector.use(dbName);
            this.output.output(code.ToString());
            return code;
        }

        public int createTable(String tableName)
        {
            int code = this.connector.createTable(tableName);
            this.output.output(code.ToString());
            return code;
        }

        public int showTables(ref String[] output)
        {
            String[] tables = { };
            int code = this.connector.showTables(ref tables);
            this.output.output(code.ToString());
            this.output.output(String.Join("\n", tables));
            return code;
        }

        public int renameTable(String tableName, String newName)
        {
            int code = this.connector.renameTable(tableName, newName);
            this.output.output(code.ToString());
            return code;
        }

        public int dropTable(String tableName)
        {
            int code = this.connector.dropTable(tableName);
            this.output.output(code.ToString());
            return code;
        }

        public int insert(String tableName, String[] values)
        {
            int code = this.connector.insert(tableName, values);
            this.output.output(code.ToString());
            return code;
        }

        public int update(String tableName, String[] values, String where = null)
        {
            int code = this.connector.update(tableName, values, where);
            this.output.output(code.ToString());
            return code;
        }

        public int select(String tableName, String columns, String where = null)
        {
            int code = this.connector.select(tableName, columns, where);
            this.output.output(code.ToString());
            return code;
        }

        public int delete(String tableName, String where = null)
        {
            int code = this.connector.select(tableName, where);
            this.output.output(code.ToString());
            return code;
        }
    }

    /// <summary>
    /// Коннектор для Oracle db
    /// </summary>
    class OracleConnector : DataBaseConnector
    {
        public int connect(String login, String pass, String dbPath)
        {
            return 0;
        }

        public int createUser(String login, String pass)
        {
            return 0;
        }

        public int createDatabase(String dbName)
        {
            throw new Exception("Oracle db doesn't use databases, use schema instead");
        }

        public int showDatabases(ref String[] output)
        {
            return 0;
        }

        public int use(String dbName)
        {
            return 0;
        }

        public int createTable(String tableName)
        {
            return 0;
        }

        public int showTables(ref String[] output)
        {
            return 0;
        }

        public int renameTable(String tableName, String newName)
        {
            return 0;
        }

        public int dropTable(String tableName)
        {
            return 0;
        }

        public int insert(String tableName, String[] values)
        {
            return 0;
        }

        public int update(String tableName, String[] values, String where = null)
        {
            return 0;
        }

        public int select(String tableName, String columns, String where = null)
        {
            return 0;
        }

        public int delete(String tableName, String where = null)
        {
            return 0;
        }
    }

    /// <summary>
    /// Коннектор для PostgreSQL
    /// </summary>
    class PostgreSQLConnector : DataBaseConnector
    {
        public int connect(String login, String pass, String dbPath)
        {
            return 0;
        }

        public int createUser(String login, String pass)
        {
            return 0;
        }

        public int createDatabase(String dbName)
        {
            return 0;
        }

        public int showDatabases(ref String[] output)
        {
            return 0;
        }

        public int use(String dbName)
        {
            return 0;
        }

        public int createTable(String tableName)
        {
            return 0;
        }

        public int showTables(ref String[] output)
        {
            return 0;
        }

        public int renameTable(String tableName, String newName)
        {
            return 0;
        }

        public int dropTable(String tableName)
        {
            return 0;
        }

        public int insert(String tableName, String[] values)
        {
            return 0;
        }

        public int update(String tableName, String[] values, String where = null)
        {
            return 0;
        }

        public int select(String tableName, String columns, String where = null)
        {
            return 0;
        }

        public int delete(String tableName, String where = null)
        {
            return 0;
        }
    }

    /// <summary>
    /// Коннектор для MySQL
    /// </summary>
    class MySQLConnector : DataBaseConnector
    {
        public int connect(String login, String pass, String dbPath)
        {
            return 0;
        }

        public int createUser(String login, String pass)
        {
            return 0;
        }

        public int createDatabase(String dbName)
        {
            return 0;
        }

        public int showDatabases(ref String[] output)
        {
            return 0;
        }

        public int use(String dbName)
        {
            return 0;
        }

        public int createTable(String tableName)
        {
            return 0;
        }

        public int showTables(ref String[] output)
        {
            return 0;
        }

        public int renameTable(String tableName, String newName)
        {
            return 0;
        }

        public int dropTable(String tableName)
        {
            return 0;
        }

        public int insert(String tableName, String[] values)
        {
            return 0;
        }

        public int update(String tableName, String[] values, String where = null)
        {
            return 0;
        }

        public int select(String tableName, String columns, String where = null)
        {
            return 0;
        }

        public int delete(String tableName, String where = null)
        {
            return 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DataBase db = new DataBase(new OracleConnector(), new ConsoleOutput());
            db.connect("root", "simsimopen", "http://localhost:68666");
            try
            {
                db.createDatabase("test");
            } 
            catch(Exception e) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: ");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.ResetColor();
            }
        }
    }
}
