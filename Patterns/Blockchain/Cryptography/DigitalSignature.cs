using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Blockchain.Cryptography
{
    /// <summary>
    /// Ensures non-repudiation or authentication of a message.
    /// Consists of three algorithms to ensure the signature is reliable:
    /// 1) a public and private key
    /// 2) a signing algorithm
    /// 3) a signature verification algorithm
    /// </summary>
    public class DigitalSignature
    {
        #region Fields

        /// <summary>
        /// Any recipient can use this to validate the signature
        /// </summary>
        private RSAParameters _publicKey;
        /// <summary>
        /// This is the key used to generate the digital signature
        /// </summary>
        private RSAParameters _privateKey;

        #endregion

        #region Properties



        #endregion

        #region Methods

        public void AssignNewKey()
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                _publicKey = rsa.ExportParameters(false);
                _privateKey = rsa.ExportParameters(true);
            }
        }

        public byte[] SignData(byte[] hashOfDataToSign)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;

                // using the private key to calculate the digital signature //
                rsa.ImportParameters(_privateKey);

                var rsaFormatter = new RSAPKCS1SignatureFormatter(rsa);
                rsaFormatter.SetHashAlgorithm("SHA256");

                // Sign the data //
                return rsaFormatter.CreateSignature(hashOfDataToSign);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hashOfDataToSign">Original data that was hashed</param>
        /// <param name="signature">signature of the the received data</param>
        /// <returns></returns>
        public bool VerifySignature(byte[] hashOfDataToSign, byte[] signature)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                // use the public key //
                rsa.ImportParameters(_publicKey);

                var rsaDeformatter = new RSAPKCS1SignatureDeformatter(rsa);
                rsaDeformatter.SetHashAlgorithm("SHA256");

                // true if the signature is valid //
                return rsaDeformatter.VerifySignature(hashOfDataToSign, signature);
            }
        }

        #endregion
    }
}
