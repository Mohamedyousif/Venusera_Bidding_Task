using System;
using System.Collections.Generic;
using System.Text;
using BiddingWebAPI.EFCore.Model;
using Microsoft.EntityFrameworkCore;

namespace BiddingWebAPI.EFCore
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options)
       : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestAttachement> RequestAttachements { get; set; }
        public DbSet<RequestComment> RequestComments { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ServiceProvider> ServiceProviders { get; set; }
    }
}
