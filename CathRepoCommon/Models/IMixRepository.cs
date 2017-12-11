﻿using System.Collections.Generic;

namespace CathRepoCommon.Models
{
    public interface IMixRepository
    {
        void AddMix(IEnumerable<Mix> mixes);
        void AddMix(Mix mix);
        void DeleteMix(string id);
        IEnumerable<Mix> GetMixes();
        void UpdateDetails(Mix mix);
        void Search(MixSearchFilter filter);
        void AddPellet(Pellet pellet);
    }
}