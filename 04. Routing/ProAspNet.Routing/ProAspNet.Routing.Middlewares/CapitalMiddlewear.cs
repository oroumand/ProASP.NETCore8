
namespace ProAspNet.Routing.Middlewares
{
    public class CapitalMiddlewar
    {
        private RequestDelegate next;

        public CapitalMiddlewar(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var segments = context.Request.Path.ToString().Split('/', StringSplitOptions.RemoveEmptyEntries);

            if (segments.Length == 2)
            {
                bool isCapital = segments[0] == "Capital";
                string country = segments[1];
                string capital = string.Empty;
                if (isCapital)
                {
                    switch (country)
                    {
                        case "Iran":
                            capital = "Tehran";
                            break;
                        case "USA":
                            capital = "Washengton";
                            break;
                        case "Tehran":
                            context.Response.Redirect("/Population/Tehran");
                            return;
                    }

                    if (!string.IsNullOrEmpty(capital))
                    {
                        await context.Response.WriteAsync(capital);
                    }
                }
            }
            next(context);
        }
    }


    public class PopulationMiddlewar
    {
        private RequestDelegate next;
        public PopulationMiddlewar()
        {
            
        }
        public PopulationMiddlewar(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var segments = context.Request.Path.ToString().Split('/', StringSplitOptions.RemoveEmptyEntries);

            if (segments.Length == 2)
            {
                bool isPopulation = segments[0] == "Population";
                string city = segments[1];
                string population = string.Empty;
                if (isPopulation)
                {
                    switch (city)
                    {
                        case "Tehran":
                            population = "10000000";
                            break;
                        case "Isfahan":
                            population = "5000000";
                            break;

                    }

                    if (!string.IsNullOrEmpty(population))
                    {
                        await context.Response.WriteAsync(population);
                    }
                }
            }
            next(context);
        }
    }
}
