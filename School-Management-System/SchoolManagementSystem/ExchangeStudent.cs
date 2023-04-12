using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SchoolManagementSystem.IStudent;

namespace SchoolManagementSystem
{
    public class ExchangeStudent : IStudent
    {
        public ExchangeStudent(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Id { get; set; }

        public void SubmitHomework()
        {
            Console.WriteLine($"The assignment has been submitted.");
        }
        public void TakeTheQuiz()
        {
            Translator quizTranslator = new Translator(TakeQuizInGerman);
            quizTranslator();
        }
        public void TakeQuizInGerman()
        {
            Console.WriteLine($"Die Prüfung ist gestartet.");
        }

        public void ViewTranscript()
        {
            Console.WriteLine($"Transcript has been displayed.");
        }
    }
}
