namespace CrudUsingEntityFramework.Models
{
    public class StudentCrud
    {
        ApplicationDbContext context;
        private IConfiguration configuration;

        public StudentCrud(ApplicationDbContext context)
        {
            this.context = context;
        }

        public StudentCrud(IConfiguration configuration)
        {
            this.configuration = configuration;


        }

        public IEnumerable<Student> GetStudents()
        {
            return context.Students.Where(x => x.IsActive == 1).ToList();
        }
        public Student GetStudentById(int id)
        {
            var student = context.Students.Where(x => x.Id == id).FirstOrDefault();
            return student;
        }
        public int AddStudent(Student student)
        {
            student.IsActive = 1;
            int result = 0;
            context.Students.Add(student);
            result = context.SaveChanges();
            return result;
        }
        public int UpdateStudent(Student student)
        {
            int result = 0;
            var b = context.Students.Where(x => x.Id == student.Id).FirstOrDefault();
            if (b != null)
            {
                b.Name = student.Name;
                b.Marks = student.Marks;
                b.IsActive = 1;
                result = context.SaveChanges();
            }
            return result;
        }
        public int DeleteStudent(int id)
        {


            int result = 0;
            // search from dbset
            var b = context.Students.Where(x => x.Id == id).FirstOrDefault();
            if (b != null)
            {
                b.IsActive = 0;
                result = context.SaveChanges(); // update the change from DbSet to DB
            }


            return result;
        }

    }
}

