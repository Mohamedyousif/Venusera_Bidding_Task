using System;
using System.Collections.Generic;
using System.Text;

namespace BiddingWebAPI.EFCore.DAL
{
    public interface ITransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
