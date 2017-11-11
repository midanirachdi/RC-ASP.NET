﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using RefugeeCamp.Domain.Models;
using RefugeeCamp.Service;

using RefugeeCamp.Web.Security;

using RefugeeCamp.Web.ViewModels;

namespace RefugeeCamp.Web.Controllers
{
    public class AccountController : Controller
    {


        private GestionUser gu = null;

        public AccountController()
        { gu = new GestionUser(); }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(AccountViewModel avm)
        {
        
            if (string.IsNullOrEmpty(avm.Username) || string.IsNullOrEmpty(avm.Password))
            {
                ViewBag.Error = "Invalid Account";
                return View("Index");
            }

            string token = gu.callLogin(avm.Username, avm.Password).Result;

            if (token == null)
            {
                ViewBag.Error = "Invalid Account";
                return View("Index");
            }
            SessionPersister.User = gu.GetUserByToken(token);
            SessionPersister.Token = token;

            ViewBag.test = JsonConvert.SerializeObject(gu.FindById(1), Formatting.Indented);
            user u = SessionPersister.User;

            return View("Success");
        }



        public ActionResult Logout()
        {
            SessionPersister.User = null;
            SessionPersister.Token = null;
            return RedirectToAction("Index");
        }
    }
}