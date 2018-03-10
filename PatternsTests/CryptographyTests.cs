using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patterns.Blockchain.Cryptography;

namespace PatternsTests
{
    [TestClass]
    public class CryptographyTests
    {
        [TestMethod]
        public void send_a_message_with_digital_signature_expect_message_validation()
        {
            // User generates a message, hashes the message and signs it with their PRIVATE key //
            var message = Encoding.UTF8.GetBytes("This is a message that will be verified through digital signature.");

            // User sends the message //
            byte[] hashedMessage = Hashing.ComputeHashSha256(message);

            // Receiver calculates the hash of the encrypted data //
            var digitalSignature = new DigitalSignature();
            digitalSignature.AssignNewKey();

            // Receiver verifies the digital signature using the public key // 
            var signature = digitalSignature.SignData(hashedMessage);
            var verified = digitalSignature.VerifySignature(hashedMessage, signature);

            // the message should be verified at this point//
            Assert.IsTrue(verified);
        }

        [TestMethod]
        public void send_a_message_with_digital_signature_expect_intercepted_message_as_invalid()
        {
            // User generates a message, hashes the message and signs it with their PRIVATE key //
            var message = Encoding.UTF8.GetBytes("This is a message that will be changed after the digital signature.");

            // User sends the message //
            byte[] hashedMessage = Hashing.ComputeHashSha256(message);

            // Receiver calculates the hash of the encrypted data //
            var digitalSignature = new DigitalSignature();
            digitalSignature.AssignNewKey();

            // this signature is sent along with the message ? //
            var signature = digitalSignature.SignData(hashedMessage);

            // Message intercepted and altered //
            message = Encoding.UTF8.GetBytes("This is a message that was intercepted after the signature.");
            hashedMessage = Hashing.ComputeHashSha256(message);

            // Receiver verifies the digital signature using the public key // 
            var verified = digitalSignature.VerifySignature(hashedMessage, signature);

            // the message should be verified at this point//
            Assert.IsFalse(verified);
        }
    }
}
