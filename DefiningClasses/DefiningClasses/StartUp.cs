using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
   public class StartUp
    {
        public static void Main()
        {
            //Family family = new Family();

            int n = int.Parse(Console.ReadLine());

            var listOfPeople = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                var currentMember = Console.ReadLine().Split();
                var name = currentMember[0];
                var age = int.Parse(currentMember[1]);
                listOfPeople.Add(new Person(name, age));

                //Person person = new Person(name, age);

                //family.AddMember(person);
            }

            var orederPeople = listOfPeople.OrderBy(x => x.Name).Where(x => x.Age > 30);
            foreach (var people in orederPeople)
            {
                Console.WriteLine($"{people.Name} - {people.Age}");
            }

            //var oldestMember = family.GetOldestMembere();

            //Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
            
        }
    }
}
