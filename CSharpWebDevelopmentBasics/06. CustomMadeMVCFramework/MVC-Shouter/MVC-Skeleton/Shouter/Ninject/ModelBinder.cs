namespace Shouter.Ninject
{
    using Data;
    using Data.Contracts;
    using global::Ninject.Modules;
    class ModelBinder : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IShouterContext>().To<ShouterContext>();
        }
    }
}
