using DeliveryOnline.Models;
using DeliveryOnline.Models.Auth;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeliveryOnline.Controllers
{
    public abstract class BaseController : Controller
    {
        private DeliveryContext dbContext;
        private ApplicationSignInManager appSignMng;
        private ApplicationUserManager appUsrMng;

        public BaseController()
        {

        }

        public BaseController(DeliveryContext deliveryContext, ApplicationSignInManager applicationSignInManager, ApplicationUserManager applicationUserManager)
        {
            dbContext = deliveryContext;
            appSignMng = applicationSignInManager;
            appUsrMng = applicationUserManager;
        }

        public DeliveryContext DbContext
        {
            get
            {
                return dbContext ?? HttpContext.GetOwinContext().Get<DeliveryContext>();
            }
            set
            {
                dbContext = value;
            }
        }

        public ApplicationSignInManager AppSignMng
        {
            get
            {
                return appSignMng ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            set
            {
                appSignMng = value;
            }
        }

        public ApplicationUserManager AppUsrMng
        {
            get
            {
                return appUsrMng ?? HttpContext.GetOwinContext().Get<ApplicationUserManager>();
            }
            set
            {
                appUsrMng = value;
            }
        }
    }
}