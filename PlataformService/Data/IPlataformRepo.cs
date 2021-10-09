using System.Collections.Generic;
using PlataformService.Models;

namespace PlataformService.Data
{
    public interface IPlataformRepo
    {
        bool SaveChanges();

        IEnumerable<Plataform> GetAllPlataforms();

        Plataform GetPlataformById(int id);

        void CreatePlataform(Plataform plat);
    }
}