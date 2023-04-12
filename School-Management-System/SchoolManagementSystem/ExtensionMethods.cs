using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace SchoolManagementSystem
{
    public static class ExtensionMethods
    {
        public static int GenerateId<T>(this List<T> items) where T : IHasID
        {
            List<int> existingIDs = items.Select(item => item.Id).ToList();

            Random random = new Random();
            int newID = 0;
            do
            {
                newID = random.Next(100, 10000);
            } while (existingIDs.Contains(newID));
            existingIDs.Add(newID);

            return newID;
        }

        public static string ConvertToTitleCase(this string inputString)
        {
            string firstChar = inputString.Substring(0, 1).ToUpper();
            string lastOfString = inputString.Substring(1, inputString.Length - 1);
            return (firstChar + lastOfString);
        }
    }
}
