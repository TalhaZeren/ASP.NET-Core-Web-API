using WebAPI.Utilities.Formatters;

namespace WebAPI.Extensions
{
    public static class IMvcBuilderExtensionscs
    {

        public static IMvcBuilder AddCustomCsvFormatter(this IMvcBuilder builder) =>
            builder.AddMvcOptions(config =>
            config.OutputFormatters
            .Add(new CsvOutputFormatter()));
    }
}
