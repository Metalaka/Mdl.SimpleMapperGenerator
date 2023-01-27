namespace Mdl.SimpleMapperGenerator.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public sealed class SimpleMapperToAttribute : Attribute
{
    // act for a 2 way mapper
    public SimpleMapperToAttribute(Type t)
    {
    }
}