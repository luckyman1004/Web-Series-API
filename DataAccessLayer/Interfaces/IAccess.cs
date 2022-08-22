namespace DataAccessLayer.Interfaces
{
    public interface IAccess<T, ID>
    {
        T GetLoginByToken(ID obj);
    }
}
