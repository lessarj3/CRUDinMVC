using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CathRepoCommon.Models;

namespace CathRepoCommon.Models
{
	public class MixRepositoryInMemory : IMixRepository
	{
		private List<Mix> _mixes;

		public MixRepositoryInMemory()
		{
			_mixes = new List<Mix>();
            SetUpRepo();
        }

        public void AddMix(IEnumerable<Mix> mixes)
		{
			_mixes.AddRange(mixes);
		}

		public void AddMix(Mix mix)
		{
			_mixes.Add(mix);
		}

		public void DeleteMix(int mixId)
		{
			_mixes.Remove(_mixes.Where(m => m.Id == mixId).FirstOrDefault());
		}

	    public IEnumerable<Mix> GetMixes()
	    {
	        return _mixes;
	    }

        public Mix GetById(int mixId)
		{
			return _mixes.Where(m => m.Id == mixId).FirstOrDefault();
		}

		public void UpdateDetails(Mix mix)
		{
			_mixes.Remove(_mixes.Where(m => m.Id == mix.Id).FirstOrDefault());
			_mixes.Add(mix);
		}

        private void SetUpRepo()
        {
            _mixes.Add(new Mix { MixName = "Mix 1", CFx = 90, Id = 1, Ratio = 1, SVO = 10 });
            _mixes.Add(new Mix { MixName = "Mix 2", CFx = 80, Id = 2, Ratio = 1, SVO = 20 });
            _mixes.Add(new Mix { MixName = "Mix 3", CFx = 70, Id = 3, Ratio = 1, SVO = 30 });
            _mixes.Add(new Mix { MixName = "Mix 4", CFx = 60, Id = 4, Ratio = 1, SVO = 40 });
            _mixes.Add(new Mix { MixName = "Mix 5", CFx = 50, Id = 5, Ratio = 1, SVO = 50 });
            _mixes.Add(new Mix { MixName = "Mix 6", CFx = 40, Id = 6, Ratio = 1, SVO = 60 });
        }
    }
}
