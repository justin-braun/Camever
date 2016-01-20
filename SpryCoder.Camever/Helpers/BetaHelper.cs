using System;

namespace SpryCoder.Camever.Helpers
{
    public static class BetaHelper
    {
        private static readonly DateTime BetaExpireDate = DateTime.Parse("03/15/2016");

        public static bool BetaExpired()
        {
            return DateTime.Now > BetaExpireDate;
        }


    }
}
