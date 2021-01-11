using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipesApp.Models;

namespace RecipesApp.Data.EntityConfigurations
{
    public class RecipeConfigurations : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder
               .Property(x => x.Name)
               .HasColumnName("Title")
               .IsRequired()
               .IsUnicode();

            modelBuilder.Entity<Recipe>()
                .Property(x => x.Description)
                .HasMaxLength(1000);

            //or

            modelBuilder.Entity<Recipe>(entity => //???????
            {
                builder.ToTable("MyRecipes", "system"); // ако искаме таблицата да има различно име от DbSet-a

                builder.HasKey(x => x.SomeKeyId); //ако пропъртито се казва не Id или RecipeId, a SomeKeyId по този начин го правим PrimaryKey

                builder.Property(x => x.Id).ValueGeneratedOnAddOrUpdate(); // да се добавя автоматично Id при insert, update

                builder.Property(x => x.Name)
                    .HasColumnName("Title")
                    .HasMaxLength(50)
                    .IsUnicode(true)
                    .IsRequired();

                builder.Ignore(x => x.Test);  //ако искаме дадено пропърти на го няма като колона в таблицата

                //ако искаме обратното - да има колона, която да не се отразява в класа - да няма пропърти - прави се Shadow Property:
                builder.Property<string>("Egn").HasColumnType("navarchar(10)"); // идеята е да не са достъпни за манипулация през кода

                builder.HasMany(x => x.Ingredients).WithOne(x => x.Recipe).OnDelete(DeleteBehavior.Cascade); // при изтриване на рецептата каскадно изтрива свързаните съставки
                //or
                builder.HasMany(x => x.Ingredients).WithOne(x => x.Recipe).OnDelete(DeleteBehavior.Restrict); // не позволява изтриване на рецептата докато не се изтрият съставките
                //or
                builder.HasMany(x => x.Ingredients).WithOne(x => x.Recipe).OnDelete(DeleteBehavior.SetNull); // set-ва рецептата на null при съставките и изтрива рецептата, съставките сочат към null (ако е nullable съответната колона) 
            }
    }
}
