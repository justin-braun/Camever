using System;

namespace ArmchairCoder.Camever.Helpers
{
    public static class BetaHelper
    {
        private static readonly DateTime BetaExpireDate = DateTime.Parse("04/01/2016");

        public static bool BetaExpired()
        {
            return DateTime.Now > BetaExpireDate;
        }


    }
}
