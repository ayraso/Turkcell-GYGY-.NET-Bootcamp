using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem
{
    public class TeacherService : ITeacherRepository
    {
        public List<ITeacher> Teachers;
        public List<HomeroomTeacher> HomeroomTeachers;
        public TeacherService()
        {
            Teachers = new List<ITeacher>();
            HomeroomTeachers = new List<HomeroomTeacher>();
        }
        public List<HomeroomTeacher> GetAllHomeroomTeachers() 
        {
            return this.HomeroomTeachers;
        }

        public void AddSubjectTeacher(string majorSubject, string name, string surname)
        {
            ITeacher entity = new SubjectTeacher(majorSubject.ConvertToTitleCase(), name.ConvertToTitleCase(), surname.ConvertToTitleCase());
            this.Add(entity);
        }
        public void Add(ITeacher entity)
        {
            this.Teachers.Add(entity);
            entity.Id = this.Teachers.GenerateId();
        }
        public void DeleteTeacherById(int id)
        {
            this.DeleteById(id);
        }
        public void DeleteById(int id)
        {
            this.Teachers.Remove(GetById(id));
        }
        public List<ITeacher> GetAllTeachers()
        {
            return this.GetAll();
        }
        public List<ITeacher> GetAll()
        {
            return this.Teachers;
        }
        public ITeacher GetTeacherById(int id)
        {
            return this.GetById(id);
        }
        public ITeacher GetById(int id)
        {
            ITeacher? teacher = this.Teachers.SingleOrDefault(student => student.Id == id);
            return teacher;
        }
        public List<ITeacher> GetTeacherByName(string matchName)
        {
            return this.GetByName(matchName.ConvertToTitleCase());
        }
        public List<ITeacher> GetByName(string matchName)
        {
            List<ITeacher>? teachers = this.Teachers.Where(teacher => teacher.Name == matchName).ToList();
            return teachers;
        }
        public List<ITeacher> GetTeacherBySurname(string matchSurname)
        {
            return this.GetBySurname(matchSurname.ConvertToTitleCase());
        }
        public List<ITeacher> GetBySurname(string matchSurname)
        {
            List<ITeacher>? teachers = this.Teachers.Where(teacher => teacher.Surname == matchSurname).ToList();
            return teachers;
        }
        public List<ITeacher> GetTeachersByMajorSubject(string matchMajorSubject)
        {
            return this.Teachers.Select(teacher => teacher).
                                 Where(teacher => teacher.MajorSubject.ConvertToTitleCase() == matchMajorSubject).ToList();
        }
        public HomeroomTeacher AssignSubjectTeacherAsHomeroomTeacher(ITeacher teacher, IClassroom classroom)
        {
            HomeroomTeacher newHomeroomTeacher = new HomeroomTeacher(teacher);
            newHomeroomTeacher.AssignedClassroomToGuide = classroom;
            this.HomeroomTeachers.Add(newHomeroomTeacher);
            return newHomeroomTeacher;
        }
        public HomeroomTeacher FindHomeroomTeacherOfClassroom(IClassroom classroom) 
        {
            HomeroomTeacher? homeroomTeacher = HomeroomTeachers.SingleOrDefault(teacher => teacher.AssignedClassroomToGuide.Id == classroom.Id);
            return homeroomTeacher;
        }
    }
}
