﻿using Loqui.Generation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loqui.Tests.Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            LoquiGenerator gen = new LoquiGenerator()
            {
            };
            gen.XmlTranslation.ShouldGenerateXSD = false;

            var proto = gen.AddProtocol(
                new ProtocolGeneration(
                    gen,
                    new ProtocolKey("LoquiTestsGenerated"),
                    new DirectoryInfo("../../../Loqui.Tests.Generated"))
                {
                    DefaultNamespace = "Loqui.Tests.Generated",
                });
            proto.AddProjectToModify(
                new FileInfo(Path.Combine(proto.GenerationFolder.FullName, "Loqui.Tests.Generated.csproj")));

            proto = gen.AddProtocol(
                new ProtocolGeneration(
                    gen,
                    new ProtocolKey("LoquiTests"),
                    new DirectoryInfo("../../../Loqui.Tests"))
                {
                    DefaultNamespace = "Loqui.Tests",
                });
            proto.AddProjectToModify(
                new FileInfo(Path.Combine(proto.GenerationFolder.FullName, "Loqui.Tests.csproj")));

            gen.Generate().Wait();
        }
    }
}
