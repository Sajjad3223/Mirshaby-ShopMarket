using System;
using System.Globalization;

namespace ShopMarket.Core.Utilities.Convertors
{
    public static class DateConvertor
    {
        public static string ToShamsi(this DateTime time)
        {
            PersianCalendar pc = new PersianCalendar();
            return string.Format("{0}/{1:00}/{2:00}", pc.GetYear(time), pc.GetMonth(time), pc.GetDayOfMonth(time));
        }
    }
}