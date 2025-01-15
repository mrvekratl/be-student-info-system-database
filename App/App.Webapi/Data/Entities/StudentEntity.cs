using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Webapi.Data.Entities
{
    public class StudentEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int StudentNumber { get; set; }
        public string Class { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
    public class StudentEntityConfiguration : IEntityTypeConfiguration<StudentEntity>
    {
        public void Configure(EntityTypeBuilder<StudentEntity> builder)
        {
            // Id özelliği için ayarlar
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd(); // Identity özelliği
            //UserName Özelliği için ayarlar
            builder.Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(50);
            // Name özelliği için ayarlar
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);
            // Surname özelliği için ayarlar
            builder.Property(x => x.Surname)
                .IsRequired()
                .HasMaxLength(50);
            // StudentNumber özelliği için ayarlar
            builder.Property(x => x.StudentNumber)
                .IsRequired();              
            // Class özelliği için ayarlar
            builder.Property(x => x.Class)
                .IsRequired();
            //Password Özelliği için ayarlar
            builder.Property(x => x.Password)
            .IsRequired()
            .HasMaxLength(255); // Parolalar genellikle hash'lenir ve bu yüzden uzunluk daha büyük olabilir.
        }
    }



}
