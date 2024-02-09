

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Tracs.Common.Models
{
    [DataContract]
    public class LoginModel
    {
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }


        public List<CountryModel> Countries { get; set; }


    }

}