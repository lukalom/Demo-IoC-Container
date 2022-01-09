using System;

namespace DI_Container
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = new DiContainer();


            container.Register<IUserEntity, User>();
            container.RegisterClass<Test>();
            container.RegisterClass<User>();
            container.RegisterClass<DirectLink>();
            container.Register<IUserEntity, User>();
            container.Register<IDirectLink, DirectLink>();
            container.RegisterDel<IForDelegate>(() =>
            {
                return new ForDelegate();
            });

            Console.WriteLine(container.Resolve<User>().Ping());
            Console.WriteLine(container.Resolve<DirectLink>().Ping());
            Console.WriteLine(container.Resolve<IDirectLink>().Ping());
            Console.WriteLine(container.Resolve<IUserEntity>().Ping());
            Console.WriteLine(container.Resolve<Test>().Log());
            Console.WriteLine(container.Resolve<IForDelegate>().SomeMethod());


        }

    }


}
