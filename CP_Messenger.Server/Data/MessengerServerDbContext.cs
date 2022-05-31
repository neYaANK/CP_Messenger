using CP_Messenger.Common.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CP_Messenger.Server.Data
{
    public class MessengerServerDbContext: DbContext
    {
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SmallImage> Images { get; set; }
        //Add model for bigimage
        public DbSet<UserCredential> Credentials { get; set; }
        public DbSet<UsersChats> UsersChats { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersChats>()
                .HasKey(bc => new { bc.UserId, bc.ChatId });
            modelBuilder.Entity<UsersChats>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.UsersChats)
                .HasForeignKey(bc => bc.ChatId);
            modelBuilder.Entity<UsersChats>()
                .HasOne(bc => bc.Chat)
                .WithMany(c => c.UsersChats)
                .HasForeignKey(bc => bc.UserId);

            modelBuilder.Entity<Contact>()
                .HasOne(o => o.Owner)
                .WithMany(c => c.Contacts)
                .HasForeignKey(f => f.OwnerId);


            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@$"FileName={Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\messengerServer.db");            
            base.OnConfiguring(optionsBuilder);
        }
    }
}
