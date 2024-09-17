using Entities.DataTransferObject;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using Microsoft.Net.Http.Headers;
namespace WebAPI.Utilities.Formatters
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter() 
        {
            SupportedMediaTypes.Add(Microsoft.Net.Http.Headers.MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        protected override bool CanWriteType(Type? type)
        {
            if (typeof(UserDto).IsAssignableFrom(type) || typeof(IEnumerable<UserDto>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
          
        }

        private static void FormatCsv(StringBuilder buffer, UserDto userDto)
        {
            buffer.AppendLine($"{userDto.Id},{userDto.Name},{userDto.Surname},{userDto.City}");
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context,Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();

            if (context.Object is IEnumerable<UserDto>)
            {
                foreach(var user in (IEnumerable<UserDto>)context.Object)
                {
                    FormatCsv(buffer, user);    
                }
            }
            else{
                FormatCsv(buffer, (UserDto)context.Object);
            }
            await response.WriteAsync(buffer.ToString());

        }

    }
}
