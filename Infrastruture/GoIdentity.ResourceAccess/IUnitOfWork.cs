namespace GoIdentity.ResourceAccess
{
    public interface IUnitOfWork
    {
        IdentityDbContext GetIdentityDbContext(bool createNew = false);
        void ClearAll();
    }
}
