using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace PIPTWeb.Shared
{
    public class SortingUtility
    {
        public enum SortOrders
        {
            Asc = 1,
            Desc = 2
        }
        public class SortingParams
        {
            public SortOrders SortOrder { get; set; } = SortOrders.Asc;
            public string ColumnName { get; set; }
        }
        /// <summary>
        /// Tập hợp để cho thự tụ sắp xếp
        /// Asc = Ascending (tăng dần)
        /// Desc = Descending (giảm dần)
        /// </summary>
        public class Sorting<T>
        {
            /// <summary>
            /// Nhóm thực tế sẽ thực hiện trong UI,
            /// từ api chúng ta sẽ gửi dữ liệu đã sắp xếp dựa theo các cột tạo nhóm
            /// </summary>
            /// <param name="data"></param>
            /// <param name="groupingColumns"></param>
            /// <returns></returns>
            public static IQueryable<T> GroupingData(IQueryable<T> data, IEnumerable<string> groupingColumns)
            {
                //IOrderedQueryable<T> groupedData = null;

                var type = typeof(T);
                // { x }
                ParameterExpression parameter = Expression.Parameter(type, "x");
                Expression expression = data.Expression;
                bool firstTime = true;

                foreach (string grpCol in groupingColumns.Where(x => !String.IsNullOrEmpty(x)))
                {
                    var columnName = typeof(T).GetProperty(grpCol, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
                    if (columnName != null)
                    {
                        // { x.ColumnName } ví dụ: x.Id, x.Name v/v...
                        var selector = Expression.Property(parameter, columnName);

                        // { x => x.ColumnName }
                        var lambda = Expression.Lambda(selector, parameter);

                        string methodName = firstTime ? nameof(Queryable.OrderBy) : nameof(Queryable.ThenBy);

                        // { Orderby | OrderByDescending | ThenBy | ThenByDescending(x => x.ColumnName) }
                        expression = Expression.Call(
                            typeof(Queryable),
                            methodName,
                            new Type[] { type, columnName.PropertyType },
                            expression,
                            Expression.Quote(lambda));

                        //sortedData = sortedData == null ? (IOrderedQueryable<T>)data.Provider.CreateQuery<T>(expression)
                        //                                : null;
                        data = data.Provider.CreateQuery<T>(expression);
                        expression = data.Expression;
                        firstTime = false;
                    }
                }

                return data;
            }
            /// <summary>
            /// Dữ liệu đã sắp xếp theo các cột đã được gửi để sắp thứ tự trả cho API.
            /// </summary>
            /// <param name="data"></param>
            /// <param name="sortingParams"></param>
            /// <returns></returns>
            public static IQueryable<T> SortData(IQueryable<T> data, IEnumerable<SortingParams> sortingParams)
            {
                //IOrderedQueryable<T> sortedData = null;

                var type = typeof(T);
                // { x }
                ParameterExpression parameter = Expression.Parameter(type, "x");
                Expression expression = data.Expression;
                bool firstTime = true;

                foreach (var sortingParam in sortingParams.Where(x => !String.IsNullOrEmpty(x.ColumnName)))
                {
                    var columnName = typeof(T).GetProperty(sortingParam.ColumnName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
                    if (columnName != null)
                    {
                        // { x.ColumnName } ví dụ: x.Id, x.Name v/v...
                        var selector = Expression.Property(parameter, columnName);

                        // { x => x.ColumnName }
                        var lambda = Expression.Lambda(selector, parameter);

                        string methodName = firstTime
                            ? sortingParam.SortOrder == SortOrders.Asc ? nameof(Queryable.OrderBy) : nameof(Queryable.OrderByDescending)
                            : sortingParam.SortOrder == SortOrders.Asc ? nameof(Queryable.ThenBy) : nameof(Queryable.ThenByDescending);

                        // { Orderby | OrderByDescending | ThenBy | ThenByDescending(x => x.ColumnName) }
                        expression = Expression.Call(
                            typeof(Queryable),
                            methodName,
                            new Type[] { type, columnName.PropertyType },
                            expression,
                            Expression.Quote(lambda));

                        //sortedData = sortedData == null ? (IOrderedQueryable<T>)data.Provider.CreateQuery<T>(expression)
                        //                                : null;
                        // Thêm cột cần sắp xếp vào truy vấn
                        data = data.Provider.CreateQuery<T>(expression);
                        expression = data.Expression;
                        firstTime = false;
                    }
                }
                return data;
            }
        }
    }
}
