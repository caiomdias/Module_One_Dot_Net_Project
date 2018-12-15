using ClassLibrary1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Friend
    {
        public Friend(int id, string name, string lastName, string birthDate)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            BirthDate = DateTime.Parse(birthDate);
        }

        public int Id { get; set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; set; }

        public int GetDaysToBirthDate()
        {
            var finalDate = DateTime.Now;
            var initialDate = new DateTime(2019, BirthDate.Month, BirthDate.Day);

            TimeSpan response = initialDate - finalDate;

            return response.Days;
        }
    }
}
