using Microsoft.EntityFrameworkCore;
using MonopolyTestTask.Data;
using MonopolyTestTask.Extensions;
using MonopolyTestTask.Models;
using MonopolyTestTask.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyTests
{
    internal class PalleteServiceTests
    {
        private IDbContext _db;
        private PalleteService _palleteService;
        private List<Pallete> _AnswerTOtestOfSorting;
        [SetUp]
        public void PrepareBd()
        {
            _db = new ApplicationContext();
            _palleteService = new PalleteService(_db);
            _AnswerTOtestOfSorting = new List<Pallete>();
            Box box1 = new Box(4, new SizeParam(20, 20, 20), new DateOnly(2024, 11, 29), false);
            Box box2 = new Box(5, new SizeParam(25, 20, 20), new DateOnly(2024, 11, 1), true);
            Box box3 = new Box(6, new SizeParam(20, 25, 25), new DateOnly(2024, 10, 29), true);
            Box box4 = new Box(7, new SizeParam(20, 30, 50), new DateOnly(2024, 11, 15), false);
            Box box5 = new Box(8, new SizeParam(20, 30, 20), new DateOnly(2024, 12, 29), false);
            Box box6 = new Box(9, new SizeParam(30, 30, 30), new DateOnly(2024, 10, 10), false);
            Pallete Pallete1 = new Pallete(new SizeParam(10, 100, 200), new List<Box> { box1, box2 });
            Pallete Pallete2 = new Pallete(new SizeParam(10, 100, 200), new List<Box> { box3, box4 });
            Pallete Pallete3 = new Pallete(new SizeParam(10, 100, 200), new List<Box> { box5, box6 });

            _palleteService.CreatePallete(Pallete1);
            _palleteService.CreatePallete(Pallete2);
            _palleteService.CreatePallete(Pallete3);
            _AnswerTOtestOfSorting.Add(Pallete3);
            _AnswerTOtestOfSorting.Add(Pallete2);
            _AnswerTOtestOfSorting.Add(Pallete1);

        }
        [Test]
        public void GetAllpalletsGroupAndSortTest()
        {
            var result = _palleteService.GetAllpalletsGroupAndSort();
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EquivalentTo(_AnswerTOtestOfSorting));
        }
        [TearDown]
        public void TearDown()
        {
            _db.Dispose();
        }
    }
}
