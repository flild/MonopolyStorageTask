using MonopolyTestTask.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyTestTask.Models
{
    public class Box
    {
        public Box() { }
        public Box(float weight, SizeParam size, DateOnly Date, bool isFabricDate = true)
        {
            Weight = weight;
            Size = size;
            Volume = Size.Height * Size.Width * Size.Depth;
            ExpirationDate = isFabricDate ? Date.AddDays(100) : Date;
        }

        [Key]
        public int BoxId { get; set; }
        public float Weight { get; set; }
        public SizeParam Size { get; set; }
        public float Volume { get; set; }
        public DateOnly? ExpirationDate { get; set; }

    }
}
