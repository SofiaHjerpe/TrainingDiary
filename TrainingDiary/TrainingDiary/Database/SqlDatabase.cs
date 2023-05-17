using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class SqlDatabase
    {
        public List<Training> GetTrainings()
        {
            SqlCommand cmd = GetDbCommand();
            cmd.CommandText = "SELECT * FROM Trainings WHERE Sets < 100 AND Sets > 1 AND Reps < 100 AND Reps > 1 AND Weights < 500 AND Weights > 1";
            var reader = cmd.ExecuteReader();
            var training = new List<Training>();
            while (reader.Read())
            {
                int id = int.Parse(reader["Id"].ToString());
                string exercise = reader["Exercise"].ToString();
                int sets = int.Parse(reader["Sets"].ToString());
                int reps = int.Parse(reader["Reps"].ToString());
                int weights = int.Parse(reader["Weights"].ToString());

                training.Add(new Training(id, exercise, sets, reps, weights));

            }
            return training;
        }

        public Training GetTrainingById(int Id)
        {

            string connection = "Data Source=localhost;Initial Catalog=Trainingdb;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connection);
            string query = "SELECT * FROM Trainings WHERE Id = @Id AND Sets < 100 AND Sets > 1 AND Reps < 100 AND Reps > 1 AND Weights < 500 AND Weights > 1";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", Id);
            conn.Open();
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int id = int.Parse(reader["Id"].ToString());
                string exercise = reader["Exercise"].ToString();
                int sets = int.Parse(reader["Sets"].ToString());
                int reps = int.Parse(reader["Reps"].ToString());
                int weights = int.Parse(reader["Weights"].ToString());

                return new Training(id, exercise, sets, reps, weights);
            }
            else
            {
                return null;
                
            }

        }
        public void SaveTraining(int id, string exercise, int sets, int reps, int weights)
        {
            SqlCommand cmd = GetDbCommand();
            cmd.CommandText = $"INSERT INTO Trainings (Id, Exercise, Sets, Reps, Weights) VALUES ({id},'{exercise}', {sets}, {reps}, {weights})";
            cmd.ExecuteNonQuery();
        }
        public void DeleteTraining(int Id)
        {
            string connection = "Data Source=localhost;Initial Catalog=Trainingdb;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connection);
            string query = "DELETE FROM Trainings WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", Id);
            conn.Open();
            cmd.ExecuteNonQuery();

        }
        private static SqlCommand GetDbCommand()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=Trainingdb;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            return cmd;
        }


    }
}
