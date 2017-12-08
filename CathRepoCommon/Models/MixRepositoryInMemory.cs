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
		}

		public void AddMix(IEnumerable<Mix> mixes)
		{
			_mixes.AddRange(mixes);
		}

		public void AddMix(Mix mix)
		{
			_mixes.Add(mix);
		}

		public void DeleteMix(string mixId)
		{
			_mixes.Remove(_mixes.Where(m => m.Id == mixId).FirstOrDefault());
		}

		public IEnumerable<Mix> GetMixes()
		{
			return _mixes;
		}

		public Mix GetById(string mixId)
		{
			return _mixes.Where(m => m.Id == mixId).FirstOrDefault();
		}

		public void UpdateDetails(Mix mix)
		{
			_mixes.Remove(_mixes.Where(m => m.Id == mix.Id).FirstOrDefault());
			_mixes.Add(mix);
		}

		public void DeleteAll()
		{
			_mixes.Clear();
		}

		public void AddPellet(Pellet pellet)
		{
			throw new NotImplementedException();
		}
	}
}
