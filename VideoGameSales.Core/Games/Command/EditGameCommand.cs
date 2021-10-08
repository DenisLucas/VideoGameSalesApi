using System;

namespace VideoGameSales.Core.Games.Command
{
    public class EditGameCommand
    {
        public int Ranks { get; set; }        
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Release_year { get; set; }
    }
}
