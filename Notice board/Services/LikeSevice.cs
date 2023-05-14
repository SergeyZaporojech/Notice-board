using Data;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Notice_board.Helper;

namespace Notice_board.Services
{

    public interface ILikeService
    {
        void Add(int id);
        void Remove(int id);
        List<Advert?> GetAll();
        void Clear();
        int GetCount();
    }
    public class LikeSevice : ILikeService
    {
        const string likeKey = "likeItems";
        private readonly HttpContext httpContext;
        private readonly AdvertDbContext context;

        public LikeSevice(IHttpContextAccessor httpContextAccessor, AdvertDbContext context)
        {
            this.httpContext = httpContextAccessor.HttpContext;
            this.context = context;
        }

        public void Add(int id)
        {
            //List<int>? ids = httpContext.Session.Get<List<int>>(likeKey);
            List<int>? ids = httpContext.Session.Get<List<int>>(likeKey);

            // if id collection is null
            ids ??= new List<int>();

            ids.Add(id);

            // save product to cart
            httpContext.Session.Set(likeKey, ids);
        }

        public void Clear()
        {
            // TODO
            throw new NotImplementedException();
        }

        public List<Advert?> GetAll()
        {
            // get all products in the cart
            var ids = httpContext.Session.Get<List<int>>(likeKey);
            ids ??= new List<int>();

            return ids.Select(id => context.Adverts.Find(id)).ToList();
        }

        public int GetCount()
        {
            var ids = httpContext.Session.Get<List<int>>(likeKey);
            return ids?.Count ?? 0;
        }

        public void Remove(int id)
        {
            List<int>? ids = httpContext.Session.Get<List<int>>(likeKey);

            if (ids != null)
            {
                ids.Remove(id);
                // save product to cart
                httpContext.Session.Set(likeKey, ids);
            }
        }
    }
}
