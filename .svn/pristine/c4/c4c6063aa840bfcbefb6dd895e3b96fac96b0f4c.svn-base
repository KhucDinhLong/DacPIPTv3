using System;
using System.Globalization;
using System.Text;

namespace PIPTWeb.Shared
{
    public static class PIPTWebMethods
    {
        public static string sEncrypKey = "085A23E677CFD1DD47BA1096B0637A52C98206484D52DBD6E4D0847FCD7EA011";
        public static string EncryptString(string sMessage)
        {
            byte[] Results;
            if (string.IsNullOrEmpty(sMessage)) return string.Empty;
            sMessage += sEncrypKey;
            Results = Encoding.UTF8.GetBytes(sMessage);
            return Convert.ToBase64String(Results);
        }

        public static string DecryptString(string base64EncodeData)
        {
            if (string.IsNullOrEmpty(base64EncodeData)) return string.Empty;
            byte[] base64EncodeBytes = Convert.FromBase64String(base64EncodeData);
            var Results = Encoding.UTF8.GetString(base64EncodeBytes);
            Results = Results.Substring(0, Results.Length - sEncrypKey.Length);
            return Results;
        }

        public static int GetIso8601WeekOfYear(DateTime time)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public static DateTime FirstDateOfWeek(int year, int weekOfYear, CultureInfo ci)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = (int)ci.DateTimeFormat.FirstDayOfWeek - (int)jan1.DayOfWeek;
            DateTime firstWeekDay = jan1.AddDays(daysOffset);
            int firstWeek = ci.Calendar.GetWeekOfYear(jan1, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
            if ((firstWeek <= 1 || firstWeek >= 52) && daysOffset >= -3)
            {
                weekOfYear -= 1;
            }
            return firstWeekDay.AddDays(weekOfYear * 7);
        }

        /// <summary>
        /// Lấy ra ngày đầu tiên trong tháng có chứa 
        /// 1 ngày bất kỳ được truyền vào
        /// </summary>
        /// <param name="dtDate">Ngày nhập vào</param>
        /// <returns>Ngày đầu tiên trong tháng</returns>
        public static DateTime GetFirstDayOfMonth(DateTime dtInput)
        {
            DateTime dtResult = dtInput;
            dtResult = dtResult.AddDays((-dtResult.Day) + 1);
            return dtResult;
        }

        /// <summary>
        /// Lấy ra ngày đầu tiên trong tháng được truyền vào 
        /// là 1 số nguyên từ 1 đến 12
        /// </summary>
        /// <param name="iMonth">Thứ tự của tháng trong năm</param>
        /// <returns>Ngày đầu tiên trong tháng</returns>
        public static DateTime GetFirstDayOfMonth(int iMonth)
        {
            DateTime dtResult = new DateTime(DateTime.Now.Year, iMonth, 1);
            dtResult = dtResult.AddDays((-dtResult.Day) + 1);
            return dtResult;
        }

        /// <summary>
        /// Lấy ra ngày cuối cùng trong tháng có chứa 
        /// 1 ngày bất kỳ được truyền vào
        /// </summary>
        /// <param name="dtInput">Ngày nhập vào</param>
        /// <returns>Ngày cuối cùng trong tháng</returns>
        public static DateTime GetLastDayOfMonth(DateTime dtInput)
        {
            DateTime dtResult = dtInput;
            dtResult = dtResult.AddMonths(1);
            dtResult = dtResult.AddDays(-(dtResult.Day));
            return dtResult;
        }

        /// <summary>
        /// Lấy ra ngày cuối cùng trong tháng được truyền vào
        /// là 1 số nguyên từ 1 đến 12
        /// </summary>
        /// <param name="iMonth"></param>
        /// <returns></returns>
        public static DateTime GetLastDayOfMonth(int iMonth)
        {
            DateTime dtResult = new DateTime(DateTime.Now.Year, iMonth, 1);
            dtResult = dtResult.AddMonths(1);
            dtResult = dtResult.AddDays(-(dtResult.Day));
            return dtResult;
        }

        /// <summary>
        /// Lấy ra ngày đầu tiên trong tuần của ngày nhập vào 
        /// với Culture mặc định là Culture hiện tại
        /// </summary>
        /// <param name="dayInWeek">Ngày nhập vào</param>
        /// <returns>Ngày đầu tiên trong tuần</returns>
        public static DateTime GetFirstDayOfWeek(DateTime dayInWeek)
        {
            CultureInfo defaultCultureInfo = CultureInfo.CurrentCulture;
            return GetFirstDayOfWeek(dayInWeek, defaultCultureInfo);
        }

        /// <summary>
        /// Lấy ra ngày đầu tiên trong tuần của ngày nhập vào
        /// với một Culture cụ thể được truyền vào
        /// </summary>
        /// <param name="dayInWeek">Ngày nhập vào</param>
        /// <param name="cultureInfo">CultureInfo quy định các thông tin về Culture 
        /// ( định dạng ngày tháng, ngày bắt đầu trong tuần , ... )
        /// </param>
        /// <returns></returns>
        private static DateTime GetFirstDayOfWeek(DateTime dayInWeek, CultureInfo cultureInfo)
        {
            DayOfWeek firstDay = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            DateTime firstDayInWeek = dayInWeek.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
            {
                firstDayInWeek = firstDayInWeek.AddDays(-1);
            }
            return firstDayInWeek;
        }

        /// <summary>
        /// Lấy ra ngày đầu tiên trong tuần của ngày nhập vào
        /// với 1 giá trị cụ thể của enum DayOfWeek chỉ định 
        /// ngày bắt đầu tuần là thứ mấy
        /// </summary>
        /// <param name="dayInWeek">Ngày nhập vào</param>
        /// <param name="dayOfWeek">enum chỉ định thứ bắt đầu tuần</param>
        /// <returns></returns>
        private static DateTime GetFirstDayOfWeek(DateTime dayInWeek, DayOfWeek dayOfWeek)
        {
            DateTime firstDayInWeek = dayInWeek.Date;
            while (firstDayInWeek.DayOfWeek != dayOfWeek)
            {
                firstDayInWeek = firstDayInWeek.AddDays(-1);
            }
            return firstDayInWeek;
        }
    }
}
