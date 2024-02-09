using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracs.Common.Models
{
    public class UserModel : BaseModel
    {
        public UserModel(int id)
        : base(id)
        {

        }
        public UserModel() {
            }
        
        public string Name { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }
        public string FirmName { get; set; }
        public string Password { get; set; }
        public int? PasswordTypeId { get; set; }
        public int? FirmId { get; set; }
        public string FirmTypeId { get; set; }

        [JsonIgnore]
        public int? AttributeId { get; set; }
        

       
       public static List<UserModel> GetAllUsers()
        {
            return new List<UserModel>
            {
                new UserModel{
                id = 1,
                Name = "igory",
                Password = "secret",
                Email="igory@parabit.com",
                Phone="5161111111",
                FirmId=1
                }
            };

        }

       
       
        private static List<UserModel> Test_GetValidUsers()
        {
            return new List<UserModel>
            {
                new UserModel{
                 id = 1,
                Name = "igory",
                Password = "secret",
                Email="igory@parabit.com",
                Phone="5161111111",
                FirmId=1
                }
            };

        }
    }
}
