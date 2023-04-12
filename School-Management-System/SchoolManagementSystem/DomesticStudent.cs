using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SchoolManagementSystem.IStudent;

namespace SchoolManagementSystem
{
    public class DomesticStudent : IStudent
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Id { get; set ; }

        public DomesticStudent(string name, string surname)
        { 
            this.Name = name;
            this.Surname = surname;
        }
        public void ViewTranscript()
        {
            Console.WriteLine($"Transcript has been displayed.");
        }
        public void SubmitHomework()
        {
            Console.WriteLine($"The assignment has been submitted.");
        }

        public void TakeTheQuiz()
        {
            Translator quizTranslator = new Translator(TakeQuizInEnglish);
            quizTranslator();
        }
        public void TakeQuizInEnglish()
        {
            Console.WriteLine($"The exam has been started.");
        }
    }
}
