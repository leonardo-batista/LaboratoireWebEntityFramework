using LaboratoireWebEntityFramework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LaboratoireWebEntityFramework.Repository
{
    public class RepositoryContext<T> : IRepositoryContext<T> where T : class
    {
        private LaboratoireContext _context;
        private DbSet<T> _dbEntity;

        public RepositoryContext()
        {
            _context = new LaboratoireContext();
            _dbEntity = _context.Set<T>();
        }

        public void DeleteModel(T model)
        {
            T modelResult = _dbEntity.Find(model);
            _dbEntity.Remove(modelResult);
        }

        public void DeleteModelById(int id)
        {
            T modelResult = _dbEntity.Find(id);
            _dbEntity.Remove(modelResult);
        }

        public T GetModelById(int id)
        {
            return _dbEntity.Find(id);
        }

        public T GetModelByName(string name)
        {
            return _dbEntity.Find(name);
        }

        public void InsertModel(T model)
        {
            _dbEntity.Add(model);
        }

        public IEnumerable<T> List()
        {
            return _dbEntity.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateModel(T model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}