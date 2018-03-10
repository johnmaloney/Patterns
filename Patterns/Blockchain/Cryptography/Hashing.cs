using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Blockchain.Cryptography
{
    public class Hashing
    {
        #region Fields



        #endregion

        #region Properties



        #endregion

        #region Methods

        public static byte[] ComputeHashSha256(byte[] toBeHashed)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(toBeHashed);
            }
        }

        #endregion
    }
}
