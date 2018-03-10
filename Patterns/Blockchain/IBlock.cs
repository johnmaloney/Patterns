using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Blockchain
{
    public interface IBlock
    {
        #region Properties

        int BlockNumber { get; }
        DateTime CreatedOn { get; }
        string Hash { get; }
        string PreviousBlockHash { get; }
        IBlock NextBlock { get; set; }

        #endregion

        #region Methods

        string CalculateBlockHash(string previousBlockHash);
        void SetBlockHash(IBlock parent);
        bool IsValidChain(string prevBlockHash, bool verbose);

        #endregion
    }
}
