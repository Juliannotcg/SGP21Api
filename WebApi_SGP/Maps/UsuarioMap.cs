using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi_SGP.Model;

namespace WebApi_SGP.Maps
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("UsuUsuario");

            builder.Property(c => c.UsuId)
               .HasColumnName("UsuId");

            builder.Property(c => c.UsuLogin)
              .HasColumnName("UsuLogin");

            builder.Property(c => c.UsuNome)
              .HasColumnName("UsuNome");

            builder.Property(c => c.UsuSenha)
                .HasColumnName("UsuSenha");

            builder.Property(c => c.UsuCategoria)
                .HasColumnName("UsuCategoria");

            builder.Property(c => c.UsuSituacao)
                .HasColumnName("UsuSituacao");

            builder.Property(c => c.UsuPrazoSenha)
                .HasColumnName("UsuPrazoSenha");

            builder.Property(c => c.UsuUltimaAlteracaoSenha)
                .HasColumnName("UsuUltimaAlteracaoSenha");

            builder.Property(c => c.UsuHoraInicioExpediente)
                .HasColumnName("UsuHoraInicioExpediente");

            builder.Property(c => c.UsuHoraFimExpediente)
                .HasColumnName("UsuHoraFimExpediente");

            builder.Property(c => c.Usu_PerId)
               .HasColumnName("Usu_PerId");

            builder.Property(c => c.Usu_CrgId)
             .HasColumnName("Usu_CrgId");



            //builder.OwnsOne(c => c.Usu_PerId, perfil =>
            //{
            //    perfil.Property(p => p.PerId)
            //     .HasColumnName("Usu_PerId");
            //});

            //builder.OwnsOne(c => c.Usu_CarId, cargo =>
            //{
            //    cargo.Property(p => p.CrgId)
            //     .HasColumnName("Usu_PerId");
            //});
        }
    }
}
