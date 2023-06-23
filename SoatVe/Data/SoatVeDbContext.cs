﻿using Microsoft.EntityFrameworkCore;
using SoatVe.Models;

namespace SoatVe.Data
{
    public class SoatVeDbContext : DbContext
    {
        public SoatVeDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ChuongTrinh> ChuongTrinhs { get; set; }

        public DbSet<TinTuc> TinTucs { get; set; }
        public DbSet<DiaDiem> DiaDiems { get; set; }
        public DbSet<MenuHoTro> MenuHoTros { get; set; }

    }
}
