using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace PIPTWeb.Shared
{
    public class FilterUtility
    {
        /// <summary>
        /// Enums các lựa chọn bộ lọc
        /// thứ tự UI theo sau
        /// </summary>
        public enum FilterOptions
        {
            StartsWith = 1,
            EndsWith,
            Contains,
            DoesNotContain,
            IsEmpty,
            IsNotEmpty,
            IsGreaterThan,
            IsGreaterThanOrEqualTo,
            IsLessThan,
            IsLessThanOrEqualTo,
            IsEqualTo,
            IsNotEqualTo,
            Between
        }

        /// <summary>
        /// Các biến lọc lớp Model
        /// </summary>
        public class FilterParams
        {
            public string ColumnName { get; set; } = string.Empty;
            public string FilterValue { get; set; } = string.Empty;
            public string SecondValue { get; set; } = string.Empty; // Chỉ áp dụng cho Between từ FilterValue đến SecondValue
            public FilterOptions FilterOption { get; set; } = FilterOptions.Contains;
        }

        /// <summary>
        /// Đây là lớp chung
        /// chịu trách nhiệm lọc dữ liệu
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class Filter<T>
        {
            public static IQueryable<T> FilteredData(IEnumerable<FilterParams> filterParams, IQueryable<T> data)
            {
                IEnumerable<string> distinctColumns = filterParams.Where(x => !String.IsNullOrEmpty(x.ColumnName)).Select(x => x.ColumnName).Distinct();
                foreach (string colName in distinctColumns)
                {
                    var filterColumn = typeof(T).GetProperty(colName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
                    if (filterColumn != null)
                    {
                        IEnumerable<FilterParams> filterValues = filterParams.Where(x => x.ColumnName.Equals(colName)).Distinct();
                        if (filterValues.Count() > 1)
                        {
                            foreach (var val in filterValues)
                            {
                                data = FilterData(val.FilterOption, data, filterColumn, val.FilterValue, val.SecondValue);
                            }
                        }
                        else
                        {
                            data = FilterData(filterValues.FirstOrDefault().FilterOption, data, filterColumn, filterValues.FirstOrDefault().FilterValue, filterValues.FirstOrDefault().SecondValue);
                        }
                    }
                }
                return data;
            }

            private static IQueryable<T> FilterData(FilterOptions filterOptions, IQueryable<T> data, PropertyInfo filterColumn, string filterValue, string secondValue)
            {
                int iOutValue, iOutSecondValue;
                double dOutValue, dOutSecondValue;
                DateTime dateValue, dateSecondValue;
                ParameterExpression parameter = Expression.Parameter(typeof(T), "x"); // x
                // Lấy phương thức so sánh mặc định String.Contains
                MethodInfo methodInfo = typeof(string).GetMethod("Contains", new[] { typeof(string) })!;
                var property = Expression.Property(parameter, filterColumn); // x.PropertyName
                switch (filterOptions)
                {
                    #region [StringDataType]
                    case FilterOptions.StartsWith:
                        var notEqualNull = Expression.NotEqual(property, Expression.Constant(null)); // x.PropertyName != null
                        methodInfo = typeof(string).GetMethod("StartsWith", new[] { typeof(string) })!;
                        Expression expression = Expression.Call(property, methodInfo, Expression.Constant(filterValue.ToLower()));
                        // Kết hợp tất cả các node biểu thức lại &&
                        Expression body = Expression.AndAlso(notEqualNull, expression);
                        // Gộp biểu thức body vào trong compile-time-typed lambda expression
                        Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                        data = data.Where(lambda);
                        break;
                    case FilterOptions.EndsWith:
                        notEqualNull = Expression.NotEqual(property, Expression.Constant(null)); // x.PropertyName != null
                        methodInfo = typeof(string).GetMethod("EndsWith", new[] { typeof(string) })!;
                        expression = Expression.Call(property, methodInfo, Expression.Constant(filterValue.ToLower()));
                        // Kết hợp tất cả các note biểu thức lại &&
                        body = Expression.AndAlso(notEqualNull, expression);
                        // Gộp biểu thức body vào trong compile-time-typed lambda expression
                        lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                        data = data.Where(lambda);
                        break;
                    case FilterOptions.Contains:
                        notEqualNull = Expression.NotEqual(property, Expression.Constant(null)); // x.PropertyName != null
                        expression = Expression.Call(property, methodInfo, Expression.Constant(filterValue.ToLower()));
                        // Kết hợp tất cả các note biểu thức lại &&
                        body = Expression.AndAlso(notEqualNull, expression);
                        // Gộp biểu thức body vào trong compile-time-typed lambda expression
                        lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                        data = data.Where(lambda);
                        break;
                    case FilterOptions.DoesNotContain:
                        notEqualNull = Expression.NotEqual(property, Expression.Constant(null)); // x.PropertyName != null
                        var equalNull = Expression.Equal(property, Expression.Constant(null)); // x.PropertyName == null
                        // NotContain !string.Contains("filterValue")
                        expression = Expression.Not(Expression.Call(property, methodInfo, Expression.Constant(filterValue.ToLower())));
                        Expression andExpression = Expression.AndAlso(notEqualNull, expression);
                        body = Expression.OrElse(equalNull, andExpression);
                        lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                        //data = data.Where(x => filterColumn.GetValue(x, null) == null ||
                        //                 (filterColumn.GetValue(x, null) != null && !filterColumn.GetValue(x, null).ToString().ToLower().Contains(filterValue.ToString().ToLower())));
                        data = data.Where(lambda);
                        break;
                    case FilterOptions.IsEmpty:
                        notEqualNull = Expression.NotEqual(property, Expression.Constant(null)); // x.PropertyName != null
                        equalNull = Expression.Equal(property, Expression.Constant(null)); // x.PropertyName == null
                        expression = Expression.Equal(property, Expression.Constant(string.Empty));
                        Expression emptyExpression = Expression.AndAlso(notEqualNull, expression);
                        body = Expression.OrElse(equalNull, emptyExpression);
                        lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                        //data = data.Where(x => filterColumn.GetValue(x, null) == null ||
                        //                 (filterColumn.GetValue(x, null) != null && filterColumn.GetValue(x, null).ToString() == string.Empty));
                        data = data.Where(lambda);
                        break;
                    case FilterOptions.IsNotEmpty:
                        notEqualNull = Expression.NotEqual(property, Expression.Constant(null)); // x.PropertyName != null
                        expression = Expression.NotEqual(property, Expression.Constant(string.Empty));
                        body = Expression.AndAlso(notEqualNull, expression);
                        lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                        //data = data.Where(x => filterColumn.GetValue(x, null) != null && filterColumn.GetValue(x, null).ToString() != string.Empty);
                        data = data.Where(lambda);
                        break;
                    #endregion

                    #region [Custom]
                    case FilterOptions.IsGreaterThan:
                        if ((filterColumn.PropertyType == typeof(Int32) || filterColumn.PropertyType == typeof(Nullable<Int32>)) && Int32.TryParse(filterValue, out iOutValue))
                        {
                            body = Expression.GreaterThan(property, Expression.Constant(iOutValue)); // x.PropertyName > iOutValue
                            lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                            data = data.Where(lambda);
                            break;
                        }
                        else if ((filterColumn.PropertyType == typeof(Double) || filterColumn.PropertyType == typeof(Nullable<Double>)) && Double.TryParse(filterValue, out dOutValue))
                        {
                            body = Expression.GreaterThan(property, Expression.Constant(dOutValue)); // x.PropertyName > dOutValue
                            lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                            data = data.Where(lambda);
                            break;
                        }
                        else if ((filterColumn.PropertyType == typeof(Nullable<DateTime>)) && DateTime.TryParse(filterValue, out dateValue))
                        {
                            body = Expression.GreaterThan(property, Expression.Constant(dateValue)); // x.PropertyName > dateValue
                            lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                            data = data.Where(lambda);
                        }
                        break;

                    case FilterOptions.IsGreaterThanOrEqualTo:
                        if ((filterColumn.PropertyType == typeof(Int32) || filterColumn.PropertyType == typeof(Nullable<Int32>)) && Int32.TryParse(filterValue, out iOutValue))
                        {
                            body = Expression.GreaterThanOrEqual(property, Expression.Constant(iOutValue)); // x.PropertyName >= iOutValue
                            lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                            data = data.Where(lambda);
                            break;
                        }
                        else if ((filterColumn.PropertyType == typeof(Double) || filterColumn.PropertyType == typeof(Nullable<Double>)) && Double.TryParse(filterValue, out dOutValue))
                        {
                            body = Expression.GreaterThanOrEqual(property, Expression.Constant(dOutValue)); // x.PropertyName >= dOutValue
                            lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                            data = data.Where(lambda);
                            break;
                        }
                        else if ((filterColumn.PropertyType == typeof(Nullable<DateTime>)) && DateTime.TryParse(filterValue, out dateValue))
                        {
                            body = Expression.GreaterThanOrEqual(property, Expression.Constant(dateValue)); // x.PropertyName >= dateValue
                            lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                            data = data.Where(lambda);
                        }
                        break;

                    case FilterOptions.IsLessThan:
                        if ((filterColumn.PropertyType == typeof(Int32) || filterColumn.PropertyType == typeof(Nullable<Int32>)) && Int32.TryParse(filterValue, out iOutValue))
                        {
                            body = Expression.LessThan(property, Expression.Constant(iOutValue)); // x.PropertyName < iOutValue
                            lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                            data = data.Where(lambda);
                            break;
                        }
                        else if ((filterColumn.PropertyType == typeof(Double) || filterColumn.PropertyType == typeof(Nullable<Double>)) && Double.TryParse(filterValue, out dOutValue))
                        {
                            body = Expression.LessThan(property, Expression.Constant(dOutValue)); // x.PropertyName < dOutValue
                            lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                            data = data.Where(lambda);
                            break;
                        }
                        else if ((filterColumn.PropertyType == typeof(Nullable<DateTime>)) && DateTime.TryParse(filterValue, out dateValue))
                        {
                            body = Expression.LessThan(property, Expression.Constant(dateValue)); // x.PropertyName < dOutValue
                            lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                            data = data.Where(lambda);
                        }
                        break;

                    case FilterOptions.IsLessThanOrEqualTo:
                        if ((filterColumn.PropertyType == typeof(Int32) || filterColumn.PropertyType == typeof(Nullable<Int32>)) && Int32.TryParse(filterValue, out iOutValue))
                        {
                            body = Expression.LessThanOrEqual(property, Expression.Constant(iOutValue)); // x.PropertyName <= iOutValue
                            lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                            data = data.Where(lambda);
                            break;
                        }
                        else if ((filterColumn.PropertyType == typeof(Double) || filterColumn.PropertyType == typeof(Nullable<Double>)) && Double.TryParse(filterValue, out dOutValue))
                        {
                            body = Expression.LessThanOrEqual(property, Expression.Constant(dOutValue)); // x.PropertyName <= dOutValue
                            lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                            data = data.Where(lambda);
                            break;
                        }
                        else if ((filterColumn.PropertyType == typeof(Nullable<DateTime>)) && DateTime.TryParse(filterValue, out dateValue))
                        {
                            body = Expression.LessThanOrEqual(property, Expression.Constant(dateValue)); // x.PropertyName <= dateValue
                            lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                            data = data.Where(lambda);
                        }
                        break;

                    case FilterOptions.IsEqualTo:
                        if (filterValue == string.Empty)
                        {
                            equalNull = Expression.Equal(property, Expression.Constant(null)); // x.PropertyName == null
                            notEqualNull = Expression.NotEqual(property, Expression.Constant(null)); // x.PropertyName != null
                            expression = Expression.Equal(property, Expression.Constant(string.Empty));
                            emptyExpression = Expression.AndAlso(notEqualNull, expression);
                            body = Expression.OrElse(equalNull, emptyExpression);
                            lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                            //data = data.Where(x => filterColumn.GetValue(x, null) == null
                            //                || (filterColumn.GetValue(x, null) != null && filterColumn.GetValue(x, null).ToString().ToLower() == string.Empty));
                            data = data.Where(lambda);
                        }
                        else
                        {
                            if ((filterColumn.PropertyType == typeof(Int32) || filterColumn.PropertyType == typeof(Nullable<Int32>)) && Int32.TryParse(filterValue, out iOutValue))
                            {
                                body = Expression.Equal(property, Expression.Constant(iOutValue)); // x.PropertyName == iOutValue
                                lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                                data = data.Where(lambda);
                                break;
                            }
                            else if ((filterColumn.PropertyType == typeof(Double) || filterColumn.PropertyType == typeof(Nullable<Double>)) && Double.TryParse(filterValue, out dOutValue))
                            {
                                body = Expression.Equal(property, Expression.Constant(dOutValue)); // x.PropertyName == dOutValue
                                lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                                data = data.Where(lambda);
                                break;
                            }
                            else if ((filterColumn.PropertyType == typeof(Nullable<DateTime>)) && DateTime.TryParse(filterValue, out dateValue))
                            {
                                body = Expression.Equal(property, Expression.Constant(dateValue)); // x.PropertyName == dateValue
                                lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                                data = data.Where(lambda);
                                break;
                            }
                            else
                            {
                                body = Expression.Equal(property, Expression.Constant(filterValue)); // x.PropertyName == filterValue
                                lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                                data = data.Where(lambda);
                            }
                        }
                        break;

                    case FilterOptions.IsNotEqualTo:
                        if ((filterColumn.PropertyType == typeof(Int32) || filterColumn.PropertyType == typeof(Nullable<Int32>)) && Int32.TryParse(filterValue, out iOutValue))
                        {
                            body = Expression.NotEqual(property, Expression.Constant(iOutValue)); // x.PropertyName != iOutValue
                            lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                            data = data.Where(lambda);
                            break;
                        }
                        else if ((filterColumn.PropertyType == typeof(Double) || filterColumn.PropertyType == typeof(Nullable<Double>)) && Double.TryParse(filterValue, out dOutValue))
                        {
                            body = Expression.NotEqual(property, Expression.Constant(dOutValue)); // x.PropertyName != dOutValue
                            lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                            data = data.Where(lambda);
                            break;
                        }
                        else if ((filterColumn.PropertyType == typeof(Nullable<DateTime>)) && DateTime.TryParse(filterValue, out dateValue))
                        {
                            body = Expression.NotEqual(property, Expression.Constant(dateValue)); // x.PropertyName != dateValue
                            lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                            data = data.Where(lambda);
                            break;
                        }
                        else
                        {
                            equalNull = Expression.Equal(property, Expression.Constant(null)); // x.PropertyName == null
                            notEqualNull = Expression.NotEqual(property, Expression.Constant(null)); // x.PropertyName != null
                            expression = Expression.NotEqual(property, Expression.Constant(filterValue)); // x.PropertyName != filterValue
                            emptyExpression = Expression.AndAlso(notEqualNull, expression);
                            body = Expression.OrElse(equalNull, emptyExpression);
                            lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                            //data = data.Where(x => filterColumn.GetValue(x, null) == null ||
                            //                 (filterColumn.GetValue(x, null) != null && filterColumn.GetValue(x, null).ToString().ToLower() != filterValue.ToLower()));
                            data = data.Where(lambda);
                        }
                        break;

                    case FilterOptions.Between:
                        if ((filterColumn.PropertyType == typeof(Int32) || filterColumn.PropertyType == typeof(Nullable<Int32>)) && Int32.TryParse(filterValue, out iOutValue) && Int32.TryParse(secondValue, out iOutSecondValue))
                        {
                            Expression left = Expression.GreaterThanOrEqual(property, Expression.Constant(iOutValue)); // x.PropertyName >= iOutValue
                            Expression right = Expression.LessThanOrEqual(property, Expression.Constant(iOutSecondValue)); // x.PropertyName <= iOutSecondValue
                            body = Expression.AndAlso(left, right);
                            lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                            data = data.Where(lambda);
                            break;
                        }
                        else if((filterColumn.PropertyType == typeof(Double) || filterColumn.PropertyType == typeof(Nullable<Double>)) && Double.TryParse(filterValue, out dOutValue) && Double.TryParse(secondValue, out dOutSecondValue))
                        {
                            Expression left = Expression.GreaterThanOrEqual(property, Expression.Constant(dOutValue)); // x.PropertyName >= dOutValue
                            Expression right = Expression.LessThanOrEqual(property, Expression.Constant(dOutSecondValue)); // x.PropertyName <= dOutSecondValue
                            body = Expression.AndAlso(left, right);
                            lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                            data = data.Where(lambda);
                            break;
                        }
                        else if ((filterColumn.PropertyType == typeof(Nullable<DateTime>)) && DateTime.TryParse(filterValue, out dateValue) && DateTime.TryParse(secondValue, out dateSecondValue))
                        {
                            dateSecondValue = dateSecondValue.Date.AddMinutes(1439);
                            Expression left = Expression.GreaterThanOrEqual(property, Expression.Constant(dateValue)); // x.PropertyName >= dateValue
                            Expression right = Expression.LessThanOrEqual(property, Expression.Constant(dateSecondValue)); // x.PropertyName <= dateSecondValue
                            body = Expression.AndAlso(left, right);
                            lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                            data = data.Where(lambda);
                        }
                        break;
                        #endregion
                }
                return data;
            }
        }
    }
}
