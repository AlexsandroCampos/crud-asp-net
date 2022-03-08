using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuSiteEmMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuSiteEmMVC.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<ContatoModel> Contatos { get; set; }
    }
}
