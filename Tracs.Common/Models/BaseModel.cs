using System;
using System.Collections.Generic;
using System.Text;

namespace Tracs.Common.Models
{
    public abstract class BaseModel
    {
        public virtual int? id { get; set; }
        public BaseModel(int? id)
        {
            this.id = id;
        }
        public BaseModel()
        {
        }
    }
}
