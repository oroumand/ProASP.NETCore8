namespace MinimalAPI.Status
{
    public class PersonRepository
    {
        private readonly List<Person> _people = [];
        private static PersonRepository _instance;

        public static PersonRepository Instance()
        {
            _instance ??= new PersonRepository();
            return _instance;
        }
        private PersonRepository()
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

        public void Add(Person person)
        {
            if (_people.Any(c => c.Id == person.Id))
            {
                throw new Exception("Invalid Person Id");
            }
            _people.Add(person);
        }

        public void Remove(int id)
        {
            var person = _people.FirstOrDefault((c) => c.Id == id);
            _people.Remove(person);
        }
    }
}
