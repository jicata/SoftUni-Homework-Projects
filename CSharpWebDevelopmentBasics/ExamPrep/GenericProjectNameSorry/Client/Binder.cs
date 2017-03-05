namespace SoftUniStore.Client
{
    using Data;
    using Data.Contracts;
    using Data.Repositories;
    using Ninject.Modules;
    class Binder : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ISoftStoreData>().To<SoftStoreData>();
            this.Bind<ISoftStoreContext>().To<SoftStoreContext>();
        }
    }
}
