using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;
        
        public Family()
        {
            this.people = new List<Person>();
        }
        public void AddMember(Person person)
        {
            this.people.Add(person);
        }

        public Person GetOldestMembere()
            => people.OrderByDescending(a => a.Age).FirstOrDefault();
       
        public void MembersMoreThenTirty(List<Person> members)
        {
            foreach (var member in members.Where(x => x.Age > 30).OrderBy(x => x.Name))
            {
                Console.WriteLine($"{member.Name} {member.Age}");
            }
        }
    }
}
