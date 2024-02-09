using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tracs.Common.Models
{
    [DataContract]
    [JsonObject(MemberSerialization.OptIn)]
    public class ShippingModel
    {
       
        public ShippingModel() {

        }

        [JsonProperty]
        [DisplayName("Case ID")]
        public string RMAId { get; set; }


        public static  List<ShippingModel> Test_GetList()
        {

            return new List<ShippingModel>
            {
                new ShippingModel{
                    RMAId = "PBT001",
                },
                new ShippingModel{
                    RMAId = "PBT002",
                }
            };

        }


    }
}