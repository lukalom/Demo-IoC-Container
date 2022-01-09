namespace DI_Container
{
    class User : IUserEntity
    {
        public string Ping()
        {
            return "User Ping!";
        }

    }
}