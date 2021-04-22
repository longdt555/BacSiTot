using System;

namespace BacSiTot.Helpers
{
    public static class AppHelpers
    {
        public static Guid ConvertStringToGuid(string input)
        {
            return Guid.TryParse(input, out var outGuid) ? outGuid : Guid.Empty;
        }
    }
}
