#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Generated at 04/28/2021 16:57:48
//       Runtime Version: 4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using DANMIS_NEW.ViewModel;

namespace DANMIS_NEW.Models
{
    public partial class ItemClass
    {
        /// <summary>
        /// 將 ViewModel 轉換為 Model 物件
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ItemClass Convert(ItemClassViewModel source)
        {
            return source == null ? null : new ItemClass
            {
                SequenceNo = source.SequenceNo,
                ID = source.ID,
                ClassName = source.ClassName ?? string.Empty,
                Order = source.Order,
                IsForUser = source.IsForUser,
                IsEnable = source.IsEnable,
                CreateUser = source.CreateUser ?? string.Empty,
                CreateTime = source.CreateTime,
                UpdateUser = source.UpdateUser ?? string.Empty,
                UpdateTime = source.UpdateTime,
            };
        }

        /// <summary>
        /// 將 Model 轉換為 ViewModel 物件
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ItemClassViewModel Convert(ItemClass source)
        {
            return source == null ? null : new ItemClassViewModel
            {
                SequenceNo = source.SequenceNo,
                ID = source.ID,
                ClassName = source.ClassName ?? string.Empty,
                Order = source.Order,
                IsForUser = source.IsForUser,
                IsEnable = source.IsEnable,
                CreateUser = source.CreateUser ?? string.Empty,
                CreateTime = source.CreateTime,
                UpdateUser = source.UpdateUser ?? string.Empty,
                UpdateTime = source.UpdateTime,
            };
        }

        /// <summary>
        /// 轉換運算子
        /// </summary>
        /// <param name="source"></param>
        public static explicit operator ItemClass(ItemClassViewModel source)
        {
            return Convert(source);
        }

        /// <summary>
        /// 轉換運算子
        /// </summary>
        /// <param name="source"></param>
        public static explicit operator ItemClassViewModel(ItemClass source)
        {
            return Convert(source);
        }
    }
}
#pragma warning restore 1591