namespace PhotoShare.Data.Repositories
{
    using Contracts;
    using Models;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly PhotoShareContext context = new PhotoShareContext();
        private IRepository<Album> albums;
        private IRepository<Picture> pictures;
        private IRepository<Tag> tags;
        private IRepository<Town> towns;
        private IRepository<User> users;
        private IRepository<AlbumRole> albumsRoles;

        public IRepository<Album> Albums => this.albums ?? (this.albums = new Repository<Album>(this.context));

        public IRepository<Picture> Pictures => this.pictures ?? (this.pictures = new Repository<Picture>(this.context));

        public IRepository<Tag> Tags => this.tags ?? (this.tags = new Repository<Tag>(this.context));

        public IRepository<Town> Towns => this.towns ?? (this.towns = new Repository<Town>(this.context));

        public IRepository<User> Users => this.users ?? (this.users = new Repository<User>(this.context));

        public IRepository<AlbumRole> AlbumsRoles
            => this.albumsRoles ?? (this.albumsRoles = new Repository<AlbumRole>(this.context));
        

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
