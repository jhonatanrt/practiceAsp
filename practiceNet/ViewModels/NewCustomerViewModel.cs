using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using practiceNet.Models; 

namespace practiceNet.ViewModels
{
    public class CustomerForViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}