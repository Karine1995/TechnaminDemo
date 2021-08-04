﻿using DAL;
using System;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    public class Service : IService
    {
        protected readonly TechnaminDemoDbContext DbContext;

        public Service(TechnaminDemoDbContext dbContext) => DbContext = dbContext;

        #region dispose
        private bool disposedValue;

        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore();

            Dispose(disposing: false);
#pragma warning disable CA1816 // Dispose methods should call SuppressFinalize
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                    DbContext?.Dispose();

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected async ValueTask DisposeAsyncCore()
        {
            if (DbContext is not null)
                await DbContext.DisposeAsync().ConfigureAwait(false);
        }

        #endregion
    }
}
