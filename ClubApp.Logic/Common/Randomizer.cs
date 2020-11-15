using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ClubApp.Logic.Common
{
    public class Randomizer : IRandomizer
    {
        public Task<string> GetRandomStringAsync()
        {
            return Task.Run(() =>
            {
                var randomNumber = new byte[32];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(randomNumber);
                    return Convert.ToBase64String(randomNumber);
                }
            });
        }
    }
}
