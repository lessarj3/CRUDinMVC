using System.Collections.Generic;

namespace CathRepoCommon.Models
{
    public interface IMixRepository
    {
        void AddMix(IEnumerable<Mix> mixes);
        void AddMix(Mix mix);
        void DeleteMix(int id);
        IEnumerable<Mix> GetMixes();
        //IEnumerable<Mix> GetMixesByChemistry(string chemistry)
        void UpdateDetails(Mix mix); 
        // Add in PELLET method JJL     
        void AddPellet(Pellet pellet);
    }
}