using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMEGPCUSTOMERBank.Modal
{
    public class ScoreCardResponse
    {
        public bool status { get; set; }

        public int maximumMarks { get; set; }
        public int marksSecured { get; set; }
        public bool isDeclrAccept { get; set; }
        public Applicant applicant { get; set; }
        public List<ScoreParameter> scoreParameters { get; set; }
    }
}
