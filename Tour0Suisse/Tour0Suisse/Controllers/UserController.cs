﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tour0Suisse.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult LogIn()
        {
            return View("~/Views/User/Connexion.cshtml");
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View("~/Views/User/Profil.cshtml");
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View("~/Views/User/Inscription.cshtml");
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return View("~/Views/Home/Index.cshtml");
            }
            catch
            {
                return View("~/Views/User/Inscription.cshtml");
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View("~/Views/User/Edit.cshtml");
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return View("~/Views/User/Profil.cshtml");
            }
            catch
            {
                return View("~/Views/User/Edit.cshtml");
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View("~/Views/User/Delete.cshtml");
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return View("~/Views/User/Deleted.cshtml");
            }
            catch
            {
                return View("~/Views/User/Delete.cshtml");
            }
        }
    }
}