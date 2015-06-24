﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RecipeShare.Models;

namespace RecipeShare.Controllers
{
	public class ProfileController: Controller
	{
		[HttpPost]
		public JsonResult GetProfileForUser()
		{
			var dbContext = new RecipeShareDbContext();
			int id = Convert.ToInt32(User.Identity.GetUserId());
			
			var user = dbContext.AspNetUsers
				.Where(netUser => netUser.Id == id)
				.Select(netuser => new 
				{
					netuser.Id, 
					netuser.Email,
					netuser.FirstName,
					netuser.LastName
					//netuser.RecipeGroups,
					//netuser.Recipes

				}).First();
			var userjson = Json(user);
			return userjson;

		}

		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public JsonResult GetRecipesForUser()
		{
			var dbContext = new RecipeShareDbContext();
			int id = Convert.ToInt32(User.Identity.GetUserId());
			var recipes = dbContext.Recipes.Where(x => x.AspNetUserId == id)
				.Select(recipe => new
				{
					recipe.Name,
					recipe.RecipeCategory,
					recipe.PrepTimeMinutes,
					recipe.CookTimeMinutes,
					recipe.Id,
					recipe.Serves

				}).ToList();
			return Json(recipes);
		}

		[HttpPost]
		public JsonResult GetGroupsForUser()
		{
			var dbContext = new RecipeShareDbContext();
			int id = Convert.ToInt32(User.Identity.GetUserId());
			var groups = dbContext.RecipeGroups.Where(x=> x.AdminId == id || x.Members.Contains(dbContext.AspNetUsers.FirstOrDefault(y => y.Id == id)))
				.Select(group => new
				{
					group.Name

				}).ToList();
			return Json(groups);
		}
	}
}