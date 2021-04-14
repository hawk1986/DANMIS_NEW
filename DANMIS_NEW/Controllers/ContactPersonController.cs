#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Generated at 04/12/2021 15:45:16
//     Runtime Version: 4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using NLog;
using ResourceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Utilities;
using Utilities.Attribute;
using Utilities.Utility;
using DANMIS_NEW.Interface;
using DANMIS_NEW.ViewModel;
using DANMIS_NEW.ViewModel.ListResult;
using DANMIS_NEW.ViewModel.SearchModel;

namespace DANMIS_NEW.Controllers
{
    public class ContactPersonController : BaseController
    {
        readonly ICommonManager _commonManager;
        readonly IContactPersonManager _contactPersonManager;

        public ContactPersonController(
            ICommonManager commonManager,
            IContactPersonManager contactPersonManager)
        {
            _commonManager = commonManager;
            _contactPersonManager = contactPersonManager;
            logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// 首頁
        /// </summary>
        /// <returns></returns>
        [WebAuthorize]
        [HttpGet]
        public ActionResult Index()
        {
            // 初始化查詢物件
            var searchModel = new ContactPersonSearchModel();
            if (null != UnobtrusiveSession.Session["QueryModel"])
            {
                // 查詢條件存在 session 則取出
                var temp = UnobtrusiveSession.Session["QueryModel"] as ContactPersonSearchModel;
                if (null != temp)
                {
                    searchModel = temp;
                }
            }

            return View(searchModel);
        }

        /// <summary>
        /// 分頁
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        [WebAuthorize(Code = "ContactPersonIndex")]
        [HttpPost]
        public ActionResult Paging(ContactPersonSearchModel searchModel)
        {
            // 查詢條件儲存於 session
            UnobtrusiveSession.Session["QueryModel"] = searchModel;
            // 查詢結果物件初始化
            var result = new Paging<ContactPersonListResult> { total = 0, rows = null };
            // 查詢
            try
            {
                result = _contactPersonManager.Paging(searchModel);
            }
            catch (Exception ex)
            {
                logger.Error(ex, string.Format(Resource.PagingError, Resource.ContactPerson));
            }

            return Json(result);
        }

        /// <summary>
        /// 檢視 ContactPerson 頁面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [WebAuthorize]
        [HttpGet]
        public ActionResult Details(Guid? id)
        {
            ContactPersonViewModel viewModel = null;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                try
                {
                    // 讀取資料
                    viewModel = _contactPersonManager.GetByID(id.Value);
                    if (null == viewModel)
                    {
                        // 查無資料
                        logger.Error(string.Format(Resource.NoData, Resource.ContactPerson, id.Value));
                        TempData["ErrorMsg"] = new JsonMessage { Style = "danger", Message = string.Format(Resource.NoData, Resource.ContactPerson, id.Value) }.ToString();
                    }
                }
                catch (Exception ex)
                {
                    // 查詢發生錯誤
                    logger.Error(ex, string.Format(Resource.GetDetailsDataError, Resource.ContactPerson, id.Value));
                    TempData["ErrorMsg"] = new JsonMessage { Style = "danger", Message = string.Format(Resource.GetDetailsDataError, Resource.ContactPerson, id.Value) }.ToString();
                }
            }
            else
            {
                // 參數錯誤
                logger.Error(string.Format(Resource.ParamError, Resource.Details));
                TempData["ErrorMsg"] = new JsonMessage { Style = "danger", Message = string.Format(Resource.ParamError, Resource.Details) }.ToString();
            }
            // 查無資料轉回列表頁
            if (null == viewModel)
            {
                return RedirectToAction("Index");
            }
            // 初始化檢視頁面下拉選單
            setDropDownList(ref viewModel);

            return View(viewModel);
        }

        /// <summary>
        /// 新增 ContactPerson 頁面
        /// </summary>
        /// <returns></returns>
        [WebAuthorize]
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new ContactPersonViewModel();
            // 初始化編輯頁面下拉選單
            setDropDownList(ref viewModel);

