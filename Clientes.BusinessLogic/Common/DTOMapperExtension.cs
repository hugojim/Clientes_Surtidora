using System.Text.Json;

namespace Clientes.BusinessLogic.Common
{
    public static class DTOMapperExtension
    {
        public static T MapTo<T>(this object value)
        {
            return JsonSerializer.Deserialize<T>(
                JsonSerializer.Serialize(value)
                );
        }
    }
}
