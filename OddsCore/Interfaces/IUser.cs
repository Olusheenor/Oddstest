using System;
using System.Collections.Generic;
using System.Text;

namespace OddsCore.Interfaces
{
    interface IUser
    {
         string UserName { get; set; }
         string UserType { get; set; }
    }
}
