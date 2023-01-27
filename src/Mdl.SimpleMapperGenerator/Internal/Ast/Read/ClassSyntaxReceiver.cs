namespace Mdl.SimpleMapperGenerator.Internal.Ast.Read;

using LanguageExt;
using Mdl.SimpleMapperGenerator.Attributes;
using Mdl.SimpleMapperGenerator.Internal.Dto;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

/// <summary>
/// Read the AST
/// </summary>
internal sealed class ClassSyntaxReceiver : ISyntaxReceiver
{
    public MappingsContainer Container { get; }

    public ClassSyntaxReceiver()
    {
        Container = new MappingsContainer();
    }

    public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
    {
        if (syntaxNode is not ClassDeclarationSyntax cds)
        {
            return;
        }

        // Store the class, allow to map the target type later
        Container.Classes.Add(new Identifier(cds.Identifier.Text), cds);

        // If an attribute is found, store it
        GetAttributeTarget(cds)
            .IfSome(identifier => Container.Mappings.Add((cds, identifier)));
    }

    private static Option<Identifier> GetAttributeTarget(ClassDeclarationSyntax cds)
    {
        AttributeSyntax? attributeSyntax = cds.AttributeLists
            .SelectMany(syntax => syntax.Attributes)
            .FirstOrDefault(IsMapperAttribute);

        AttributeArgumentSyntax? attributeArgumentSyntax = attributeSyntax?.ArgumentList?.Arguments.FirstOrDefault();

        if (attributeArgumentSyntax?.Expression is not TypeOfExpressionSyntax typeOfExpressionSyntax)
        {
            return default;
        }

        if (typeOfExpressionSyntax.Type is not IdentifierNameSyntax typeSyntax)
        {
            return default;
        }

        // todo: check NS
        return new Identifier(typeSyntax.Identifier.Text);
    }

    private static bool IsMapperAttribute(AttributeSyntax attribute)
    {
        return attribute.Name.ToString() == nameof(SimpleMapperToAttribute) ||
               attribute.Name.ToString() == nameof(SimpleMapperToAttribute).Replace(nameof(Attribute), ""); // Short version
    }
}
