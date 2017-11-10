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
		    _mixes.Add(new Mix { Id = 1, MixName = "Mix 1", CFx = 12, SVO = 24, Carbon = 32, Binder = 23, Ratio = 23 });
		    _mixes.Add(new Mix { Id = 2, MixName = "Mix 2", CFx = 12, SVO = 24, Carbon = 32, Binder = 23, Ratio = 23 });


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
	}
}
