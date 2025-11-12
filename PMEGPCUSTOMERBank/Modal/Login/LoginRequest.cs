using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMEGPCUSTOMERBank.Modal.Login
{

    public class LoginRequest
    {
        [JsonProperty("data")]
        public string Data { get; set; }
    }
}
