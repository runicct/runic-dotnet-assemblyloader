# Introduction
Runic.Dotnet.AssemblyLoader is a tiny helper that combine Runic.FileFormat.PortableExecutable and Runic.Dotnet.Assembly.
This helper allows the user to quickly load inspect and manipulate dotnet assemblies

# Sample

The following code shows a tiny usage sample:

``` csharp
using (System.IO.BinaryReader reader = new System.IO.BinaryReader(System.IO.File.OpenRead("./your_assembly")))
{
    // Load the assembly using Runic.Dotnet.AssemblyLoader
    var assembly = Runic.Dotnet.AssemblyLoader.Load(reader);
    Console.WriteLine($"Loaded assembly: {assembly.ReadString(assembly.AssemblyTable[1].Name)}");

    // Read all the types defined in the Assembly (They are listed in TypeDefTable)
    for (uint n = 1; n <= assembly.TypeDefTable.Rows; n++)
    {
        var typeName = assembly.ReadString(assembly.TypeDefTable[n].Name);
        Console.WriteLine($"Type {n}: {typeName}");

        // The method list in the type is simply an index into the MethodDefTable.
        uint startMethod = assembly.TypeDefTable[n].MethodList.Row;
        uint endMethod = assembly.TypeDefTable[n].MethodListEnd != null ? assembly.TypeDefTable[n].MethodListEnd.Row : (assembly.MethodDefTable.Rows);
        for (uint m = startMethod; m < endMethod; m++)
        {
            var methodName = assembly.ReadString(assembly.MethodDefTable[m].Name);
            Console.WriteLine($"  Method {m}: {methodName}");
            // If available dump the bytecode
            if (assembly.MethodDefTable[m].MethodBodyRelativeVirtualAddress > 0)
            {
                var methodHeader = assembly.ReadMethodHeader(assembly.MethodDefTable[m]);
                Runic.Dotnet.Assembly.MethodHeader.Decode(methodHeader,
                                                          out var bytecodeLength,
                                                          out var maxStack,
                                                          out var localVarSigToken,
                                                          out bool moreSection,
                                                          out bool initLocals);
                var bytecode = assembly.ReadByteArray(assembly.MethodDefTable[m].MethodBodyRelativeVirtualAddress + (uint)methodHeader.Length, (uint)bytecodeLength);
                Console.WriteLine("    Bytecode:");
                Console.Write("      ");
                for (int x = 0; x < bytecode.Length; x++)
                {
                    Console.Write($"{bytecode[x]:X2} ");
                }
                Console.WriteLine();
            }
        }
    }
}
```
