#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Generated at 05/10/2021 10:24:53
//       Runtime Version: 4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using DANMIS_NEW.ViewModel;

namespace DANMIS_NEW.Models
{
    public partial class ItemsApply
    {
        /// <summary>
        /// 將 ViewModel 轉換為 Model 物件
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ItemsApply Convert(ItemsApplyViewModel source)
        {
            return source == null ? null : new ItemsApply
            {
                SequenceNo = source.SequenceNo,
                ID = source.ID,
                ItemID = source.ItemID,
                Qty = source.Qty,
                ApplyWDID = source.ApplyWDID ?? string.Empty,
                ApplyBrand = source.ApplyBrand ?? string.Empty,
                Status = source.Status ?? string.Empty,
                Memo = source.Memo ?? string.Empty,
                ConfirmID = source.ConfirmID,
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
        public static ItemsApplyViewModel Convert(ItemsApply source)
        {
            return source == null ? null : new ItemsApplyViewModel
            {
                SequenceNo = source.SequenceNo,
                ID = source.ID,
                ItemID = source.ItemID,
                Qty = source.Qty,
                ApplyWDID = source.ApplyWDID ?? string.Empty,
                ApplyBrand = source.ApplyBrand ?? string.Empty,
                Status = source.Status ?? string.Empty,
                Memo = source.Memo ?? string.Empty,
                ConfirmID = source.ConfirmID,
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
        public static explicit operator ItemsApply(ItemsApplyViewModel source)
        {
            return Convert(source);
        }

        /// <summary>
        /// 轉換運算子
        /// </summary>
        /// <param name="source"></param>
        public static explicit operator ItemsApplyViewModel(ItemsApply source)
        {
            return Convert(source);
        }
    }
}
#pragma warning restore 1591