using Microsoft.EntityFrameworkCore;
using projectef.models;

namespace proyjectef;


public  class TareasContex: DbContext {

    public DbSet<Categoria> Categorias {get;set;}
    public DbSet<Tarea> Tareas {get;set;}

    public TareasContex(DbContextOptions<TareasContex> options): base (options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder){

        modelBuilder.Entity<Categoria>(Categoria => {
            Categoria.ToTable("categoria");
            Categoria.HasKey(P => P.CategoriadId );
            Categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
            Categoria.Property(p => p.Descripcion);
            Categoria.Property(p => p.peso);
        });


        modelBuilder.Entity<Tarea>(tarea => {
            tarea.ToTable("Tarea");
            tarea.HasKey(tarea => tarea.TareaId );
            tarea.Property(tarea => tarea.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(tarea => tarea.Descripcion);
            tarea.Property(tarea => tarea.PrioridadTarea);
            tarea.Property(tarea => tarea.FechaCreacion);
            tarea.HasOne(tarea => tarea.Categoria).WithMany(trea => trea.Tareas).HasForeignKey( categoria => categoria.CatergoriaId);
            tarea.Ignore(tarea => tarea.Resumen);
        });  
       
    }   
}