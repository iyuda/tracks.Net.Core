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
    public class FirmModel : BaseModel
    {
        public FirmModel(int id)
        : base(id)
        {
            //LoadRelations();
        }
        public FirmModel() { }
        public string FirmName { get; set; }
        public int? ContactId { get; set; }

        public UserModel contact { get; set; }
       
       
       
    }
}