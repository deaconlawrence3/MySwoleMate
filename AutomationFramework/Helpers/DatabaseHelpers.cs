using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace AutomationFramework.Helpers
{
    public class DatabaseHelpers
    {
        #region DB Table Columns/Values
        public int TraineeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public int WorkoutID { get; set; }
        public string WorkoutName { get; set; }
        public string Exercise1 { get; set; }
        public string Excercise1Reps { get; set; }
        public string Excercise1Sets { get; set; }
        public string Exercise2 { get; set; }
        public string Excercise2Reps { get; set; }
        public string Excercise2Sets { get; set; }
        public string Exercise3 { get; set; }
        public string Excercise3Reps { get; set; }
        public string Excercise3Sets { get; set; }
        public string Exercise4 { get; set; }
        public string Excercise4Reps { get; set; }
        public string Excercise4Sets { get; set; }
        public string Exercise5 { get; set; }
        public string Excercise5Reps { get; set; }
        public string Excercise5Sets { get; set; }

        #endregion

        #region DB Queries/Scripts
        public DataTable GetTraineeInfoQuery(string DBConnection)
        {
            using (SqlConnection SwoleMateDB = new SqlConnection(DBConnection))
            {
                try
                {
                    SwoleMateDB.Open();
                    using (SqlCommand query = SwoleMateDB.CreateCommand())
                    {
                        query.CommandText = "SELECT TOP 1 * FROM[MySwoleMate].[dbo].[Trainee] ORDER BY TraineeID DESC";

                        using (SqlDataReader dataReader = query.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while(dataReader.Read())
                                {
                                    if (dataReader["TraineeID"] != System.DBNull.Value)
                                    {
                                        TraineeId = (int)dataReader["TraineeID"];
                                    }

                                    if (dataReader["FirstName"] != System.DBNull.Value)
                                    {
                                        FirstName = (string)dataReader["FirstName"];
                                    }

                                    if (dataReader["LastName"] != System.DBNull.Value)
                                    {
                                        LastName = (string)dataReader["LastName"];
                                    }

                                    if (dataReader["Email"] != System.DBNull.Value)
                                    {
                                        Email = (string)dataReader["Email"];
                                    }

                                    if (dataReader["Height"] != System.DBNull.Value)
                                    {
                                        Height = (int)dataReader["Height"];
                                    }

                                    if (dataReader["Weight"] != System.DBNull.Value)
                                    {
                                        Weight = (int)dataReader["Weight"];
                                    }

                                    if (dataReader["CellNbr"] != System.DBNull.Value)
                                    {
                                        Phone = (string)dataReader["CellNbr"];
                                    }

                                    if (dataReader["Gender"] != System.DBNull.Value)
                                    {
                                        Gender = (string)dataReader["Gender"];
                                    }

                                    if (dataReader["Age"] != System.DBNull.Value)
                                    {
                                        Age = (int)dataReader["Age"];
                                    }

                                    if (dataReader["WorkoutID"] != System.DBNull.Value)
                                    {
                                        WorkoutID = (int)dataReader["WorkoutID"];
                                    }
                                   
                                }
                            }
                        }
                    }

                    SwoleMateDB.Close();
                    return new DataTable();
                }

                catch (Exception ex)
                {
                    throw ex;
                }

                finally
                {
                    if (SwoleMateDB.State != ConnectionState.Closed)
                    {
                        SwoleMateDB.Close();
                    }
                }
            }
        }

        #endregion
    }
}
