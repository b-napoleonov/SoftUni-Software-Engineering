using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private List<IEgg> eggs;

        public EggRepository()
        {
            eggs = new List<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models => eggs;

        public void Add(IEgg model) 
            => eggs.Add(model);

        public bool Remove(IEgg model) 
            => eggs.Remove(model);

        public IEgg FindByName(string name) 
            => eggs.FirstOrDefault(x => x.Name == name);
    }
}
