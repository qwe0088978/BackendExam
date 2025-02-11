using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class MyOfficeDbContext : DbContext
{
    public MyOfficeDbContext(DbContextOptions<MyOfficeDbContext> options) : base(options) { }

    public DbSet<MyOfficeACPD> MyOffice_ACPD { get; set; }
    public DbSet<MyOfficeExecutionLog> MyOffice_ExcuteionLog { get; set; }
}
