using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CathRepoCommon.Models
{
    public static class MixRepositoryFactory
    {
        private static IMixRepository _repo;
        public static IMixRepository Get()
        {
            if (_repo == null)
            {
                _repo = new MixRepositoryInMemory();
                return _repo;
            }
            else
                return _repo;
        }
    }
}
