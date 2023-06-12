using System.Linq.Expressions;

using Microsoft.Extensions.Options;

using MongoDB.Driver;
using YellowPages.Data.Abstract;

using YellowPages.Shared.Models;
using YellowPages.Shared.Settings;

using YellowPagesReportService.Entities.Concrete;

using MongoDbEntity = YellowPages.Shared.Models.MongoDbEntity;

namespace YellowPages.Data.Concrete
{
    public abstract class MongoDbRepositoryBase<T> : IRepository<T, string> where T : MongoDbEntity, new()
    {
        protected readonly IMongoCollection<T> Collection;
        private readonly IDatabaseSettings settings;
        //private readonly IMongoDatabase db;
       

        protected MongoDbRepositoryBase(IOptions<DatabaseSettings> options)
        {
            this.settings = options.Value;
            var client = new MongoClient(this.settings.ConnectionString);
            var db = client.GetDatabase(this.settings.DatabaseName);
            this.Collection = db.GetCollection<T>(typeof(T).Name);
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> predicate = null)
        {
            return predicate == null
                ? Collection.AsQueryable()
                : Collection.AsQueryable().Where(predicate);
        }

        public virtual Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return Collection.Find(predicate).FirstOrDefaultAsync();
        }


        public virtual async Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate)
        {
            
            
            var filter = new ExpressionFilterDefinition<T>(predicate);
           var list=await Collection.Find(filter).ToListAsync();
           var listb = list;
           return listb;
           // return Collection.AsQueryable().ToListAsync();
           // return Collection.Find(T,null)
           //  MongoDB.Driver.IAsyncCursorSourceExtensions.ToListAsync(
           // IMongoCollectionExtensions.Find(_phoneInformationCollection, a => true));

        }



        //public virtual List<T> GetList(Expression<Func<T, bool>> predicate = null)
        //{
        //    var datas = db.GetCollection<T>(settings.ConnectionString).AsQueryable()
        //        .Where(predicate).ToList();

        //    return datas;

        //    // return predicate == null
        //    //     ? Collection.AsQueryable()
        //    //     : Collection.AsQueryable().Where(predicate);

        //    //var r= MongoDB.Driver.IAsyncCursorSourceExtensions.ToListAsync(
        //    //  IMongoCollectionExtensions.Find(=> true));

        //}

        public virtual Task<T> GetByIdAsync(string id)
        {
            return Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            var options = new InsertOneOptions { BypassDocumentValidation = false };
            await Collection.InsertOneAsync(entity, options);
            return entity;
        }

        public virtual async Task<bool> AddRangeAsync(IEnumerable<T> entities)
        {
            var options = new BulkWriteOptions { IsOrdered = false, BypassDocumentValidation = false };
            return (await Collection.BulkWriteAsync((IEnumerable<WriteModel<T>>)entities, options)).IsAcknowledged;
        }

        public virtual async Task<T> UpdateAsync(string id, T entity)
        {
            return await Collection.FindOneAndReplaceAsync(x => x.Id == id, entity);
        }

        public virtual async Task<T> UpdateAsync(T entity, Expression<Func<T, bool>> predicate)
        {
            return await Collection.FindOneAndReplaceAsync(predicate, entity);
        }

        public virtual async Task<T> DeleteAsync(T entity)
        {
            return await Collection.FindOneAndDeleteAsync(x => x.Id == entity.Id);
        }

        public virtual async Task<T> DeleteAsync(string id)
        {
            return await Collection.FindOneAndDeleteAsync(x => x.Id == id);
        }

        public virtual async Task<T> DeleteAsync(Expression<Func<T, bool>> filter)
        {
            return await Collection.FindOneAndDeleteAsync(filter);
        }
    }
}
