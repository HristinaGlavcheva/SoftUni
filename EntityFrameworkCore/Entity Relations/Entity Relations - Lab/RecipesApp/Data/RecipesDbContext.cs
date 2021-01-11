using Microsoft.EntityFrameworkCore;
using RecipesApp.Data.EntityConfigurations;
using RecipesApp.Models;
using System.Security.Cryptography.X509Certificates;

namespace RecipesApp.Data
{
    public class RecipesDbContext : DbContext
    {
        public RecipesDbContext()
        {
        }

        public RecipesDbContext(DbContextOptions<RecipesDbContext> options)
            :base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.; Database=Recipes; Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RecipeConfigurations()); // акo сме изнесли настройките в отделен клас така ги добавяме тук

            modelBuilder.Entity<Recipe>().HasKey(x => new { x.Id, x.Name }); // композите ключ правим само прес Fluent API, няма възможност с атрибути
            // or
            modelBuilder.Entity<Recipe>().HasKey(new[] { "Id", "Name" });
            // or
            modelBuilder.Entity<Recipe>().HasKey("Id", "Name"); // става и така, защото HasKey приема params string[]

            //пак така се прави индекс, няма атрибут:
            modelBuilder.Entity<Recipe>().HasIndex(x => new { x.Id, x.Name }).IsUnique();

            //само през Fluent API се задава и Delete.Cascade или Restrict...

            modelBuilder.Entity<Recipe>()
                .Property(x => x.Name)
                .HasColumnName("Title")
                .IsRequired()
                .IsUnicode();

            modelBuilder.Entity<Recipe>()
                .Property(x => x.Description)
                .HasMaxLength(1000);

            //or

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("MyRecipes", "system"); // ако искаме таблицата да има различно име от DbSet-a

                entity.HasKey(x => x.SomeKeyId); //ако пропъртито се казва не Id или RecipeId, a SomeKeyId по този начин го правим PrimaryKey

                entity.Property(x => x.Id).ValueGeneratedOnAddOrUpdate(); // да се добавя автоматично Id при insert, update

                entity.Property(x => x.Name)
                    .HasColumnName("Title")
                    .HasMaxLength(50)
                    .IsUnicode(true)
                    .IsRequired();

                entity.Ignore(x => x.Test);  //ако искаме дадено пропърти на го няма като колона в таблицата

                entity.HasMany(x => x.Ingredients).WithOne(x => x.Recipe).OnDelete(DeleteBehavior.Cascade); // при изтриване на рецептата каскадно изтрива свързаните съставки
                //or
                entity.HasMany(x => x.Ingredients).WithOne(x => x.Recipe).OnDelete(DeleteBehavior.Restrict); // не позволява изтриване на рецептата докато не се изтрият съставките
                //or
                entity.HasMany(x => x.Ingredients).WithOne(x => x.Recipe).OnDelete(DeleteBehavior.SetNull); // set-ва рецептата на null при съставките и изтрива рецептата, съставките сочат към null (ако е nullable съответната колона) 

                modelBuilder.Entity<Recipe>()
                    .HasMany(x => x.Ingredients) // при many-to-many връзката тук е към междинния клас
                    .WithOne(x => x.Recipe)
                    .HasForeignKey(x => x.RecipeId)
                    .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Ingredient>()
                    .HasMany(x => x.Recipes)
                    .WithOne(x => x.Ingredient);
            });
        }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }
    }
}
