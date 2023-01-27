namespace Mdl.SimpleMapperGenerator.Internal.Dto;

using Mdl.SimpleMapperGenerator.Attributes;
using Microsoft.CodeAnalysis.CSharp.Syntax;

internal readonly struct MappingsContainer
{
    /// <summary>
    /// Mappings configured by <see cref="SimpleMapperToAttribute"/>.
    /// </summary>
    public IList<(ClassDeclarationSyntax Dto, Identifier Target)> Mappings { get; }

    /// <summary>
    /// All classes visible by the generator.
    /// </summary>
    public IDictionary<Identifier, ClassDeclarationSyntax> Classes { get; }

    public MappingsContainer()
    {
        Mappings = new List<(ClassDeclarationSyntax Dto, Identifier Target)>();
        Classes = new Dictionary<Identifier, ClassDeclarationSyntax>();
    }
}
