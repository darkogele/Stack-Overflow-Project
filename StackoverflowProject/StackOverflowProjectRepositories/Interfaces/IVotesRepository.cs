using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowProjectRepositories.Interfaces
{
    public interface IVotesRepository
    {
        void UpdateVote(int aid, int uid, int value);
    }

}
