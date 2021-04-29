﻿using System.IO;
using System.Linq;

namespace NeoServer.Server.Compiler
{
    public class ScriptCompiler
    {
        public static void Compile(string basePath)
        {
            var sourcesPath = Path.Combine(basePath, "scripts");

            var compiler = new Compiler();

            var bin = Directory.GetDirectories(sourcesPath, "bin", new EnumerationOptions { RecurseSubdirectories = true });
            var obj = Directory.GetDirectories(sourcesPath, "obj", new EnumerationOptions { RecurseSubdirectories = true });

            if(bin.FirstOrDefault() is string binFolder)Directory.Delete(binFolder, true);
            if (obj.FirstOrDefault() is string objFolder) Directory.Delete(objFolder, true);

            var files = Directory.GetFiles(sourcesPath, "*.cs", new EnumerationOptions
            {
                AttributesToSkip = FileAttributes.Temporary,
                IgnoreInaccessible = true,
                RecurseSubdirectories = true
            });

            var assembly = compiler.Compile(files);

            Runner.LoadAndExecute(assembly);
        }
    }
}
