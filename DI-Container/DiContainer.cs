using System;
using System.Collections.Generic;

namespace DI_Container
{
    public class DiContainer : IoContainer
    {

        private Type _type;
        private Type _interfaceType;

        private readonly Dictionary<Type, Type> types = new Dictionary<Type, Type>();

        private readonly Dictionary<Type, Delegate> delTypes = new Dictionary<Type, Delegate>();


        public void RegisterClass<T>() where T : class
        {
            _type = typeof(T);
            types[_type] = _type;
        }

        public void Register<T, R>() where R : class, T
        {
            try
            {
                _type = typeof(R);
                _interfaceType = typeof(T);

                types[_interfaceType] = _type;

            }
            catch (Exception)
            {
                Console.WriteLine($"Something goes wrong");
            }

        }

        public void RegisterDel<T>(Func<T> factory)
        {
            _interfaceType = typeof(T);
            delTypes.Add(typeof(T), factory);

        }

        public T Resolve<T>()
        {

            bool keyExists = types.ContainsKey(typeof(T));

            if (keyExists)
            {
                //Console.WriteLine(types[typeof(T)]);
                return (T)Activator.CreateInstance(types[typeof(T)]);
            }

            if (delTypes.ContainsKey(typeof(T)))
            {
                return ((Func<T>)delTypes[_interfaceType]).Invoke();
            }

            Console.WriteLine("Reference Not Registered");
            return default(T);

        }

    }
}