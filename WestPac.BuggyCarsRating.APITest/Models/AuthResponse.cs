using System.Collections.Generic;

namespace WestPac.BuggyCarsRating.APITest.Models
{
    public class AuthResponse
    {
        
        public string Access_token { get; set; }
        public int Expires_in { get; set; }
        public string Refresh_token { get; set; }
        public string Token_type { get; set; }
    }
}