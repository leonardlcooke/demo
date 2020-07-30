using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Demo.Helpers
{
    public interface IEncryptionService
    {
        string SetShaOneString(string stringToHash);
    }

    public class EncryptionService
    {
        public string SetShaOneString(string stringToHash)
        {
            try
            {
                var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(stringToHash));
                return string.Concat(hash.Select(h => h.ToString("x2")));
            }
            catch (Exception)
            {
                throw new Exception($"Issue setting the hashed string for {stringToHash}");
            }
        }
    }


}
