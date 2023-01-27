namespace Mdl.SimpleMapperGenerator.Internal.Dto;

using Mdl.SimpleMapperGenerator.Attributes;
using Microsoft.CodeAnalysis.CSharp.Syntax;

internal readonly struct Mapping
{
    public Mapping(ClassDeclarationSyntax dto, ClassDeclarationSyntax entity, IReadOnlyCollection<IdentifierNameSyntax> properties)
    {
        Dto = dto;
        Entity = entity;
        Properties = properties;
    }

    /// <summary>
    /// The DTO having the <see cref="SimpleMapperToAttribute"/>.
    /// </summary>
    public ClassDeclarationSyntax Dto { get; }

    /// <summary>
    /// The target of <see cref="SimpleMapperToAttribute"/>.
    /// </summary>
    public ClassDeclarationSyntax Entity { get; }

    /// <summary>
    /// Checked properties.
    /// </summary>
    public IReadOnlyCollection<IdentifierNameSyntax> Properties { get; }
}
