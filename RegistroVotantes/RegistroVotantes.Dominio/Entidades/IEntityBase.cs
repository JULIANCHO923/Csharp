namespace RegistroVotantes.Dominio.Entidades
{
    public interface IEntityBase<T>
    {
        T Id { get; set; }
    }
}