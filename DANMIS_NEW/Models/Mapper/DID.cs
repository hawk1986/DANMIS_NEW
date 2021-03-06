#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Generated at 04/28/2021 11:03:08
//       Runtime Version: 4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using DANMIS_NEW.ViewModel;

namespace DANMIS_NEW.Models
{
    public partial class DID
    {
        /// <summary>
        /// 將 ViewModel 轉換為 Model 物件
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DID Convert(DIDViewModel source)
        {
            return source == null ? null : new DID
            {
                SequenceNo = source.SequenceNo,
                ID = source.ID,
                DID1 = source.DID1 ?? string.Empty,
                Brand = source.Brand ?? string.Empty,
                WDID = source.WDID ?? string.Empty,
                Memo = source.Memo ?? string.Empty,
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
        public static DIDViewModel Convert(DID source)
        {
            return source == null ? null : new DIDViewModel
            {
                SequenceNo = source.SequenceNo,
                ID = source.ID,
                DID1 = source.DID1 ?? string.Empty,
                Brand = source.Brand ?? string.Empty,
                WDID = source.WDID ?? string.Empty,
                Memo = source.Memo ?? string.Empty,
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
        public static explicit operator DID(DIDViewModel source)
        {
            return Convert(source);
        }

        /// <summary>
        /// 轉換運算子
        /// </summary>
        /// <param name="source"></param>
        public static explicit operator DIDViewModel(DID source)
        {
            return Convert(source);
        }
    }
}
#pragma warning restore 1591