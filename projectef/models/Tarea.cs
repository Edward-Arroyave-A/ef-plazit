using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectef.models;


public class Tarea {
    // [Key]
    public Guid TareaId{get;set;}

    // [ForeignKey("CategoriaId")]
    public Guid CatergoriaId {get;set;}

    // [Required]
    // [MaxLength(200)]
    public string? Titulo {get;set;}
    public string? Descripcion {get;set;}

    public Prioridad PrioridadTarea {get;set;}

    public DateTime FechaCreacion {get;set;}


    public virtual Categoria? Categoria {get; set;}
    
    // [NotMapped]
    public virtual string? Resumen {get; set;}
}

public enum Prioridad {

    Alta,
    media,
    baja
}
