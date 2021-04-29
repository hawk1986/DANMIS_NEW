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
    public partial class FactoryItems
    {
        /// <summary>
        /// 將 ViewModel 轉換為 Model 物件
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static FactoryItems Convert(FactoryItemsViewModel source)
        {
            return source == null ? null : new FactoryItems
            {
                SequenceNo = source.SequenceNo,
                ID = source.ID,
                ItemName = source.ItemName ?? string.Empty,
                ItemSpecification = source.ItemSpecification ?? string.Empty,
                ItemClass = source.ItemClass ?? string.Empty,
                ItemUnit = source.ItemUnit ?? string.Empty,
                ItemPrice = source.ItemPrice,
                ItemQty = source.ItemQty,
                Factory = source.Factory ?? string.Empty,
                IsInventoryMgmt = source.IsInventoryMgmt,
                IsForStationery = source.IsForStationery,
                IsForColleague = source.IsForColleague,
                IsAttached = source.IsAttached,
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
        public static FactoryItemsViewModel Convert(FactoryItems source)
        {
            return source == null ? null : new FactoryItemsViewModel
            {
                SequenceNo = source.SequenceNo,
                ID = source.ID,
                ItemName = source.ItemName ?? string.Empty,
                ItemSpecification = source.ItemSpecification ?? string.Empty,
                ItemClass = source.ItemClass ?? string.Empty,
                ItemUnit = source.ItemUnit ?? string.Empty,
                ItemPrice = source.ItemPrice,
                ItemQty = source.ItemQty,
                Factory = source.Factory ?? string.Empty,
                IsInventoryMgmt = source.IsInventoryMgmt,
                IsForStationery = source.IsForStationery,
                IsForColleague = source.IsForColleague,
                IsAttached = source.IsAttached,
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
        public static explicit operator FactoryItems(FactoryItemsViewModel source)
        {
            return Convert(source);
        }

        /// <summary>
        /// 轉換運算子
        /// </summary>
        /// <param name="source"></param>
        public static explicit operator FactoryItemsViewModel(FactoryItems source)
        {
            return Convert(source);
        }
    }
}
#pragma warning restore 1591