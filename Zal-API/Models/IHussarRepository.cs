using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zal_API.Models
{
    public interface IHussarRepository
    {
        Task<Hussar> AddHussar(Hussar hussar);
        Task<IEnumerable<Hussar>> GetAllHussars();
        Task<Hussar> GetHussar(int id);
        Task<Hussar> EditHussar(Hussar hussar);
        Task DeleteHussar(Hussar hussar);

    }
}
