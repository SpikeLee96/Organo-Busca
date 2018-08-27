namespace Organobusca.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class dbOrg : DbContext
    {
        public dbOrg()
            : base("name=dbOrg1")
        {
        }

        public virtual DbSet<Avaliacao> Avaliacao { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<DiaDaSemana> DiaDaSemana { get; set; }
        public virtual DbSet<Estoque> Estoque { get; set; }
        public virtual DbSet<Feira> Feira { get; set; }
        public virtual DbSet<Feirante> Feirante { get; set; }
        public virtual DbSet<Preferencia> Preferencia { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Avaliacao>()
                .Property(e => e.comentario)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.senha)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.url_foto)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Avaliacao)
                .WithOptional(e => e.Cliente)
                .HasForeignKey(e => e.Cliente_id);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Preferencia)
                .WithOptional(e => e.Cliente)
                .HasForeignKey(e => e.Cliente_id);

            modelBuilder.Entity<Feira>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Feira>()
                .Property(e => e.bairro)
                .IsUnicode(false);

            modelBuilder.Entity<Feira>()
                .Property(e => e.cidade)
                .IsUnicode(false);

            modelBuilder.Entity<Feira>()
                .Property(e => e.rua)
                .IsUnicode(false);

            modelBuilder.Entity<Feira>()
                .Property(e => e.cep)
                .IsUnicode(false);

            modelBuilder.Entity<Feira>()
                .Property(e => e.numero)
                .IsUnicode(false);

            modelBuilder.Entity<Feira>()
                .HasMany(e => e.DiaDaSemana)
                .WithRequired(e => e.Feira)
                .HasForeignKey(e => e.Feira_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Feira>()
                .HasMany(e => e.Feirante)
                .WithOptional(e => e.Feira)
                .HasForeignKey(e => e.Feira_id);

            modelBuilder.Entity<Feirante>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Feirante>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Feirante>()
                .Property(e => e.senha)
                .IsUnicode(false);

            modelBuilder.Entity<Feirante>()
                .Property(e => e.site)
                .IsUnicode(false);

            modelBuilder.Entity<Feirante>()
                .Property(e => e.url_foto)
                .IsUnicode(false);

            modelBuilder.Entity<Feirante>()
                .HasMany(e => e.Avaliacao)
                .WithOptional(e => e.Feirante)
                .HasForeignKey(e => e.Feirante_id);

            modelBuilder.Entity<Feirante>()
                .HasMany(e => e.Estoque)
                .WithOptional(e => e.Feirante)
                .HasForeignKey(e => e.Feirante_id);

            modelBuilder.Entity<Produto>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .HasMany(e => e.Estoque)
                .WithOptional(e => e.Produto)
                .HasForeignKey(e => e.Produto_id);

            modelBuilder.Entity<Produto>()
                .HasMany(e => e.Preferencia)
                .WithOptional(e => e.Produto)
                .HasForeignKey(e => e.Produto_id);
        }
    }
}
