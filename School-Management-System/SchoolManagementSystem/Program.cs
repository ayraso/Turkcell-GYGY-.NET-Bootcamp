using SchoolManagementSystem;

StudentService StudentService = new StudentService();
StudentService.AddStudent("ayşe", "soylu");
StudentService.AddStudent("rabia", "soylu");
StudentService.AddStudent("ayşe", "çimen");
StudentService.AddStudent("özgür", "çelik");

var list = StudentService.GetAllStudents();
Console.WriteLine($"Tüm Öğrenciler: ");
foreach (var item in list)
{
    Console.WriteLine($"{item.Name} {item.Surname} {item.Id}");
}

var list2 = StudentService.GetStudentByName("ayşe");
Console.WriteLine($"Adı ayşe olan öğrenciler: ");
foreach (var item in list2)
{
    Console.WriteLine($"{item.Name} {item.Surname}");
}

var list3 = StudentService.GetStudentBySurname("soylu");
Console.WriteLine($"Soyadı soylu olan öğrenciler: ");
foreach (var item in list3)
{
    Console.WriteLine($"{item.Name} {item.Surname}");
}

var list4 = StudentService.GetStudentById(list[0].Id);
Console.WriteLine($"ID si x olan öğrenci: ");
Console.WriteLine($"{list4.Name} {list4.Surname} {list4.Id}");

var list5 = StudentService.GetStudentById(8);
Console.WriteLine($"olmayan öğrenci: ");
if (list5 != default(DomesticStudent))
    Console.WriteLine($"{list5.Name} {list5.Surname} {list5.Id}");

Console.WriteLine($"ID si x olan öğrenciyi silme: ");
StudentService.DeleteStudentById(list[0].Id);
var list6 = StudentService.GetAllStudents();
foreach (var item in list6)
{
    Console.WriteLine($"{item.Name} {item.Surname} {item.Id}");
}

Console.WriteLine($"Graduated Student yaratma: ");
StudentService.AddStudent("sıla", "çomak", false);
var list7 = StudentService.GetAllStudents();
foreach (var item in list7)
{
    Console.WriteLine($"{item.Name} {item.Surname} {item.Id}");
}



Console.WriteLine($"\n\n");
ClassroomService ClassroomService = new ClassroomService();

Console.WriteLine($"Classroom ekleme: ");
ClassroomService.AddClassroom(11, 'C', 's');
ClassroomService.AddClassroom(11, 'B', 'l');
ClassroomService.AddClassroom(10, 'C');
ClassroomService.AddClassroom(9, 'B');
ClassroomService.AddClassroom(9, 'A');
ClassroomService.AddClassroom(10, 'B');
var list8 = ClassroomService.GetAllClassrooms();
foreach(var item in list8)
{
    Console.WriteLine($"{item.Grade}{item.Section}");
}

Console.WriteLine($"\n\n");
TeacherService TeacherService = new TeacherService();

TeacherService.AddSubjectTeacher("math", "ayse", "soylu");
TeacherService.AddSubjectTeacher("music", "rabia", "soylu");

var list10 = TeacherService.GetAllTeachers();
foreach(var item in list10)
{
    Console.WriteLine($"{item.Name} {item.Surname} {item.MajorSubject} {item.Id}");
}
Console.WriteLine($"\n\n");

ITeacher teacherMe = list10[0];
HomeroomTeacher homeroomTeacherMe = new HomeroomTeacher(teacherMe);
Console.WriteLine($"{homeroomTeacherMe.Name} {homeroomTeacherMe.Surname} {homeroomTeacherMe.MajorSubject} {homeroomTeacherMe.Id}");

Console.WriteLine($"\n\n");

ITeacher teacherMe2 = list10[1];
HomeroomTeacher newbi = TeacherService.AssignSubjectTeacherAsHomeroomTeacher(teacherMe2, list8[1]);
ClassroomService.AssignHomeroomTeacherToClassroom(list8[1], newbi);

Console.WriteLine($"sınıf: {list8[1].Grade}{list8[1].Section} teacher: {list8[1].HomeroomTeacher.Id}");
Console.WriteLine($"teacher: {newbi.Id} sınıf: {newbi.AssignedClassroomToGuide.Grade}{newbi.AssignedClassroomToGuide.Section}");

Console.WriteLine($"\n\n");
var list11 = TeacherService.GetAllTeachers();
foreach (var item in list11)
{
    Console.WriteLine($"{item.Name} {item.Surname} {item.MajorSubject} {item.Id}");
}
Console.WriteLine($"\n\n");

Console.WriteLine("Homeroom teacher bulma:");
Console.WriteLine($"{TeacherService.FindHomeroomTeacherOfClassroom(list8[1]).Id}"); 

Console.WriteLine("Delege kullanımı:");
list[2].TakeTheQuiz();
list[0].TakeTheQuiz();

StudentService.AddStudent("nikol", "straus", false);
list = StudentService.GetAllStudents();
list[list.Count- 1].TakeTheQuiz();


