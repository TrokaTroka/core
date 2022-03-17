using System;
using TrokaTroka.Api.Enums;

namespace TrokaTroka.Api.Models
{
    public class Trade : EntityBase
    {
        public Trade(DateTime tradeDate, TradeStatus tradeStatus)
        {
            TradeDate = tradeDate;
            TradeStatus = tradeStatus;
        }

        public DateTime TradeDate { get; private set; }
        public TradeStatus TradeStatus { get; private set; }

        public Trade()
        { }
    }
}