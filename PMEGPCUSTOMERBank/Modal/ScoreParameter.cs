using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMEGPCUSTOMERBank.Modal
{

        public class ScoreParameter
        {
            public int ScrParamID { get; set; }
            public string ScrCategory { get; set; }
            public string ScrParameter { get; set; }
            public string ScrCriteria { get; set; }
            public int MaxMarks { get; set; }
            public bool IsUpload { get; set; }
            public bool IsManual { get; set; }
            public int Seq { get; set; }
            public string FileLable { get; set; }
        }
    
}
