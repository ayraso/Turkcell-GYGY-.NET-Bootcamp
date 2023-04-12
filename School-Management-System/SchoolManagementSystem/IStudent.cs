using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem
{
    public interface IStudent : IHasID
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public void ViewTranscript();
        public void SubmitHomework();
        public void TakeTheQuiz();

        public delegate void Translator();
    }
}
