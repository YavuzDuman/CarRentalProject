﻿
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
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
        static void Main(string[] args)
        {
            //CarTest();
            //ColorListMethod();
            //ColorAdd();
            //CarAddList();
            //BrandAddList();
            //List();
            
        }

        private static void List()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("Car : " + car.CarName + "\n" + "Brand : " + car.BrandName + "\n" + "Color : " + car.ColorName + "\n" + "Daily Price : " + car.DailyPrice);
                Console.WriteLine("");
            }
        }

        private static void BrandAddList()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandName = "Mitsubishi" });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarAddList()
        {
            CarManager carmanager = new CarManager(new EfCarDal());

            carmanager.Add(new Car {  CarName = "Mustang", BrandId = 2, ColorId = 2, DailyPrice = 12000, ModelYear = "1978", Description = "Amerikan" });

            foreach (var car in carmanager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void ColorAdd()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorId=3,ColorName = "Kırmızı" });
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void ColorListMethod()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());


            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}