using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data;
using MySql.Web;
using ObjectsModel;
using MySql.Data.MySqlClient;

namespace Data
{
    public class NewsRepository : IRepository
    {
        string connectionString;
        public NewsRepository()
            : this("myConnectionString")
        {
        }

        public NewsRepository(string connectionStringName)
        {
            var cs = ConfigurationManager.ConnectionStrings[connectionStringName];
            if (cs == null)
                throw new ApplicationException(string.Format("ConnectionString '{0}' not found", connectionStringName));
            connectionString = cs.ConnectionString;
        }
        public IEnumerable<Object> GetAll()
        {
            List<News> news = new List<News>();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT 
                                id,
                                data,
                                titolo,
                                testo,
                                foto
                                FROM news";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            News news_obj = new News();
                            news_obj.Id = reader.GetValue<int>("id");
                            news_obj.Data = reader.GetValue<DateTime>("data");
                            news_obj.Titolo = reader.GetValue<string>("titolo");
                            news_obj.Testo = reader.GetValue<string>("testo");
                            news_obj.Foto = reader.GetValue<string>("foto");

                            news.Add(news_obj);
                        }
                    }
                }
            }
            return news;
        }

        public object Get(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {

                string query = @"SELECT 
                                id,
                                data,
                                titolo,
                                testo,
                                foto
                                FROM news
                                WHERE id = " + id;

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = query;

                try
                {
                    connection.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    News news_obj = new News();
                    news_obj.Id = reader.GetValue<int>("id");
                    news_obj.Data = reader.GetValue<DateTime>("data");
                    news_obj.Titolo = reader.GetValue<string>("titolo");
                    news_obj.Testo = reader.GetValue<string>("testo");
                    news_obj.Foto = reader.GetValue<string>("foto");

                    connection.Close();
                    return news_obj;
                }
                else
                {
                    connection.Close();
                    return null;
                }

            }
        }


        public void Put(Object myObject)
        {
            News news = (News)myObject;

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                var query = @"INSERT INTO `news`
                            (id, 
                            data, 
                            titolo, 
                            testo, 
                            foto) 
                            VALUES 
                            (@Id,
                            @Data,
                            @Titolo,
                            @Testo,
                            @foto)";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.Add(new MySqlParameter("id", news.Id));
                    command.Parameters.Add(new MySqlParameter("data", news.Data));
                    command.Parameters.Add(new MySqlParameter("titolo", news.Titolo));
                    command.Parameters.Add(new MySqlParameter("testo", news.Testo));
                    command.Parameters.Add(new MySqlParameter("foto", news.Foto));

                    int affectedRows = command.ExecuteNonQuery();


                }
                connection.Close();
            }
        }


        public void Delete(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                var query = @"DELETE FROM news WHERE id = " + id;

                using (var command = new MySqlCommand(query, connection))
                {
                    int affectedRows = command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }


        public void Post(Object myObject)
        {
            News news = (News)myObject;

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"UPDATE news 
                                SET id = @id,
                                    data = @data,
                                    titolo = @titolo,
                                    testo = @testo,
                                    foto = @foto 
                                    WHERE id = @id";

                using(var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.Add(new MySqlParameter("@id", news.Id));
                    command.Parameters.Add(new MySqlParameter("@data", news.Data));
                    command.Parameters.Add(new MySqlParameter("@titolo", news.Titolo));
                    command.Parameters.Add(new MySqlParameter("@testo", news.Testo));
                    command.Parameters.Add(new MySqlParameter("@foto", news.Foto));

                    int affectedRows = command.ExecuteNonQuery();
                }

            }
        }
    }
}
