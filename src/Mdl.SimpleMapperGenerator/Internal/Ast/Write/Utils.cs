namespace Mdl.SimpleMapperGenerator.Internal.Ast.Write;

using System.Reflection;
using CommunityToolkit.Diagnostics;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

internal static class Utils
{
    internal static NameSyntax BuildQualifiedName(params string[] nameSpaceParts)
    {
        Guard.IsNotNull(nameSpaceParts);
        Guard.IsNotEmpty(nameSpaceParts);

        NameSyntax? nameSyntax = default;

        foreach (string part in nameSpaceParts)
        {
            if (nameSyntax is null)
            {
                nameSyntax = IdentifierName(part);
                continue;
            }

            nameSyntax = QualifiedName(nameSyntax, IdentifierName(part));
        }

        return nameSyntax!;
    }

    internal static string GetAssemblyNamespace()
    {
        return Assembly.GetExecutingAssembly().GetName().Name ?? "";
    }
}
