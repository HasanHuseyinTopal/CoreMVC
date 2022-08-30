using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-TR1VOCD;database=CoreMVC;integrated security=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message2>()
                .HasOne(x => x.senderUser)
                .WithMany(x => x.WriterSender)
                .HasForeignKey(x => x.SenderID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message2>()
                 .HasOne(x => x.receiverUser)
                 .WithMany(x => x.WriterReceiver)
                 .HasForeignKey(x => x.ReceiverID)
                 .OnDelete(DeleteBehavior.ClientSetNull);
        }
        public DbSet<About> abouts { get; set; }
        public DbSet<Blog> blogs { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Writer> writers { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<NewsLatter> NewsLatters { get; set; }
        public DbSet<BlogRayting> blogRaytings { get; set; }
        public DbSet<Notification> notifications { get; set; }
        public DbSet<Message> messages { get; set; }
        public DbSet<Message2> messages2 { get; set; }

    }
}
