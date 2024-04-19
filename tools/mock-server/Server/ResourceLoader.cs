using System;
namespace Server
{
	static class ResourceLoader
	{
        public static string GetResourceTextFile(string filename)
        {
            string result = string.Empty;
            var assembly = typeof(ResourceLoader).Assembly;
            using (var stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.Resources.{filename}"))
            {
                using (var sr = new StreamReader(stream))
                {
                    result = sr.ReadToEnd();
                }
            }
            return result;
        }
    }
}

