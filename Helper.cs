using Sotrydniki.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sotrydniki
{
    public static class Helper
    {
        public static User9Context DbContext { get; set; } = new User9Context();
    }
}
