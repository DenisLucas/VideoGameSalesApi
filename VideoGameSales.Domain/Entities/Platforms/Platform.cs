using System;
using System.Collections.Generic;
using VideoGameSales.Domain.Entities.Conectors;

namespace VideoGameSales.Domain.Entities.Platforms
{
    public class Platform
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GamesToPlataform> GameToPlatform { get; set; }
    }
}
