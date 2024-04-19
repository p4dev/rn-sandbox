using System.Xml.Serialization;

public class XmlResult : IResult
{
    private readonly string _source;

    public XmlResult(string source)
    {
        _source = source;
    }

    public static Stream GenerateStreamFromString(string s)
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(s);
        writer.Flush();
        stream.Position = 0;
        return stream;
    }

    public async Task ExecuteAsync(HttpContext httpContext)
    {
        httpContext.Response.ContentType = "application/xml";
        using (var stream = GenerateStreamFromString(_source))
        {
            await stream.CopyToAsync(httpContext.Response.Body);
        }
    }
}