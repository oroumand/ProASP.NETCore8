namespace MinimalAPI.RoutGroupSamples
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
            Dictionary<string, string[]> ValidationErrors = new Dictionary<string, string[]>();
            if (string.IsNullOrEmpty(person.FirstName))
            {
                ValidationErrors.Add("FirstName", ["FirstName Is Null"]);
            }
            if (string.IsNullOrEmpty(person.LastName))
            {
                ValidationErrors.Add("LastName", ["LastName Is Null"]);
            }
            if (ValidationErrors.Count > 0)
            {
                return Results.ValidationProblem(ValidationErrors, title: "Validation Error");
            }
            try
            {
                PersonRepository.Instance().Add(person);
                return Results.Created($"/people/{person.Id}", person);
            }
            catch (Exception ex)
            {
                return Results.Problem(title: "My code Stopped", detail: ex.Message);
            }


        }

        public static IResult Remove(int id)
        {
            PersonRepository.Instance().Remove(id);
            return Results.NoContent();
        }
    }
}
