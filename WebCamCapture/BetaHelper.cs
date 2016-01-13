using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpryCoder.Camever
{
    public static class BetaHelper
    {
        private static readonly DateTime BetaExpireDate = DateTime.Parse("03/15/2016");

        public static bool BetaExpired()
        {
            return (DateTime.Now > BetaExpireDate) ? true : false;
        }
    }
}
