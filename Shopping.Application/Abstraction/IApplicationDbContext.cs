﻿
using Microsoft.EntityFrameworkCore;
using Shopping.Domain.Models;

namespace Shopping.Application.Abstraction
{
    public interface IApplicationDbContext
    {
        public DbSet<Product> Products { get; }
        public DbSet<Order> Orders { get; }
        public DbSet<Category> Categories { get;  }
        public DbSet<Customer> Customers { get; }
        public DbSet<Role> Roles { get; }
        public DbSet<Permission> Permissions { get; }
        public DbSet<RolePermission> RolePermissions { get; }
        public DbSet<User> Users { get; }
        public DbSet<OrderProduct> OrderProducts { get; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; }
        public DbSet<UserRole> UserRoles { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
    
}
