using System;

namespace TrokaTroka.Api.Models
{
    public class TradeUser
    {
        public Guid IdUser { get; private set; }
        public Guid IdTrade { get; private set; }

        public TradeUser()
        { }
    }
}
