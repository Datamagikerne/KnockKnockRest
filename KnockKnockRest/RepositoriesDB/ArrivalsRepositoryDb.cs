﻿using KnockKnockRest.Interfaces;
using KnockKnockRest.Models;
using KnockKnockRest.Context;

namespace KnockKnockRest.RepositoriesDB
{
    public class ArrivalsRepositoryDb : IArrivalsRepository
    {

        private KnockKnockContext _context;
        public ArrivalsRepositoryDb(KnockKnockContext context)
        {
            _context = context;
        }

        public Arrival Add(Arrival newArrival)
        {
            _context.arrivals.Add(newArrival);
            _context.SaveChanges();
            return newArrival;
        }

        public Arrival? Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Arrival> GetAll()
        {
            return _context.arrivals.ToList();
        }

        public Arrival? GetByID(int qr)
        {
            List<Arrival> result = _context.arrivals.ToList();
            return result.Find(arrival => arrival.QrCode == qr);
        }

        public Arrival? Update(int id, Arrival updates)
        {
            throw new NotImplementedException();
        }
    }
}