            return View(viewModel);
        }

        /// <summary>
        /// 新增資料儲存
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [WebAuthorize]
        [HttpPost]
        public ActionResult Create(ContactPersonViewModel viewModel)
        {
            // 驗證
            if (ModelState.IsValid)
            {
                try
                {
                    viewModel.ID = Guid.NewGuid();
                    viewModel.CreateUser = UserName;
                    viewModel.CreateTime = NowTime;
                    viewModel.UpdateUser = UserName;
                    viewModel.UpdateTime = NowTime;
                    _contactPersonManager.Create(viewModel);
                    UnobtrusiveSession.Session["QueryModel"] = null;
                    // 完成
                    TempData["ErrorMsg"] = new JsonMessage { Style = "success", Message = string.Format(Resource.ExecutionCompleted, Resource.Create, Resource.ContactPerson) }.ToString();
                    // 轉回列表頁
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // 儲存發生錯誤
                    logger.Error(ex, string.Format(Resource.ExecutionFailedWithID, Resource.Create, Resource.ContactPerson, viewModel.ID));
                    TempData["ErrorMsg"] = new JsonMessage { Style = "danger", Message = string.Format(Resource.ExecutionFailedWithID, Resource.Create, Resource.ContactPerson, viewModel.ID) }.ToString();
                }
            }
            // 初始化新增頁面下拉選單
            setDropDownList(ref viewModel);

            return View(viewModel);
        }

        /// <summary>
        /// 修改 ContactPerson 頁面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [WebAuthorize]
        [HttpGet]
        public ActionResult Edit(Guid? id)
        {
            ContactPersonViewModel viewModel = null;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                try
                {
                    // 讀取資料
                    viewModel = _contactPersonManager.GetByID(id.Value);
                    if (null == viewModel)
                    {
                        // 查無資料
                        logger.Error(string.Format(Resource.NoData, Resource.ContactPerson, id.Value));
                        TempData["ErrorMsg"] = new JsonMessage { Style = "danger", Message = string.Format(Resource.NoData, Resource.ContactPerson, id.Value) }.ToString();
                    }
                }
                catch (Exception ex)
                {
                    // 查詢發生錯誤
                    logger.Error(ex, string.Format(Resource.GetEditDataError, Resource.ContactPerson, id.Value));
                    TempData["ErrorMsg"] = new JsonMessage { Style = "danger", Message = string.Format(Resource.GetEditDataError, Resource.ContactPerson, id.Value) }.ToString();
                }
            }
            else
            {
                // 參數錯誤
                logger.Error(string.Format(Resource.ParamError, Resource.Edit));
                TempData["ErrorMsg"] = new JsonMessage { Style = "danger", Message = string.Format(Resource.ParamError, Resource.Edit) }.ToString();
            }
            // 查無資料轉回列表頁
            if (null == viewModel)
            {
                return RedirectToAction("Index");
            }
            // 初始化編輯頁面下拉選單
            setDropDownList(ref viewModel);

