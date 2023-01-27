using Mdl.SimpleMapperGenerator.Attributes;

[SimpleMapperTo(typeof(Foo))]
public class FooDto
{
    public int Id { get; set; }
    public int Data { get; set; }
    public string Data2 { get; set; }
}
