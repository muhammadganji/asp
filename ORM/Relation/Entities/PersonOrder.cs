using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PersonOrder
    {
        public long Id { get; set; }
        public long PersonId { get; set; }
        public long OrderId { get; set; }
    }
}
