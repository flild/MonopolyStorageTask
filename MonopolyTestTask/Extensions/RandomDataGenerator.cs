using Microsoft.EntityFrameworkCore;
using MonopolyTestTask.Data;
using MonopolyTestTask.Models;
using MonopolyTestTask.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyTestTask.Extensions
{
    internal class RandomDataGenerator
    {
        private readonly Random _random = new Random();
        private readonly int _maxWidth = 100;
        private readonly int _maxHeight = 100;
        private readonly int _maxDepth = 200;
        private readonly int _maxWeight = 100;
        private PalleteService _palleteService;
        private BoxService _boxService;
        public RandomDataGenerator()
        {
            _palleteService = new PalleteService();
            _boxService = new BoxService();
        }
        public Box GenerateBox()
        {
            SizeParam size = new SizeParam(_random.Next(1, _maxHeight), _random.Next(1, _maxWidth), _random.Next(1, _maxDepth));
            float weight = _random.Next(1, _maxWeight);
            bool isFabricDate = _random.Next() % 2 == 0;
            DateOnly date;
            DateOnly now = DateOnly.FromDateTime(DateTime.Now);
            if (isFabricDate)
            {
                date = now.AddDays(_random.Next(-99, -1));
            }
            else
            {
                date = now.AddDays(_random.Next(10, 200));
            }

            return new Box(weight, size, date, isFabricDate);
        }
        public Pallete GeneretePallete()
        {
            SizeParam size = new SizeParam(10, _maxWidth, _maxDepth);
            int countBox = _random.Next(1, 100);
            var boxes = new List<Box>();
            for (int i = 0; i < countBox; i++)
            {
                Box box = GenerateBox();
                boxes.Add(box);
            }
            return new Pallete(size, boxes);
        }
        public void GenerateData()
        {
            for (int i = 0; i < _random.Next(10, 100); i++)
            {
                var pallete = GeneretePallete();
                _palleteService.CreatePallete(pallete);
            }
        }
    }
    internal static class DbExtensions
    {
        public static void ClearDb()
        {
            ApplicationContext _db = new ApplicationContext();
            _db.Database.ExecuteSqlRaw("DELETE FROM \"Boxes\"");
            _db.Database.ExecuteSqlRaw("DELETE FROM \"Palletes\"");
            _db.SaveChanges();
        }
    }
}
