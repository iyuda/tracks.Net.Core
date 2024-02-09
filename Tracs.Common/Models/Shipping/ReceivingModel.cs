using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;

using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tracs.Common.Models
{
    [DataContract]
    [JsonObject(MemberSerialization.OptIn)]
    public class ReceivingModel
    {
        public ReceivingModel() {

        }

        [JsonProperty]
        [DisplayName("Case ID")]
        public string RMAId { get; set; }

        [JsonProperty]
        [DisplayName("Tech Name")]
        public string UserName { get; set; }

        [JsonProperty]
        [DisplayName("Tech E-mail")]
        public string Email { get; set; }

        [JsonProperty]
        [DisplayName("Tech Number")]
        public string UserPhoneNumber { get; set; }

        [JsonProperty]
        [DisplayName("Date Submitted")]
        public string DateSubmitted { get; set; }

        public static  List<ReceivingModel> Test_GetList()
        {

            return new List<ReceivingModel>
            {
                new ReceivingModel{
                    RMAId = "PBT001",
                    UserName = "Igor Yuda",
                    Email = "igory@parabit.com",
                    UserPhoneNumber = "9876543210",
                },
                new ReceivingModel{
                    RMAId = "PBT002",
                    UserName = "Igor Yuda2",
                    Email = "igory@parabit.com",
                    UserPhoneNumber = "1876543210",
                }
            };

        }


    }
}