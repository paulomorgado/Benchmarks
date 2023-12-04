using BenchmarkDotNet.Running;

if (args is null || args.Length == 0)
{
    args = new[] { "--filter", "*" };
}

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

//ObjectLayoutInspector.TypeLayout.PrintLayout<Duende.AccessTokenManagement.ClientCredentialsTokenHandler>();
