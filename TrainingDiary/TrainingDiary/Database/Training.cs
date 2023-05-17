using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Training
    {
       
   

        public int Id { get; set; }
        public string Exercise { get; set; }

        public int Sets { get; set; }

        public int Reps { get; set; }

        public  int Weights { get; set; }

        public Training(int id, string exercise, int sets, int reps, int weights)
        {
            Id = id;
            Exercise = exercise;
            Sets = sets;
            Reps = reps;
            Weights = weights;

        }

    }
}
