using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Entity_Framework.models
{
    public class PostTag
    {
        public int PostId { get; set; }
        public int TagId { get; set; }
    }
}
