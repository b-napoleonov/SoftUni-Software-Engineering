using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly List<IDecoration> decorations;

        public DecorationRepository()
        {
            decorations = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => decorations.AsReadOnly();

        public void Add(IDecoration model) => decorations.Add(model);

        public IDecoration FindByType(string type) => decorations.FirstOrDefault(d => d.GetType().Name == type);

        public bool Remove(IDecoration model) => decorations.Remove(model);
    }
}
