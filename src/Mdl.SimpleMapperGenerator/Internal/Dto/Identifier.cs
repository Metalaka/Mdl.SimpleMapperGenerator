namespace Mdl.SimpleMapperGenerator.Internal.Dto;

internal readonly struct Identifier
{
    public Identifier(string name)
    {
        Name = name;
    }

    public string Name { get; }
    // todo: NS
}
