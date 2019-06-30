using System;

namespace Market.Component.Item
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
    }
}
