using MinimalAPI.HttpVerbs;

namespace MinimalAPI.RoutParameter
{
    public class PersonRepository
    {
        private readonly List<Person> _people=[];
        public static PersonRepository Instance => new();
        public PersonRepository()
        {
            _people.Add(new Person
            {
                Id = 1,
                FirstName = "Alireza",
                LastName = "Oroumand"
            });
            _people.Add(new Person
            {
                Id = 2,
                FirstName = "Mohammad",
                LastName = "Abbasi"
            });
            _people.Add(new Person
            {
                Id = 3,
                FirstName = "Masoud",
                LastName = "Taheri"
            });
            _people.Add(new Person
            {
                Id = 4,
                FirstName = "Farid",
                LastName = "Taheri"
            });
        }

        public Person Get(int id)
        {
            return _people.FirstOrDefault(c => c.Id == id);
        }

        public List<Person> Get()
        {
            return _people;
        }
    }
}
