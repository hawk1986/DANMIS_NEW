#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Generated at 04/16/2021 12:13:09
//     Runtime Version: 4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Extensions;
using DANMIS_NEW.Interface;
using DANMIS_NEW.Models;
using DANMIS_NEW.ViewModel;
using DANMIS_NEW.ViewModel.ListResult;
using DANMIS_NEW.ViewModel.SearchModel;
using ResourceLibrary;

namespace DANMIS_NEW.Manager
{
    public class CandidateManager : ICandidateManager
    {
        readonly ICandidateRepository _candidateRepository;

        public CandidateManager(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        /// <summary>
        /// 建立 Candidate
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void Create(CandidateViewModel entity)
        {
            var item = (Candidate)entity;

            using (var transaction = _candidateRepository.dbContext.Database.BeginTransaction())
            {
                try
                {
                    _candidateRepository.Create(item);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// 根據 id 刪除 Candidate
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void Delete(List<Guid> id)
        {
            using (var transaction = _candidateRepository.dbContext.Database.BeginTransaction())
            {
                try
                {
                    var itemSet = _candidateRepository.Where(x => id.Contains(x.ID)).ToList();
                    if (itemSet.Any())
                    {
                        foreach (var item in itemSet)
                        {
                            _candidateRepository.Delete(item);
                        }
                    }
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// 根據 id 取得 Candidate
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CandidateViewModel GetByID(Guid id)
        {
            var item = _candidateRepository.GetByID(id);
            var result = (CandidateViewModel)item;

            return result;
        }

        public CandidateViewModel GetByWDID(string id)
        {
            var item = _candidateRepository.GetAll().FirstOrDefault(x => x.WDID == id);
            var result = (CandidateViewModel)item;

            return result;
        }

        /// <summary>
        /// 分頁
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public Paging<CandidateListResult> Paging(CandidateSearchModel searchModel)
        {
            // 預設集合
            var temp = _candidateRepository.GetAll();

            // 將 DB 資料轉換為列表頁呈現資料
            var tempResult = from x in temp
                             select new CandidateListResult
                             {
                                 SequenceNo = x.SequenceNo,
                                 ID = x.ID,
                                 WDID = x.WDID,
                                 FirstName = x.FirstName,
                                 LastName = x.LastName,
                                 PreferredName = x.PreferredName,
                                 Company = x.Company,
                             };

            // 如有篩選條件，進行篩選
            if (!string.IsNullOrWhiteSpace(searchModel.Search))
            {
                var search = searchModel.Search.ToLower();
                tempResult = tempResult.Where(x =>
                    x.WDID.Contains(search) ||
                    x.FirstName.Contains(search) ||
                    x.LastName.Contains(search) ||
                    x.PreferredName.Contains(search) ||
                    x.Company.Contains(search) ||
                    false);
            }
            if (!string.IsNullOrWhiteSpace(searchModel.CompCode))            
                tempResult = tempResult.Where(x =>            
                    x.Company.Contains(searchModel.CompCode) ||
                    false);

            if (!string.IsNullOrWhiteSpace(searchModel.WDID))
                tempResult = tempResult.Where(x =>
                    x.WDID != searchModel.WDID ||
                    false);

            if (!string.IsNullOrWhiteSpace(searchModel.SearchName))
                tempResult = tempResult.Where(x =>
                    x.PreferredName.Contains(searchModel.SearchName) ||
                    false);

            // 進行分頁處理
            var result = new Paging<CandidateListResult>();
            result.total = tempResult.Count();
            result.rows = tempResult
                .OrderBy(searchModel.Sort, searchModel.Order)
                .OrderBy(x => x.PreferredName)
                //.Skip(searchModel.Offset)
                //.Take(searchModel.Limit)
                .ToList();

            return result;
        }

        /// <summary>
        /// 更新 Candidate
        /// </summary>
        /// <param name="entity"></param>
        public void Update(CandidateViewModel entity)
        {
            using (var transaction = _candidateRepository.dbContext.Database.BeginTransaction())
            {
                try
                {
                    var source = _candidateRepository.GetByID(entity.ID);
                    source.WDID = entity.WDID ?? string.Empty;
                    source.FirstName = entity.FirstName ?? string.Empty;
                    source.LastName = entity.LastName ?? string.Empty;
                    source.PreferredName = entity.PreferredName ?? string.Empty;
                    source.Company = entity.Company ?? string.Empty;

                    _candidateRepository.Update(source);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
#pragma warning restore 1591