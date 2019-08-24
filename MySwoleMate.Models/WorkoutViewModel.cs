using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySwoleMate.Models
{
    public class WorkoutViewModel
    {
        public int WorkoutID { get; set; }
        public string WorkoutName { get; set; }
        public string Excercise1 { get; set; }
        public int Excercise1Reps { get; set; }
        public int Excercise1Sets { get; set; }
        public string Excercise2 { get; set; }
        public int Excercise2Reps { get; set; }
        public int Excercise2Sets { get; set; }
        public string Excercise3 { get; set; }
        public int Excercise3Reps { get; set; }
        public int Excercise3Sets { get; set; }
        public string Excercise4 { get; set; }
        public int Excercise4Reps { get; set; }
        public int Excercise4Sets { get; set; }
        public string Excercise5 { get; set; }
        public int Excercise5Reps { get; set; }
        public int Excercise5Sets { get; set; }

        public string DisplayExercise1
        {
            get
            {
                return this.Excercise1 + ": " + this.Excercise1Sets + "x" + this.Excercise1Reps;
            }
        }

        public string DisplayExercise2
        {
            get
            {
                return this.Excercise2 + ": " + this.Excercise2Sets + "x" + this.Excercise2Reps;
            }
        }

        public string DisplayExercise3
        {
            get
            {
                return this.Excercise3 + ": " + this.Excercise3Sets + "x" + this.Excercise3Reps;
            }
        }

        public string DisplayExercise4
        {
            get
            {
                return this.Excercise4 + ": " + this.Excercise4Sets + "x" + this.Excercise4Reps;
            }
        }

        public string DisplayExercise5
        {
            get
            {
                return this.Excercise5 + ": " + this.Excercise5Sets + "x" + this.Excercise5Reps;
            }
        }
    }
}
