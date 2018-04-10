using DomainDrivenDesignArchitecture.Interface.Infra;
using System;
using System.Data.Entity;
using System.Web;

namespace DomainDrivenDesignArchitecture.Repository
{
    public class ContextManager : IContextManager
    {
        private const string CONTEXT_HTTP = "CONTEXT_HTTP";

        public DbContext Context
        {
            get
            {
                return HttpContext.Current.Items[CONTEXT_HTTP] as DbContext;
            }
        }

        public ContextManager()
        {
            CreateContext();
        }

        private void CreateContext()
        {
            var context = HttpContext.Current.Items[CONTEXT_HTTP] as DbContext;

            if (context == null)
            {
                context = new SimpleContext();
                HttpContext.Current.Items[CONTEXT_HTTP] = context;
            }
        }

        public void Dispose()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Context.Dispose();
                HttpContext.Current.Items[CONTEXT_HTTP] = null;
            }
        }
    }
}
