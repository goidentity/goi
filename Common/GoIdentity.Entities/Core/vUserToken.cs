using System;
using System.Collections.Generic;
using System.Text;

namespace GoIdentity.Entities.Core
{
    public class vUserToken
    {
        public int RowNo { get; set; }
        public int UserId { get; set; }
        public string TokenName { get; set; }
        public string Token { get; set; }
    }
}
