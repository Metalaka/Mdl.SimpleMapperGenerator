namespace Mdl.SimpleMapperGenerator.Internal.Ast.Read;

using Microsoft.CodeAnalysis;

internal static class SyntaxNodeExtensions
{
    public static T GetParent<T>(this SyntaxNode node)
    {
        var parent = node.Parent;
        while (true)
        {
            if (parent is null)
            {
                throw new Exception();
            }

            if (parent is T t)
            {
                return t;
            }

            parent = parent.Parent;
        }
    }
}
