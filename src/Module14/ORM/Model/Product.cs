﻿namespace ORM.Model
{
    public class Product : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Weight { get; set; }

        public decimal Height { get; set; }

        public decimal Width { get; set; }

        public decimal Length { get; set; }
    }
}