            return View("Create", viewModel);
        }

        /// <summary>
        /// 編輯資料儲存
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [WebAuthorize]
        [HttpPost]
        public ActionResult Edit(ContactPersonViewModel viewModel)
        {
            // 驗證
            if (ModelState.IsValid)
            {
                try
                {
                    viewModel.UpdateUser = UserName;
                    viewModel.UpdateTime = NowTime;
                    _contactPersonManager.Update(viewModel);
                    // 完成
                    TempData["ErrorMsg"] = new JsonMessage { Style = "success", Message = string.Format(Resource.ExecutionCompleted, Resource.Edit, Resource.ContactPerson) }.ToString();
                    // 轉回列表頁
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // 儲存發生錯誤
                    logger.Error(ex, string.Format(Resource.ExecutionFailedWithID, Resource.Edit, Resource.ContactPerson, viewModel.ID));
                    TempData["ErrorMsg"] = new JsonMessage { Style = "danger", Message = string.Format(Resource.ExecutionFailedWithID, Resource.Edit, Resource.ContactPerson, viewModel.ID) }.ToString();
                }
            }
            // 初始化編輯頁面下拉選單
            //setDropDownList(ref viewModel);

            return View("Create", viewModel);
        }

        /// <summary>
        /// 刪除機構資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [WebAuthorize]
        [HttpPost]
        public ActionResult Delete(List<Guid> id)
        {
            // 預設失敗
            var result = false;
            // id 有值進行刪除作業
            if (id != null && id.Any())
            {
                try
                {
                    // 進行刪除
                    _contactPersonManager.Delete(id);
                    result = true;
                }
                catch (Exception ex)
                {
                    // 刪除失敗
                    logger.Error(ex, string.Format(Resource.ExecutionFailed, Resource.Delete, Resource.ContactPerson, id));
                }
            }

            return Json(result);
        }

        [HttpPost]
        public ActionResult EditAJAX(ContactPersonViewModel viewModel)
        {
            var result = Json(new { result = false }, JsonRequestBehavior.AllowGet);
            // 驗證
            if (ModelState.IsValid)
            {
                try
                {
                    viewModel.UpdateUser = UserName;
                    viewModel.UpdateTime = NowTime;
                    _contactPersonManager.Update(viewModel);

                    // 完成
                    result = Json(new { result = true }, JsonRequestBehavior.AllowGet);
                    
                }
                catch (Exception ex)
                {
                    // 儲存發生錯誤
                    logger.Error(ex, string.Format(Resource.ExecutionFailedWithID, Resource.Edit, Resource.ContactPerson, viewModel.ID));
                    TempData["ErrorMsg"] = new JsonMessage { Style = "danger", Message = string.Format(Resource.ExecutionFailedWithID, Resource.Edit, Resource.ContactPerson, viewModel.ID) }.ToString();
                }
            }

            return result;
        }

        [HttpPost]
        public ActionResult CreateAJAX(ContactPersonViewModel viewModel)
        {
            var result = Json(new { result = false }, JsonRequestBehavior.AllowGet);
            // 驗證
            if (ModelState.IsValid)
            {
                try
                {
                    viewModel.ID = Guid.NewGuid();
                    viewModel.CreateUser = UserName;
                    viewModel.CreateTime = NowTime;
                    viewModel.UpdateUser = UserName;
                    viewModel.UpdateTime = NowTime;
                    _contactPersonManager.Create(viewModel);
                    UnobtrusiveSession.Session["QueryModel"] = null;

                    // 完成
                    result = Json(new { result = true }, JsonRequestBehavior.AllowGet);
                    
                }
                catch (Exception ex)
                {
                    // 儲存發生錯誤
                    logger.Error(ex, string.Format(Resource.ExecutionFailedWithID, Resource.Create, Resource.ContactPerson, viewModel.ID));
                    TempData["ErrorMsg"] = new JsonMessage { Style = "danger", Message = string.Format(Resource.ExecutionFailedWithID, Resource.Create, Resource.ContactPerson, viewModel.ID) }.ToString();
                }
            }            

            return result;
        }

        [HttpPost]
        public ActionResult DeleteAJAX(List<Guid> id)
        {
            // 預設失敗
            var result = Json(new { result = false }, JsonRequestBehavior.AllowGet);
            // id 有值進行刪除作業
            if (id != null && id.Any())
            {
                try
                {
                    // 進行刪除
                    _contactPersonManager.Delete(id);

                    // 完成
                    result = Json(new { result = true }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    // 刪除失敗
                    logger.Error(ex, string.Format(Resource.ExecutionFailed, Resource.Delete, Resource.ContactPerson, id));
                }
            }

            return result;
        }

        /// <summary>
        /// 設定頁面所需要的下拉選單資料
        /// </summary>
        /// <param name="viewModel"></param>
        void setDropDownList(ref ContactPersonViewModel viewModel)
        {
            
        }

        
    }
}
#pragma warning restore 1591