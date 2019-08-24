using MySwoleMate.DAL;
using MySwoleMate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySwoleMate.BLL
{
    public class WorkoutBLL
    {
        private WorkoutDAL data;

        public WorkoutBLL(string connectionString)
        {
            data = new WorkoutDAL(connectionString);
        }

        public List<WorkoutViewModel> GetAllWorkouts()
        {

            List<WorkoutViewModel> workouts = data.GetWorkouts();
            //foreach(var item in workouts)
            //{

            //}
            //return GetAllWorkouts();
            return workouts;
        }

        public WorkoutViewModel GetWorkOutByID(int id)
        {
            return data.GetWorkoutByWorkOutID(id);
        }

        public int EditWorkout(WorkoutViewModel edit)
        {
            return data.EditTraineeWorkout(edit);
        }

        public int AddWorkout(WorkoutViewModel add)
        {
            return data.AddWorkout(add);
        }

        public int DeleteWorkout(int id)
        {
            return data.DeleteWorkout(id);
        }
    }
}
