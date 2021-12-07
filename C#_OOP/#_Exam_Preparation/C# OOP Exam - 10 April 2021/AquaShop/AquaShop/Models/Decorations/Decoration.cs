﻿using AquaShop.Models.Decorations.Contracts;

namespace AquaShop.Models.Decorations
{
    public abstract class Decoration : IDecoration
    {
        public Decoration(int comfort, decimal price)
        {
            Comfort = comfort;
            Price = price;
        }
        public int Comfort { get; }

        public decimal Price { get; }
    }
}
