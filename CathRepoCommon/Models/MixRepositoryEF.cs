using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;

namespace CathRepoCommon.Models
{
    public class MixRepositoryEF : IMixRepository
    {
        public void AddMix(Mix mix)
        {
            using (var db = new MixDBContext())
            {
                db.Mixes.Add(mix);
                db.SaveChanges();
            }
        }

        public void AddMix(IEnumerable<Mix> mixes)
        {
            using (var db = new MixDBContext())
            {
                db.Mixes.AddRange(mixes);
                db.SaveChanges();
            }
        }

        public void AddPellet(Pellet pellet)
        {
            throw new NotImplementedException();
        }

        public void DeleteMix(string id)
        {
            using (var db = new MixDBContext())
            {
                var mix = db.Mixes.Where(m => m.Id == id).FirstOrDefault();
                if (mix != null)
                {
                    db.Mixes.Remove(mix);
                    db.SaveChanges();
                }
            }
        }

        public IEnumerable<Mix> GetMixes()
        {
            using (var db = new MixDBContext())
            {
                return db.Mixes.ToList();
            }
        }

        public void UpdateDetails(Mix mix)
        {
            using (var db = new MixDBContext())
            {
                db.Entry(mix).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Search(MixSearchFilter filter)
        {
            throw new NotImplementedException();
        }
    }
}
