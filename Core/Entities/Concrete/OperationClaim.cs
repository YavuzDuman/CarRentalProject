﻿using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Core.Entities.Concrete
{
	public class OperationClaim  : IEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
