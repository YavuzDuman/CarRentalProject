﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi.";
        public static string CarNameInvalid = "Araba ismi ve günlük ücret miktarı uygun değil.";
        public static string CarUpdated;
        public static string CarDeleted;
        public static string ColorAdded = "Color eklendi.";
        public static string ColorDeleted = "Color silindi.";
        public static string ColorUpdated = "Color güncellendi.";
        public static string BrandAdded = "Brand eklendi.";
        public static string BrandDeleted = "Brand silindi.";
        public static string BrandUpdated = "Brand güncellendi.";
        public static string UserAdded = "User eklendi.";
        public static string UserDeleted = "User silindi.";
        public static string UserUpdated = "User güncellendi.";
        public static string CustomerAdded = "Customer eklendi.";
        public static string CustomerDeleted = "Customer silindi";
        public static string RentalAdded = "Rental Eklendi";
        public static string RentalDeleted = "Rental silindi";
		public static string RentalUpdated = "Rental Güncellendi";
        public static string CarNameAlreadyExists = "Araba ismi sistemde mevcut";

		public static string ImageAdded { get; internal set; }
		public static string DefaultError { get; internal set; }
		public static string ImageDeleted { get; internal set; }
		public static string ImageUpdated { get; internal set; }
		public static string ImageLimitExceded { get; internal set; }
	}
}
