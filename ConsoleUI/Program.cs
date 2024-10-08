﻿
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        private string rentDate = "19.02.2024";
		static void Main(string[] args)
        {

            //CarTest();
            //ColorListMethod();
            //ColorAdd();
            //CarAddList();
            //BrandAddList();
            //List();
            //CustomerTest();

        }

        private static void CustomerTest()
        {
            CustomerManager customer = new CustomerManager(new EfCustomerDal());
            customer.Add(new Customer { CompanyName = "Ford" });
            Console.WriteLine("Müsteri eklendi");
        }

        private static void List()
        {
            ICarService carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("Car : " + car.CarName + "\n" + "Brand : " + car.BrandName + "\n" + "Color : " + car.ColorName + "\n" + "Daily Price : " + car.DailyPrice);
                Console.WriteLine("");
            }
        }

        private static void BrandAddList()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandName = "Mitsubishi" });
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarAddList()
        {
            ICarService carmanager = new CarManager(new EfCarDal());

            carmanager.Add(new Car {  CarName = "Mustang", BrandId = 2, ColorId = 2, DailyPrice = 12000, ModelYear = "1978", Description = "Amerikan" });

            foreach (var car in carmanager.GetAll().Data)
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void ColorAdd()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorId=3,ColorName = "Kırmızı" });
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void ColorListMethod()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void CarTest()
        {
			ICarService carManager = new CarManager(new EfCarDal());


			var result = carManager.GetById(2).Data;
            Console.WriteLine(result.CarName);
        }
    }
}