using Microsoft.EntityFrameworkCore;
using MonopolyTestTask.Data;
using MonopolyTestTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyTestTask.Service
{
    public class PalleteService
    {
        ApplicationContext _db;
        public PalleteService() 
        {
            _db = new ApplicationContext();
        }
        public void CreatePallete(Pallete pallete)
        {
            _db.Palletes.Add(pallete);
            _db.SaveChanges();
        }
        public List<Pallete> GetAllpalletsGroupAndSort()
        {
            List<Pallete> palletes = _db.Palletes.ToList();
            var groupedPalettes = palletes
                .GroupBy(p => p.ExpirationDate)
                .Select(group => group.OrderBy(p => p.Weight));
            var sortedPalettes = groupedPalettes.SelectMany(group => group).ToList();

            return sortedPalettes;
        }
        public List<Pallete> GetPalletesWithMaxExpirationDate()
        {
            var palletes = _db.Palletes.Include(p => p.Boxes).ToList();
            var filteredPalettes = palletes
                .OrderByDescending(palette => palette.Boxes.Max(box => box.ExpirationDate))
                .Take(3);
            var sortedPalettes = filteredPalettes
                .OrderBy(p => p.Volume)
                .ToList();
            return sortedPalettes;
        }
    }
}
