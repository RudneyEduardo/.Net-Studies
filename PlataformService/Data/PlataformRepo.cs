using System;
using System.Collections.Generic;
using System.Linq;
using PlataformService.Models;

namespace PlataformService.Data 
{
    public class PlataformRepo : IPlataformRepo
    {
        private readonly AppDbContext _context;

        public PlataformRepo(AppDbContext context)
        {
            _context = context;    
        }



        public void CreatePlataform(Plataform plat)
        {
            if(plat == null){
                throw new ArgumentNullException(nameof(plat));
            }

            _context.Plataforms.Add(plat);
        }

        public IEnumerable<Plataform> GetAllPlataforms()
        {
            return _context.Plataforms.ToList();
        }

        public Plataform GetPlataformById(int id)
        {
            return _context.Plataforms.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}