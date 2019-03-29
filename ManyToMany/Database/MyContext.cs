using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany.Database
{
    public class MyContext:DbContext
    {
        //public MyContext(DbContextOptions<MyContext> options):base(options)
        //{
            
        //}
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }


        // 控制台程序使用下列代码
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=ManyToMany.db");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
