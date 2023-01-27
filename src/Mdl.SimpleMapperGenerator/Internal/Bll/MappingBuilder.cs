namespace Mdl.SimpleMapperGenerator.Internal.Bll;

using Mdl.SimpleMapperGenerator.Internal.Dto;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

internal sealed class MappingBuilder
{
    private readonly MappingsContainer _container;

    public MappingBuilder(MappingsContainer container)
    {
        _container = container;
    }

    internal Mapping[] Build()
    {
        return _container.Mappings
            .Select(tuple => CreateMapping(tuple.Dto, tuple.Target))
            .ToArray();
    }

    private Mapping CreateMapping(ClassDeclarationSyntax dto, Identifier entityIdentifier)
    {
        ClassDeclarationSyntax cds = GetClassDeclarationSyntax(entityIdentifier);

        return new Mapping(dto, cds, BuildProperties(cds, dto));
    }

    private ClassDeclarationSyntax GetClassDeclarationSyntax(Identifier entityIdentifier)
    {
        if (!_container.Classes.TryGetValue(entityIdentifier, out ClassDeclarationSyntax? cds))
        {
            throw new Exception($"Target type is not found: {entityIdentifier.Name}");
        }

        return cds;
    }

    private static IdentifierNameSyntax[] BuildProperties(ClassDeclarationSyntax from, ClassDeclarationSyntax to)
    {
        string[] fromProperties = GetProperties(from);
        string[] toProperties = GetProperties(to);

        // todo: check type matching
        return toProperties.Where(s => fromProperties.Contains(s))
            .Select(IdentifierName)
            .ToArray();
    }

    private static string[] GetProperties(ClassDeclarationSyntax from)
    {
        return from.Members
            .OfType<PropertyDeclarationSyntax>()
            .Select(x => x.Identifier.Text)
            .ToArray();
    }
}
