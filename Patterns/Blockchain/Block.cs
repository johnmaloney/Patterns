using Patterns.Blockchain.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Blockchain
{
    public class Block : IBlock
    {
        #region Fields

        private readonly DataItem dataItem;

        #endregion

        #region Properties

        public int BlockNumber { get; private set; }

        public DateTime CreatedOn { get; private set; }

        public string Hash { get; private set; }

        public string PreviousBlockHash { get; private set; }

        public IBlock NextBlock { get; set; }

        #endregion

        #region Methods

        public Block(DataItem data)
        {
            this.dataItem = data;
        }

        public string CalculateBlockHash(string previousBlockHash)
        {
            var properties = this.dataItem.ToString();
            string blockHeader = BlockNumber + CreatedOn.ToString() + previousBlockHash;
            string combined = properties + blockHeader;

            return Convert.ToBase64String(Hashing.ComputeHashSha256(Encoding.UTF8.GetBytes(combined)));
        }

        public bool IsValidChain(string prevBlockHash, bool verbose)
        {
            throw new NotImplementedException();
        }

        public void SetBlockHash(IBlock parent)
        {
            throw new NotImplementedException();
        }
        
        #endregion
    }
}
