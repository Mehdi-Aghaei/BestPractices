using System.Collections.Generic;
using System.Collections.Immutable;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SourceGenerators
{
	[Generator]
	public class ClassNameFinderGenerator : IIncrementalGenerator
	{

		public void Initialize(IncrementalGeneratorInitializationContext context)
		{
			var provider = context.SyntaxProvider.CreateSyntaxProvider(
				predicate: static (node, _) => node is ClassDeclarationSyntax,
				transform: static (ctx, _) => (ClassDeclarationSyntax)ctx.Node).Where(n => n is not null);

			var compilation = context.CompilationProvider.Combine(provider.Collect());

			context.RegisterSourceOutput(compilation, Execute);
		}

		private static void Execute(SourceProductionContext context, (Compilation Left, ImmutableArray<ClassDeclarationSyntax> Right) tuple)
		{
			var (compilations, list) = tuple;
			var nameList = new List<string>();
			foreach (var syntax in list)
			{
				var symbol = compilations.GetSemanticModel(syntax.SyntaxTree)
					.GetDeclaredSymbol(syntax) as INamedTypeSymbol;

				nameList.Add($"\"{symbol.ToDisplayString()}\"");
			}
			var names = string.Join(",\n ", nameList);

			var theCode = $$"""
				namespace ClassListGenerator;

				public static class ClassNames
				{
					public static List<string> Names = new() {{{names}}};
				}
				""";
			context.AddSource("ClassList.g.cs", theCode);
		}
	}
}
