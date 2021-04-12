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
                    case "badProjectData":
                        result = new List<ListOption>
                        {
                            
                            new ListOption{ field = "WORK_CARD_NO", title = Resource.WORK_CARD_NO },
                            new ListOption{ field = "ProjectName", title = Resource.CUST_ABBR },
                            new ListOption{ field = "ProjectName", title = Resource.PROD_NAME },
                            new ListOption{ field = "ProjectName", title = Resource.MEDIA_KIND_NAME },
                            new ListOption{ field = "BrandName", title = Resource.Brand },
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
                    case "nonChargeable":
                        result = new List<ListOption>
                        {
                            new ListOption{ checkbox = true, sortable = false, visible = true },
                            new ListOption{ field = "ProjectID", title = Resource.ProjectID },
                            new ListOption{ field = "ProjectName", title = Resource.ProjectName },
                            new ListOption{ field = "ProgramName", title = Resource.ProgramName },
                            new ListOption{ field = "ClientName", title = Resource.ClientName },
                            new ListOption{ field = "LineofBusiness", title = Resource.LineofBusiness },
                            new ListOption{ field = "Chargeable", title = Resource.Chargeable },
                            new ListOption{ field = "ImportType", title = Resource.ImportType },
                            new ListOption{ field = "ImportDate", title = Resource.ImportDate, formatter = "JsonDateFormatter" },
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
                    case "projectData":
                        result = new List<ListOption>
                        {
                            new ListOption{ checkbox = true, sortable = false, visible = true },
                            new ListOption{ field = "ProjectID", title = Resource.ProjectID },
                            new ListOption{ field = "ProjectName", title = Resource.ProjectName },
                            new ListOption{ field = "ProgramName", title = Resource.ProgramName },
                            new ListOption{ field = "ClientName", title = Resource.ClientName },
                            new ListOption{ field = "LineofBusiness", title = Resource.LineofBusiness },
                            new ListOption{ field = "Chargeable", title = Resource.Chargeable },
                            new ListOption{ field = "ImportType", title = Resource.ImportType },
                            new ListOption{ field = "ImportDate", title = Resource.ImportDate, formatter = "JsonDateFormatter" },
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
                    case "workfrontReport":
                        result = new List<ListOption>
                        {
                            new ListOption{ checkbox = false, sortable = false, visible = false },
                            new ListOption{ field = "ProjectID", title = Resource.ProjectID },
                            new ListOption{ field = "Name", title = Resource.Name },
                            new ListOption{ field = "Owner", title = Resource.Owner },
                            new ListOption{ field = "Status", title = Resource.Status },
                            new ListOption{ field = "GroupName", title = Resource.GroupName },
                            new ListOption{ field = "IsChargeable", title = Resource.IsChargeable },
                            new ListOption{ field = "ProjectType", title = Resource.ProjectType },                            
                            new ListOption{ field = "UpdateUser", title = Resource.UpdateUser },
                            new ListOption{ field = "UpdateTime", title = Resource.UpdateTime, formatter = "JsonDateFormatter" },
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
        /// 記憶選單收合狀態
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
