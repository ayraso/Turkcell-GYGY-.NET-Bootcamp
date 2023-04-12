using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem
{
    public class ClassroomService : IClassroomRepository, IClassroomFactory
    {
        public List<IClassroom> Classrooms { get; set ; }
        public ClassroomService()
        {
            this.Classrooms = new List<IClassroom>();
        }
        public IClassroom CreateClassroom(int grade, char section, char? programType = null)
        {
            {
                if (programType.HasValue)
                {
                    return new RegularClassroom(grade, section);
                }
                else if (programType == 'l')
                {
                    return new LanguageFocusedClassroom(grade, section);
                }
                else //(programType == 's')
                {
                    return new LanguageFocusedClassroom(grade, section);
                }
            }
        }
        public void AddClassroom(int grade, char section, char? programType = null)
        {
            this.Add(this.CreateClassroom(grade, section, programType));
        }
        public void Add(IClassroom entity)
        {
            Classrooms.Add(entity);
            entity.Id = Classrooms.GenerateId();
        }
        public void DeleteClassroomById(int id)
        {
            this.DeleteById(id);
        }
        public void DeleteClassroomByCode(int grade, int section)
        {
            IClassroom? classroom = this.Classrooms.SingleOrDefault(classroom => classroom.Grade == grade && classroom.Section == section);
            if (classroom != null) 
                this.DeleteById(classroom.Id);
        }
        public void DeleteById(int id)
        {
            Classrooms.Remove(GetById(id));
        }
        public List<IClassroom> GetAllClassrooms()
        {
            return this.GetAll();
        }
        public List<IClassroom> GetAll()
        {
            return this.Classrooms;
        }
        public IClassroom GetClassroomByCode(int grade, char section)
        {
            return this.Classrooms.SingleOrDefault(classroom => classroom.Grade == grade && classroom.Section == section);
        }

        public IClassroom GetById(int id)
        {
            IClassroom? classroom = this.Classrooms.SingleOrDefault(classroom => classroom.Id == id);
            return classroom;
        }
        public void AddStudentToClassroom(IClassroom classroom, IStudent student)
        {
            classroom.Students.Add(student);
        }
        public void DeleteStudentFromClassroom(IClassroom classroom, IStudent student)
        {
            classroom.Students.Remove(student);
        }
        public void AssignHomeroomTeacherToClassroom(IClassroom classroom, ITeacher teacher) 
        {
            classroom.HomeroomTeacher = teacher;
        }
    }
}
