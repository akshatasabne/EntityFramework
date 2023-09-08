using System.ComponentModel.DataAnnotations.Schema;

namespace CrudUsingEntityFramework.Models
{

    public class MovieCrud
    {
        ApplicationDbContext context;
        private IConfiguration configuration;

        public MovieCrud(ApplicationDbContext context)
        {
            this.context = context;
        }

        public MovieCrud(IConfiguration configuration)
        {
            this.configuration = configuration;


        }

        public IEnumerable<Movie> GetMovies()
        {
            return context.Movies.Where(x => x.IsActive == 1).ToList();
        }
        public Movie GetMovieById(int id)
        {
            var movie = context.Movies.Where(x => x.Id == id).FirstOrDefault();
            return movie;
        }
        public int AddMovie(Movie movie)
        {
            movie.IsActive = 1;
            int result = 0;
            context.Movies.Add(movie);
            result = context.SaveChanges();
            return result;
        }
        public int UpdateMovie(Movie movie)
        {
            int result = 0;
            var b = context.Movies.Where(x => x.Id == movie.Id).FirstOrDefault();
            if (b != null)
            {
                b.Mname = movie.Mname;
                b.ReleaseDate = movie.ReleaseDate;
                b.Genre = movie.Genre;
                b.StarsName = movie.StarsName;
                b.IsActive = 1;
                result = context.SaveChanges();
            }
            return result;
        }
        public int DeleteMovie(int id)
        {


            int result = 0;
            // search from dbset
            var b = context.Movies.Where(x => x.Id == id).FirstOrDefault();
            if (b != null)
            {
                b.IsActive = 0;
                result = context.SaveChanges(); // update the change from DbSet to DB
            }


            return result;
        }


    }
}
