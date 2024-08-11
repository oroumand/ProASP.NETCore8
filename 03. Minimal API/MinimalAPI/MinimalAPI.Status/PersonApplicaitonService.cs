namespace MinimalAPI.Status
{
    public class PersonApplicaitonService
    {

        public static IResult GetAll()
        {
            return TypedResults.Ok(PersonRepository.Instance().Get());
        }


        public static IResult Get(int id)
        {
            var person = PersonRepository.Instance().Get(id);

            if (person == null)
            {
                return Results.NotFound(id);
            }
            return TypedResults.Ok(person);
        }

        public static IResult Add(Person person)
        {
            if (string.IsNullOrEmpty(person.FirstName) || string.IsNullOrEmpty(person.LastName))
            {
                return Results.BadRequest(new
                {
                    Message = "Firstname or Lastname is null or empy"
                });

            }
            try
            {
                PersonRepository.Instance().Add(person);
                return Results.Created($"/people/{person.Id}", person);
            }
            catch (Exception)
            {
                return Results.StatusCode(500);
            }

        }

        public static IResult Remove(int id)
        {
            PersonRepository.Instance().Remove(id);
            return Results.NoContent();
        }
    }
}
