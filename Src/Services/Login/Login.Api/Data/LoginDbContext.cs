using Login.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Login.Api.Data;

public class LoginDbContext:DbContext
{
    public LoginDbContext(DbContextOptions<LoginDbContext> options) : base(options)
    {

    }
    public DbSet<UserDetail> userDetails { get; set; }
}
