using System;
using System.Collections.Generic;

namespace VideoGameSales.Domain.Entities.Authentification
{
    public class AuthentificationResult
    {
        public string Token { get; set; }
        public bool Succes { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
