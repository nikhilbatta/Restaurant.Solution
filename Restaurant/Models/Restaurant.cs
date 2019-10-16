using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Restaurant.Models
{
    public class RestaurantV
    {
        
        public int RestaurantVId {get;set;}
        public int CuisineId { get; set;}
        public string Name {get;set;}
        public virtual Cuisine Cuisine {get;set;}
    }
}