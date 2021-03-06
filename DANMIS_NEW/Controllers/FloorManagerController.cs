#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Generated at 05/05/2021 16:39:11
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
    public class FloorManagerController : BaseController
    {
        readonly ICommonManager _commonManager;
        readonly IFloorManagerManager _floorManagerManager;
        readonly IUserManager _userManager;
        readonly IBrandManager _brandManager;

        public FloorManagerController(
            ICommonManager commonManager,
            IFloorManagerManager floorManagerManager,
            IUserManager userManager,
            IBrandManager brandManager)
        {
            _commonManager = commonManager;
            _floorManagerManager = floorManagerManager;
            _userManager = userManager;
            _brandManager = brandManager;
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
            var searchModel = new FloorManagerSearchModel();
            if (null != UnobtrusiveSession.Session["QueryModel"])
            {
                // 查詢條件存在 session 則取出
                var temp = UnobtrusiveSession.Session["QueryModel"] as FloorManagerSearchModel;
                if (null != temp)
                {
                    searchModel = temp;
                }
            }
            // 初始化查詢下拉選單
            searchModel.YesNoList = _commonManager.GetYesNoList();

            return View(searchModel);
        }

        /// <summary>
        /// 分頁
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        [WebAuthorize(Code = "FloorManagerIndex")]
        [HttpPost]
        public ActionResult Paging(FloorManagerSearchModel searchModel)
        {
            // 查詢條件儲存於 session
            UnobtrusiveSession.Session["QueryModel"] = searchModel;
            // 查詢結果物件初始化
            var result = new Paging<FloorManagerListResult> { total = 0, rows = null };
            // 查詢
            try
            {
                result = _floorManagerManager.Paging(searchModel);
            }
            catch (Exception ex)
            {
                logger.Error(ex, string.Format(Resource.PagingError, Resource.FloorManager));
            }

            return Json(result);
        }

        /// <summary>
        /// 檢視 FloorManager 頁面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [WebAuthorize]
        [HttpGet]
        public ActionResult Details(Guid? id)
        {
            FloorManagerViewModel viewModel = null;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                try
                {
                    // 讀取資料
                    viewModel = _floorManagerManager.GetByID(id.Value);
                    if (null == viewModel)
                    {
                        // 查無資料
                        logger.Error(string.Format(Resource.NoData, Resource.FloorManager, id.Value));
                        TempData["ErrorMsg"] = new JsonMessage { Style = "danger", Message = string.Format(Resource.NoData, Resource.FloorManager, id.Value) }.ToString();
                    }
                }
                catch (Exception ex)
                {
                    // 查詢發生錯誤
                    logger.Error(ex, string.Format(Resource.GetDetailsDataError, Resource.FloorManager, id.Value));
                    TempData["ErrorMsg"] = new JsonMessage { Style = "danger", Message = string.Format(Resource.GetDetailsDataError, Resource.FloorManager, id.Value) }.ToString();
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
        /// 新增 FloorManager 頁面
        /// </summary>
        /// <returns></returns>
        [WebAuthorize]
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new FloorManagerViewModel();
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
        public ActionResult Create(FloorManagerViewModel viewModel)
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
                    _floorManagerManager.Create(viewModel);
                    UnobtrusiveSession.Session["QueryModel"] = null;
                    // 完成
                    TempData["ErrorMsg"] = new JsonMessage { Style = "success", Message = string.Format(Resource.ExecutionCompleted, Resource.Create, Resource.FloorManager) }.ToString();
                    // 轉回列表頁
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // 儲存發生錯誤
                    logger.Error(ex, string.Format(Resource.ExecutionFailedWithID, Resource.Create, Resource.FloorManager, viewModel.ID));
                    TempData["ErrorMsg"] = new JsonMessage { Style = "danger", Message = string.Format(Resource.ExecutionFailedWithID, Resource.Create, Resource.FloorManager, viewModel.ID) }.ToString();
                }
            }
            // 初始化新增頁面下拉選單
            setDropDownList(ref viewModel);

            return View(viewModel);
        }

        /// <summary>
        /// 修改 FloorManager 頁面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [WebAuthorize]
        [HttpGet]
        public ActionResult Edit(Guid? id)
        {
            FloorManagerViewModel viewModel = null;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                try
                {
                    // 讀取資料
                    viewModel = _floorManagerManager.GetByID(id.Value);
                    if (null == viewModel)
                    {
                        // 查無資料
                        logger.Error(string.Format(Resource.NoData, Resource.FloorManager, id.Value));
                        TempData["ErrorMsg"] = new JsonMessage { Style = "danger", Message = string.Format(Resource.NoData, Resource.FloorManager, id.Value) }.ToString();
                    }
                }
                catch (Exception ex)
                {
                    // 查詢發生錯誤
                    logger.Error(ex, string.Format(Resource.GetEditDataError, Resource.FloorManager, id.Value));
                    TempData["ErrorMsg"] = new JsonMessage { Style = "danger", Message = string.Format(Resource.GetEditDataError, Resource.FloorManager, id.Value) }.ToString();
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
        public ActionResult Edit(FloorManagerViewModel viewModel)
        {
            // 驗證
            if (ModelState.IsValid)
            {
                try
                {
                    viewModel.UpdateUser = UserName;
                    viewModel.UpdateTime = NowTime;
                    _floorManagerManager.Update(viewModel);
                    // 完成
                    TempData["ErrorMsg"] = new JsonMessage { Style = "success", Message = string.Format(Resource.ExecutionCompleted, Resource.Edit, Resource.FloorManager) }.ToString();
                    // 轉回列表頁
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // 儲存發生錯誤
                    logger.Error(ex, string.Format(Resource.ExecutionFailedWithID, Resource.Edit, Resource.FloorManager, viewModel.ID));
                    TempData["ErrorMsg"] = new JsonMessage { Style = "danger", Message = string.Format(Resource.ExecutionFailedWithID, Resource.Edit, Resource.FloorManager, viewModel.ID) }.ToString();
                }
            }
            // 初始化編輯頁面下拉選單
            setDropDownList(ref viewModel);

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
                    _floorManagerManager.Delete(id);
                    result = true;
                }
                catch (Exception ex)
                {
                    // 刪除失敗
                    logger.Error(ex, string.Format(Resource.ExecutionFailed, Resource.Delete, Resource.FloorManager, id));
                }
            }

            return Json(result);
        }

        /// <summary>
        /// 設定頁面所需要的下拉選單資料
        /// </summary>
        /// <param name="viewModel"></param>
        void setDropDownList(ref FloorManagerViewModel viewModel)
        {
            viewModel._Users = _userManager.GetSelectList();
            viewModel._Brand = _brandManager.GetSelectList();
            viewModel.YesNoList = _commonManager.GetYesNoList();
        }
    }
}
#pragma warning restore 1591