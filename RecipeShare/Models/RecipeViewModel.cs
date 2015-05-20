﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeShare.Models
{
	public class RecipeViewModel
	{
		public string  Name { get; set; }

		public int Serves { get; set; }

		public int PrepTime	{ get; set; }

		public int CookTime { get; set; }

		public List<Models.RecipeModel.Ingredient> Ingredients { get; set; }

		public List<RecipeModel.Instruction> Instructions { get; set; }
	}
}