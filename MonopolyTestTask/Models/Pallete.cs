using MonopolyTestTask.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyTestTask.Models
{
    public class Pallete
    {
        public Pallete() { }
        public Pallete(SizeParam size, List<Box> boxes)
        {
            Size = size;
            Boxes = boxes;
            if (!ValidateBoxes(boxes))
            {
                throw new ArgumentException("wrong box!");
            };
            Volume = boxes.Sum(box => box.Volume) + Size.Depth*Size.Height*Size.Width;
            Weight = boxes.Sum(box => box.Weight);
            ExpirationDate = boxes.Min(Box => Box.ExpirationDate);


        }

        [Key]
        public int PalleteId { get; set; }
        public float Weight { get; set; }
        public SizeParam Size { get; set; }
        public float Volume { get; set; }
        public DateOnly? ExpirationDate { get; set; }
        public List<Box> Boxes { get; set; }

        public string GetStringSize()
        {
            return $"({Size.Height}; {Size.Width}; {Size.Depth})";
        }
        private bool ValidateBoxes(List<Box> boxes)
        {
            var valid = true;

            foreach (var box in boxes)
            {
                if (box.Size.Width > Size.Width || box.Size.Depth > Size.Depth)
                {
                    valid = false;
                    break;
                }
            }
            return valid;
        }

    }
}
