using System;
using System.Data.Entity;
using LibrarySystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LibrarySystem.Context
{
    public class LibrarySystemContext : IdentityDbContext<User, UserClaim, UserSecret, UserLogin, Role, UserRole, Token, UserManagement>
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Book> Books { get; set; }
    }
}
