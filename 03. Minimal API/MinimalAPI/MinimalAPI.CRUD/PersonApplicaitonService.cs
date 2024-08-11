namespace MinimalAPI.CRUD
{
    public class PersonApplicaitonService
    {
        public static void Add(Person person)
        {
            PersonRepository.Instance().Add(person);
        }

        public void Remove(int id)
        {
            PersonRepository.Instance().Remove(id);
        }
    }
}
