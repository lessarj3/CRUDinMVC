using System.Collections.Generic;

namespace CathRepoCommon.Models
{
    public interface IMixRepository
    {
        void AddMix(Mix mix);
        void DeleteMix(int id);
        IEnumerable<Mix> GetMixes();
        void UpdateDetails(Mix mix);
        
    }
}