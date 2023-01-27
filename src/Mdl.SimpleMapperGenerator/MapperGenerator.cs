namespace Mdl.SimpleMapperGenerator;

using System.Text;
using Mdl.SimpleMapperGenerator.Internal.Ast.Read;
using Mdl.SimpleMapperGenerator.Internal.Ast.Write;
using Mdl.SimpleMapperGenerator.Internal.Bll;
using Mdl.SimpleMapperGenerator.Internal.Dto;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

/// <summary>
/// Entry point of the source generator.
/// </summary>
[Generator]
public class MapperGenerator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context)
    {
#if DEBUG
        //Debugger.Launch();
#endif

        context.RegisterForSyntaxNotifications(() => new ClassSyntaxReceiver());
    }

    public void Execute(GeneratorExecutionContext context)
    {
        if (context.SyntaxReceiver is not ClassSyntaxReceiver receiver)
        {
            return;
        }

        Mapping[] mappings = new MappingBuilder(receiver.Container).Build();

        CompilationUnitSyntax unitSyntax = SimpleMapperGenerator.BuildFactory(mappings);

        context.AddSource("Mapper.g.cs", unitSyntax.GetText(Encoding.UTF8));
    }
}