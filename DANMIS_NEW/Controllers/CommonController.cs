using DANMIS_NEW.Interface;
using DANMIS_NEW.ViewModel;
using DANMIS_NEW.ViewModel.ListResult;
using ResourceLibrary;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Utilities.Attribute;

namespace DANMIS_NEW.Controllers
{
    public class CommonController : BaseController
    {
        readonly IUserProfileManager _userProfileManager;

        public CommonController(IUserProfileManager userProfileManager)
        {
            _userProfileManager = userProfileManager;
        }

        /// <summary>
        /// get table list fields
        /// </summary>
        /// <param name="functionName"></param>
        /// <returns></returns>
        [WebAuthorize(Code = "Pass")]
        [HttpGet]
        public ActionResult GetColumn(string functionName)
        {
            var result = new List<ListOption>();
            var profile = _userProfileManager.GetByUserIDAndFunction(ID.Value, functionName);
            if (null != profile && profile.ListOption != null && profile.ListOption.Count > 0)
            {
                result = profile.ListOption;
            }
            else
            {
                switch (functionName)
                {
                    case "brandItemsMgmt":
                        result = new List<ListOption>
                        {
                            new ListOption{ checkbox = true, sortable = false, visible = true },
                            new ListOption{ field = "BrandName", title = Resource.Brand },                            
                        };
                        break;
                    case "contactPerson":
                        result = new List<ListOption>
                        {
                            new ListOption{ checkbox = false, sortable = false, visible = false },
                            new ListOption{ field = "Name", title = Resource.ContactPerson },
                            new ListOption{ field = "TEL", title = Resource.TEL },
                            new ListOption{ field = "FAX", title = Resource.FAX },
                            new ListOption{ field = "CellPhone", title = Resource.CellPhone },
                            new ListOption{ field = "Email", title = Resource.Email },
                            new ListOption{ field = "IsShow", title = Resource.IsShow, formatter = "BitFormatter" },
                        };
                        break;
                    case "department":
                        result = new List<ListOption>
                        {
                            new ListOption{ checkbox = true, sortable = false, visible = true },
                            new ListOption{ field = "DepartmentParent", title = Resource.DepartmentParent },
                            new ListOption{ field = "Name", title = Resource.Name },
                            new ListOption{ field = "DepartmentLevel", title = Resource.DepartmentLevel },
                            new ListOption{ field = "DepartmentHead", title = Resource.DepartmentHead },
                            new ListOption{ field = "Sequence", title = Resource.Sequence },
                            new ListOption{ field = "IsEnable", title = Resource.IsEnable, formatter = "BitFormatter" },
                            new ListOption{ field = "UpdateUser", title = Resource.UpdateUser },
                            new ListOption{ field = "UpdateTime", title = Resource.UpdateTime, formatter = "JsonTimeFormatter" },
                        };
                        break;
                    case "dID":
                        result = new List<ListOption>
                        {
                            new ListOption{ checkbox = true, sortable = false, visible = true },
                            new ListOption{ field = "DID1", title = Resource.DIDNumber },
                            new ListOption{ field = "Brand", title = Resource.Brand },
                            new ListOption{ field = "User", title = Resource.User },
                            new ListOption{ field = "Email", title = Resource.Email },
                            new ListOption{ field = "UpdateUser", title = Resource.UpdateUser },
                            new ListOption{ field = "UpdateTime", title = Resource.UpdateTime, formatter = "JsonDateFormatter" },
                        };
                        break;
                    case "dIDAndHeadphone":
                        result = new List<ListOption>
                        {
                            new ListOption{ checkbox = true, sortable = false, visible = true },
                            new ListOption{ field = "Brand", title = Resource.Brand },
                            new ListOption{ field = "User", title = Resource.User },
                            new ListOption{ field = "Email", title = Resource.Email },
                            new ListOption{ field = "Status", title = Resource.State },
                            new ListOption{ field = "DID", title = Resource.DIDNumber },
                            new ListOption{ field = "HeadphoneNumber", title = Resource.HeadphoneNumber },
                            new ListOption{ field = "_EffectiveDate", title = Resource.EffectiveDate },
                        };
                        break;
                    case "factory":
                        result = new List<ListOption>
                        {
                            new ListOption{ checkbox = true, sortable = false, visible = true },
                            new ListOption{ field = "FactoryShortName", title = Resource.FactoryShortName },
                            new ListOption{ field = "TEL", title = Resource.TEL },
                            new ListOption{ field = "FAX", title = Resource.FAX },
                            new ListOption{ field = "IDNO", title = Resource.IDNO },
                            new ListOption{ field = "FactoryClass", title = Resource.FactoryClass },
                            new ListOption{ field = "ContactPerson", title = Resource.ContactPerson, align = "center", events = "window.operateEvents", formatter = "<button class='detail btn btn-info' title='Detail' data-toggle='modal' data-target='#myModal'><i class='fa fa-address-book'></i>?????p???H</button>" },
                        };
                        break;
                    case "factoryClass":
                        result = new List<ListOption>
                        {
                            new ListOption{ checkbox = true, sortable = false, visible = true },
                            new ListOption{ field = "ClassName", title = Resource.ClassName },
                            new ListOption{ field = "Order", title = Resource.Order },
                            new ListOption{ field = "Factory", title = Resource.Factory_Name, align = "center", events = "window.operateEvents", formatter = "<button class='detail btn btn-info' title='Detail' data-toggle='modal' data-target='#myModal'><i class='fa fa-address-book'></i>?????t??</button>" },
                        };
                        break;
                    case "floorManager":
                        result = new List<ListOption>
                        {
                            new ListOption{ checkbox = true, sortable = false, visible = true },
                            new ListOption{ field = "Name", title = Resource.Name },
                            new ListOption{ field = "IsEnable", title = Resource.IsEnable, formatter = "BitFormatter" },
                            new ListOption{ field = "Brand", title = Resource.Brand },
                        };
                        break;
                    case "floorManagerConfirm":
                        result = new List<ListOption>
                        {
                            new ListOption{ checkbox = true, sortable = false, visible = true },
                            new ListOption{ field = "ApplyName", title = Resource.ApplyName },
                            new ListOption{ field = "ApplyItemName", title = Resource.ApplyItemName },
                            new ListOption{ field = "ApplyQty", title = Resource.ApplyQty },
                            new ListOption{ field = "AgentName", title = Resource.AgentName },
                        };
                        break;
                    case "freeFieldSetting":
                        result = new List<ListOption>
                        {
                            new ListOption{ checkbox = true, sortable = false, visible = true },
                            new ListOption{ field = "TableName", title = Resource.TableName },
                            new ListOption{ field = "FieldName", title = Resource.FieldName },
                            new ListOption{ field = "DataType", title = Resource.DataType },
                        };
                        break;
                    case "function":
                        result = new List<ListOption>
                        {
                            new ListOption{ checkbox = true, sortable = false, visible = true },
                            new ListOption{ field = "ModuleName", title = Resource.Module },
                            new ListOption{ field = "GroupName", title = Resource.GroupName },
                            new ListOption{ field = "GroupSequence", title = Resource.GroupSequence },
                            new ListOption{ field = "Sequence", title = Resource.Sequence },
                            new ListOption{ field = "Code", title = Resource.Code },
                            new ListOption{ field = "SimpleName", title = Resource.SimpleName },
                            new ListOption{ field = "DisplayName", title = Resource.DisplayName },
                            new ListOption{ field = "DisplayTree", title = Resource.DisplayTree, formatter = "BitFormatter" },
                            new ListOption{ field = "DisplayHeader", title = Resource.DisplayHeader, formatter = "BitFormatter" },
                            new ListOption{ field = "IsEnable", title = Resource.IsEnable, formatter = "BitFormatter" },
                            new ListOption{ field = "ControllerName", title = Resource.ControllerName },
                            new ListOption{ field = "ActionName", title = Resource.ActionName },
                        };
                        break;
                    case "factoryItems":
                        result = new List<ListOption>
                        {
                            new ListOption{ checkbox = true, sortable = false, visible = true },
                            new ListOption{ field = "ItemName", title = Resource.ItemName },
                            new ListOption{ field = "ItemSpecification", title = Resource.ItemSpecification },
                            new ListOption{ field = "ItemClass", title = Resource.ItemClass },
                            new ListOption{ field = "ItemUnit", title = Resource.ItemUnit },
                            new ListOption{ field = "ItemPrice", title = Resource.ItemPrice },
                            new ListOption{ field = "ItemQty", title = Resource.ItemQty },
                            new ListOption{ field = "Factory", title = Resource.Factory_Name },
                        };
                        break;
                    case "headphone":
                        result = new List<ListOption>
                        {
                            new ListOption{ checkbox = true, sortable = false, visible = true },
                            new ListOption{ field = "HeadphoneNumber", title = Resource.HeadphoneNumber },
                            new ListOption{ field = "Brand", title = Resource.Brand },
                            new ListOption{ field = "User", title = Resource.User },
                            new ListOption{ field = "Email", title = Resource.Email },
                            new ListOption{ field = "Status", title = Resource.HeadphoneStatus },
                            new ListOption{ field = "UpdateUser", title = Resource.UpdateUser },
                            new ListOption{ field = "UpdateTime", title = Resource.UpdateTime, formatter = "JsonDateFormatter" },
                        };
                        break;
                    case "itemsApply":
                        result = new List<ListOption>
                        {
                            new ListOption{ checkbox = true, sortable = false, visible = true },
                            new ListOption{ field = "ItemName", title = Resource.ItemName },
                            new ListOption{ field = "ItemSpecification", title = Resource.ItemSpecification },
                            new ListOption{ field = "Qty", title = Resource.Qty },
                            new ListOption{ field = "Memo", title = Resource.Memo },
                            new ListOption{ field = "Status", title = Resource.State },
                            new ListOption{ field = "ApplyName", title = Resource.ApplyName },
                            new ListOption{ field = "CreateTime", title = Resource.ApplyDate, formatter = "JsonDateFormatter" },
                        };
                        break;
                    case "itemClass":
                        result = new List<ListOption>
                        {
                            new ListOption{ checkbox = true, sortable = false, visible = true },
                            new ListOption{ field = "ClassName", title = Resource.ClassName },
                            new ListOption{ field = "Order", title = Resource.Order },
                            new ListOption{ field = "IsForUser", title = Resource.IsForUser, formatter = "BitFormatter" },
                            new ListOption{ field = "IsEnable", title = Resource.IsEnable, formatter = "BitFormatter" },
                            new ListOption{ field = "FactoryItems", title = Resource.FactoryItems, align = "center", events = "window.operateEvents", formatter = "<button class='detail btn btn-info' title='Detail' data-toggle='modal' data-target='#myModal'><i class='fa fa-address-book'></i>???????????~</button>" },
                        };
                        break;
                    case "module":
                        result = new List<ListOption>
                        {
                            new ListOption{ checkbox = true, sortable = false, visible = true },
                            new ListOption{ field = "Sequence", title = Resource.Sequence },
                            new ListOption{ field = "Name", title = Resource.Name },
                            new ListOption{ field = "IsEnable", title = Resource.IsEnable, formatter = "BitFormatter" },
                            new ListOption{ field = "MenuDisplay", title = Resource.MenuDisplay, formatter = "BitFormatter" },
                        };
                        break;
                    case "operateRecord":
                        result = new List<ListOption>
                        {
                            new ListOption{ checkbox = true, sortable = false, visible = true },
                            new ListOption{ field = "TableName", title = Resource.TableName },
                            new ListOption{ field = "RecordInfo", title = Resource.RecordInfo },
                            new ListOption{ field = "Action", title = Resource.Action, formatter = "OperatorFormatter" },
                            new ListOption{ field = "Result", title = Resource.Result, formatter = "OperatorResultFormatter" },
                            new ListOption{ field = "OperateIP", title = Resource.OperateIP },
                            new ListOption{ field = "OperateUser", title = Resource.OperateUser },
                            new ListOption{ field = "OperateTime", title = Resource.OperateTime, formatter = "JsonTimeFormatter" },
                        };
                        break;
                    case "role":
                        result = new List<ListOption>
                        {
                            new ListOption{ checkbox = true, sortable = false, visible = true },
                            new ListOption{ field = "Name", title = Resource.Name },
                            new ListOption{ field = "IsEnable", title = Resource.IsEnable, formatter = "BitFormatter" },
                            new ListOption{ field = "UpdateUser", title = Resource.UpdateUser },
                            new ListOption{ field = "UpdateTime", title = Resource.UpdateTime, formatter = "JsonTimeFormatter" },
                        };
                        break;                    
                    case "systemConfig":
                        result = new List<ListOption>
                        {
                            new ListOption{ checkbox = true, sortable = false, visible = true },
                            new ListOption{ field = "ConfigKey", title = Resource.ConfigKey },
                            new ListOption{ field = "ConfigValue", title = Resource.ConfigValue },
                            new ListOption{ field = "UpdateUser", title = Resource.UpdateUser },
                            new ListOption{ field = "UpdateTime", title = Resource.UpdateTime, formatter = "JsonTimeFormatter" },
                        };
                        break;
                    case "systemOption":
                        result = new List<ListOption>
                        {
                            new ListOption{ checkbox = true, sortable = false, visible = true },
                            new ListOption{ field = "Category", title = Resource.Category },
                            new ListOption{ field = "OptionKey", title = Resource.OptionKey },
                            new ListOption{ field = "OptionValue", title = Resource.OptionValue },
                            new ListOption{ field = "UpdateUser", title = Resource.UpdateUser },
                            new ListOption{ field = "UpdateTime", title = Resource.UpdateTime, formatter = "JsonTimeFormatter" },
                        };
                        break;
                    
                    case "user":
                        result = new List<ListOption>
                        {
                            new ListOption{ checkbox = true, sortable = false, visible = true },
                            new ListOption{ field = "PhotoPath", title = Resource.Photo },
                            new ListOption{ field = "Name", title = Resource.UserName },
                            new ListOption{ field = "Account", title = Resource.Account },
                            new ListOption{ field = "Email", title = Resource.Email },
                            new ListOption{ field = "IsEnable", title = Resource.IsEnable, formatter = "BitFormatter" },
                            new ListOption{ field = "Department", title = Resource.Department },
                            new ListOption{ field = "DefaultIndex", title = Resource.DefaultIndex },
                            new ListOption{ field = "LoginTime", title = Resource.LoginTime, formatter = "JsonTimeFormatter" },
                            new ListOption{ field = "UpdateUser", title = Resource.UpdateUser },
                            new ListOption{ field = "UpdateTime", title = Resource.UpdateTime, formatter = "JsonTimeFormatter" },
                        };
                        break;
                    case "userProfile":
                        result = new List<ListOption>
                        {
                            new ListOption{ checkbox = true, sortable = false, visible = true },
                            new ListOption{ field = "UserName", title = Resource.UserName },
                            new ListOption{ field = "Code", title = Resource.Code },
                            new ListOption{ field = "ListOption", title = Resource.ListOption },
                        };
                        break;                   
                    case "visualMenu":
                        result = new List<ListOption>
                        {
                            new ListOption{ checkbox = true, sortable = false, visible = true },
                            new ListOption{ field = "ParentName", title = Resource.MenuParent },
                            new ListOption{ field = "Sequence", title = Resource.Sequence },
                            new ListOption{ field = "MenuLevel", title = Resource.MenuLevel },
                            new ListOption{ field = "MenuCode", title = Resource.MenuCode },
                            new ListOption{ field = "MenuName", title = Resource.MenuName },
                            new ListOption{ field = "Layout", title = Resource.Layout },
                            new ListOption{ field = "IsEnable", title = Resource.IsEnable },
                            new ListOption{ field = "UpdateUser", title = Resource.UpdateUser },
                            new ListOption{ field = "UpdateTime", title = Resource.UpdateTime, formatter = "JsonTimeFormatter" },
                        };
                        break;

                }
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// set table list fields
        /// </summary>
        /// <param name="functionName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        [WebAuthorize(Code = "Pass")]
        [HttpPost]
        public ActionResult SetColumn(string functionName, List<ListOption> data)
        {
            var result = false;
            if (null != data && data.Count > 0 && ID.HasValue)
            {
                foreach (var item in data)
                {
                    item.formatter = item.formatter ?? string.Empty;
                }
                var profile = new UserProfileViewModel
                {
                    ID = Guid.NewGuid(),
                    UserID = ID.Value,
                    Code = functionName,
                    ListOption = data
                };

                try
                {
                    _userProfileManager.Save(profile);
                    result = true;
                }
                catch (Exception ex)
                {
                    logger.Error(ex, string.Format(Resource.ExecutionFailedWithID, Resource.Save, Resource.UserProfile, ID.Value + ", Function: " + functionName));
                }
            }

            return Json(result);
        }

        /// <summary>
        /// ?O?????????X???A
        /// </summary>
        /// <param name="collapse"></param>
        /// <returns></returns>
        [WebAuthorize(Code = "Pass")]
        [HttpPost]
        public ActionResult SideBarCollapse(bool collapse)
        {
            var sidebar = new HttpCookie("SideBarCollapse");
            sidebar.Value = collapse.ToString();
            sidebar.Expires.AddYears(1);
            Response.Cookies.Add(sidebar);

            return null;
        }
    }
}
