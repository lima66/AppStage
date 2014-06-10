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
    public class EventRepository : IRepository
    {
        string connectionString;
        public EventRepository()
            : this("myConnectionString")
        {
        }

        public EventRepository(string connectionStringName)
        {
            var cs = ConfigurationManager.ConnectionStrings[connectionStringName];
            if (cs == null)
                throw new ApplicationException(string.Format("ConnectionString '{0}' not found", connectionStringName));
            connectionString = cs.ConnectionString;
        }
        public IEnumerable<Object> GetAll()
        {
            List<Event> events = new List<Event>();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT 
                                id,
                                data,
                                titolo,
                                testo,
                                foto
                                FROM events";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Event event_obj = new Event();
                            event_obj.Id = reader.GetValue<int>("id");
                            event_obj.Data = reader.GetValue<DateTime>("data");
                            event_obj.Titolo = reader.GetValue<string>("titolo");
                            event_obj.Testo = reader.GetValue<string>("testo");
                            event_obj.Foto = reader.GetValue<string>("foto");

                            events.Add(event_obj);
                        }
                    }
                }
            }
            return events;
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
                                FROM events
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
                    Event event_obj = new Event();
                    event_obj.Id = reader.GetValue<int>("id");
                    event_obj.Data = reader.GetValue<DateTime>("data");
                    event_obj.Titolo = reader.GetValue<string>("titolo");
                    event_obj.Testo = reader.GetValue<string>("testo");
                    event_obj.Foto = reader.GetValue<string>("foto");

                    connection.Close();

                    return event_obj;
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
            throw new NotImplementedException();
        }


        public void Delete(int id)
        {
            throw new NotImplementedException();
        }


        public void Post(object myObject)
        {
            throw new NotImplementedException();
        }
    }
}
