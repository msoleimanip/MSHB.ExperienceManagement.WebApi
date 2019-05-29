using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExperienceManagement.WebUI.Layers.L00_BaseModels.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MSHB.ExperienceManagement.Presentation.WebUI.Controllers
{
    public class BaseController : Controller
    {
        protected RequestResultViewModel GetRequestResult(object data)
        {
            RequestResultViewModel res = new RequestResultViewModel
            {
                Data = data
            };
            return res;
        }
    }
}