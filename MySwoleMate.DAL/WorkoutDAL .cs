using MySwoleMate.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySwoleMate.DAL
{
    public class WorkoutDAL
    {

        //uses connection string for connecting to database
        private string _connectionString;
        public WorkoutDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        //Returns All Workouts
        public List<WorkoutViewModel> GetWorkouts()
        {
            //SQL command for selecting all from Workouts table
            string sqlQuery = "SELECT * FROM Workouts";

            //Empty list of WorkoutViewModel to add and return
            List<WorkoutViewModel> workouts = new List<WorkoutViewModel>();

            //Using SqlConnection to establish connection to database
            //using SqlCommand passing in the SqlConnection and the sqlQuery
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                //open the connection
                con.Open();
                //SqlDataReader is used because we are reading data from the database
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    //while there are records in the database
                    while (reader.Read())
                    {
                        //store each value into the properties of WorkoutViewModel
                        WorkoutViewModel temp = new WorkoutViewModel()
                        {
                            WorkoutID = Convert.ToInt32(reader["WorkoutID"]),
                            WorkoutName = reader["WorkoutName"].ToString(),
                            Excercise1 = reader["Excercise1"].ToString(),
                            Excercise1Sets = Convert.ToInt32(reader["Excercise1Sets"]),
                            Excercise1Reps = Convert.ToInt32(reader["Excercise1Reps"]),
                            Excercise2 = reader["Excercise2"].ToString(),
                            Excercise2Sets = Convert.ToInt32(reader["Excercise2Sets"]),
                            Excercise2Reps = Convert.ToInt32(reader["Excercise2Reps"]),
                            Excercise3 = reader["Excercise3"].ToString(),
                            Excercise3Sets = Convert.ToInt32(reader["Excercise3Sets"]),
                            Excercise3Reps = Convert.ToInt32(reader["Excercise3Reps"]),
                            Excercise4 = reader["Excercise4"].ToString(),
                            Excercise4Sets = Convert.ToInt32(reader["Excercise4Sets"]),
                            Excercise4Reps = Convert.ToInt32(reader["Excercise4Reps"]),
                            Excercise5 = reader["Excercise5"].ToString(),
                            Excercise5Sets = Convert.ToInt32(reader["Excercise5Sets"]),
                            Excercise5Reps = Convert.ToInt32(reader["Excercise5Reps"]),
                        };
                       
                        workouts.Add(temp);
                    }
                }
            }
            return workouts;
        }

        //Get Workout By Id, returns one instance of WorkoutIDModel      
        public WorkoutViewModel GetWorkoutByWorkOutID(int id)
        {
            WorkoutViewModel workout = new WorkoutViewModel();
            string sqlQuery = "Select * from Workouts where WorkoutID=@ID";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        workout.WorkoutID = Convert.ToInt32(reader["WorkoutID"]);
                        workout.WorkoutName = reader["WorkoutName"].ToString();
                        workout.Excercise1 = reader["Excercise1"].ToString();
                        workout.Excercise1Sets = Convert.ToInt32(reader["Excercise1Sets"]);
                        workout.Excercise1Reps = Convert.ToInt32(reader["Excercise1Reps"]);
                        workout.Excercise2 = reader["Excercise2"].ToString();
                        workout.Excercise2Sets = Convert.ToInt32(reader["Excercise2Sets"]);
                        workout.Excercise2Reps = Convert.ToInt32(reader["Excercise2Reps"]);
                        workout.Excercise3 = reader["Excercise3"].ToString();
                        workout.Excercise3Sets = Convert.ToInt32(reader["Excercise3Sets"]);
                        workout.Excercise3Reps = Convert.ToInt32(reader["Excercise3Reps"]);
                        workout.Excercise4 = reader["Excercise4"].ToString();
                        workout.Excercise4Sets = Convert.ToInt32(reader["Excercise4Sets"]);
                        workout.Excercise4Reps = Convert.ToInt32(reader["Excercise4Reps"]);
                        workout.Excercise5 = reader["Excercise5"].ToString();
                        workout.Excercise5Sets = Convert.ToInt32(reader["Excercise5Sets"]);
                        workout.Excercise5Reps = Convert.ToInt32(reader["Excercise5Reps"]);

                    }
                }
            }
            return workout;
        }

     
        //Edits Trainee Workut by using "UPDATE" Sql Query passing in values to edit depending on the TraineeID
        public int EditTraineeWorkout(WorkoutViewModel edit)
        {
            string sqlQuery = "Update Workouts Set WorkoutName=@WorkoutName, Excercise1=@Excercise1, Excercise1Reps=@Excercise1Reps, Excercise1Sets " +
                              "Excercise2 = @Excercise2, Excercise2Reps = @Excercise1Reps, Excercise2Sets " +
                              "Excercise3 = @Excercise3, Excercise3Reps = @Excercise3Reps, Excercise3Sets " +
                              "Excercise4 = @Excercise4, Excercise4Reps = @Excercise4Reps, Excercise4Sets " +
                              "Excercise5 = @Excercise5, Excercise5Reps = @Excercise5Reps, Excercise5Sets";

            //No need to use SqlDataReader here since we are just using the Sql Query to persist to database
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                cmd.Parameters.Add("@WorkoutID", SqlDbType.Int).Value = edit.WorkoutID;
                cmd.Parameters.Add("@WorkoutName", SqlDbType.VarChar).Value = edit.WorkoutName;
                cmd.Parameters.Add("@Excercise1", SqlDbType.VarChar).Value = edit.Excercise1;
                cmd.Parameters.Add("@Excercise1Reps", SqlDbType.VarChar).Value = edit.Excercise1Reps;
                cmd.Parameters.Add("@Excercise1Sets", SqlDbType.VarChar).Value = edit.Excercise1Sets;
                cmd.Parameters.Add("@Excercise2", SqlDbType.VarChar).Value = edit.Excercise2;
                cmd.Parameters.Add("@Excercise2Reps", SqlDbType.VarChar).Value = edit.Excercise2Reps;
                cmd.Parameters.Add("@Excercise2Sets", SqlDbType.VarChar).Value = edit.Excercise2Sets;
                cmd.Parameters.Add("@Excercise3", SqlDbType.VarChar).Value = edit.Excercise3;
                cmd.Parameters.Add("@Excercise3Reps", SqlDbType.VarChar).Value = edit.Excercise3Reps;
                cmd.Parameters.Add("@Excercise3Sets", SqlDbType.VarChar).Value = edit.Excercise3Sets;
                cmd.Parameters.Add("@Excercise4", SqlDbType.VarChar).Value = edit.Excercise4;
                cmd.Parameters.Add("@Excercise4Reps", SqlDbType.VarChar).Value = edit.Excercise4Reps;
                cmd.Parameters.Add("@Excercise4Sets", SqlDbType.VarChar).Value = edit.Excercise4Sets;
                cmd.Parameters.Add("@Excercise5", SqlDbType.VarChar).Value = edit.Excercise5;
                cmd.Parameters.Add("@Excercise5Reps", SqlDbType.VarChar).Value = edit.Excercise5Reps;
                cmd.Parameters.Add("@Excercise5Sets", SqlDbType.VarChar).Value = edit.Excercise5Sets;
                return cmd.ExecuteNonQuery();
            }
        }

        //Add Workout 
        public int AddWorkout(WorkoutViewModel add)
        {
         string sqlQuery = "INSERT INTO Workouts (WorkoutID, WorkoutName ,Excercise1, Excercise1Reps, Excercise1Sets, " +
         "Excercise2, Excercise2Reps, Excercise2Sets, Excercise3, Excercise3Reps, Excercise3Sets, " +
         "Excercise4, Excercise4Reps, Excercise4Sets, Excercise5, Excercise5Reps, Excercise5Sets) " +
         "VALUES (@WorkoutID, @WorkoutName, @Excercise1, @Excercise1Reps, @Excercise1Sets, @Excercise2, @Excercise2Reps, @Excercise2Sets, " +
         "@Excercise3, @Excercise3Reps, @Excercise3Sets, @Excercise4, @Excercise4Reps, @Excercise4Sets, @Excercise5, @Excercise5Reps, @Excercise5Sets";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                cmd.Parameters.Add("@WorkoutID", SqlDbType.Int).Value = add.WorkoutID;
                cmd.Parameters.Add("@Excercise1", SqlDbType.VarChar).Value = add.Excercise1;
                cmd.Parameters.Add("@Excercise1Reps", SqlDbType.VarChar).Value = add.Excercise1Reps;
                cmd.Parameters.Add("@Excercise1Sets", SqlDbType.VarChar).Value = add.Excercise1Sets;
                cmd.Parameters.Add("@Excercise2", SqlDbType.VarChar).Value = add.Excercise2;
                cmd.Parameters.Add("@Excercise2Reps", SqlDbType.VarChar).Value = add.Excercise2Reps;
                cmd.Parameters.Add("@Excercise2Sets", SqlDbType.VarChar).Value = add.Excercise2Sets;
                cmd.Parameters.Add("@Excercise3", SqlDbType.VarChar).Value = add.Excercise3;
                cmd.Parameters.Add("@Excercise3Reps", SqlDbType.VarChar).Value = add.Excercise3Reps;
                cmd.Parameters.Add("@Excercise3Sets", SqlDbType.VarChar).Value = add.Excercise3Sets;
                cmd.Parameters.Add("@Excercise4", SqlDbType.VarChar).Value = add.Excercise4;
                cmd.Parameters.Add("@Excercise4Reps", SqlDbType.VarChar).Value = add.Excercise4Reps;
                cmd.Parameters.Add("@Excercise4Sets", SqlDbType.VarChar).Value = add.Excercise4Sets;
                cmd.Parameters.Add("@Excercise5", SqlDbType.VarChar).Value = add.Excercise5;
                cmd.Parameters.Add("@Excercise5Reps", SqlDbType.VarChar).Value = add.Excercise5Reps;
                cmd.Parameters.Add("@Excercise5Sets", SqlDbType.VarChar).Value = add.Excercise5Sets;
                return cmd.ExecuteNonQuery();
            }
        }

        //Delete using "DELETE" Sql Query by the WorkoutID
       
        public int DeleteWorkout(int id)
        {
            string sqlQuery = "DELETE from Workouts Where WorkoutID=@WorkoutID";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                cmd.Parameters.Add("@WorkoutID", SqlDbType.Int).Value = id;
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
