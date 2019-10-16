using System.Collections.Generic;

namespace Restaurant.Models
{
    public class Cuisine
    {
        public int CuisineId {get;set;}
        public string Name {get; set;}
        public virtual ICollection<RestaurantV> RestaurantVariable {get;set;}

        public Cuisine()
        {
            this.RestaurantVariable = new HashSet<RestaurantV>();
        }
    }
}