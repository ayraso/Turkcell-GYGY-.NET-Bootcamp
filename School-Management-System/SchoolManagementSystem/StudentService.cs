using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem
{
    public class StudentService : IStudentRepository, IStudentFactory
    {
        public List<IStudent> Students { get; set; }
        public StudentService() 
        {
            this.Students = new List<IStudent>();
        }
        public IStudent CreateStudent(string name, string surname, bool? isDomestic = null) 
        {
            if (isDomestic == false)
            {
                return new ExchangeStudent(name.ConvertToTitleCase(), surname.ConvertToTitleCase());
            }
            else
            {
                return new DomesticStudent(name.ConvertToTitleCase(), surname.ConvertToTitleCase());
            }
        }
        public void AddStudent(string name, string surname, bool? isActive = null)
        {
            this.Add(this.CreateStudent(name, surname, isActive));
        }
        public void Add(IStudent entity)
        {
            Students.Add(entity);
            entity.Id = Students.GenerateId();
        }
        public void DeleteStudentById(int id)
        {
            this.DeleteById(id);
        }
        public void DeleteById(int id)
        {
            Students.Remove(GetById(id));
        }
        public List<IStudent> GetAllStudents()
        {
            return this.GetAll();
        }
        public List<IStudent> GetAll()
        {
            return this.Students;
        }
        public IStudent GetStudentById(int id)
        {
            return this.GetById(id);
        }
        public IStudent GetById(int id)
        {
            IStudent? student = this.Students.SingleOrDefault(student => student.Id == id);
            return student;
        }
        public List<IStudent> GetStudentByName(string matchName)
        {
            return this.GetByName(matchName.ConvertToTitleCase());
        }
        public List<IStudent> GetByName(string matchName)
        {
            List<IStudent>? students = this.Students.Where(student => student.Name == matchName).ToList();
            return students;
        }
        public List<IStudent> GetStudentBySurname(string matchSurname)
        {
            return this.GetBySurname(matchSurname.ConvertToTitleCase());
        }
        public List<IStudent> GetBySurname(string matchSurname)
        {
            List<IStudent>? students = this.Students.Where(student => student.Surname == matchSurname).ToList();
            return students;
        }
    }
}
