using com.sun.xml.@internal.bind.v2.runtime.unmarshaller;
using java.io;
using java.lang;
using java.net;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions;
using Moq;
using NUnit.Framework;
using Org.Mapeditor.Core;
using Org.Mapeditor.Io;
using System;
using System.Drawing;
using File = java.io.File;
using Thread = java.lang.Thread;

namespace Org.Mapeditor.Io
{
    [TestFixture]
    public class MapReaderTests
    { 
        [SetUp]
        public void SetUp()
        { 
        }
 
        [Test]
        public void TestAcceptValidFilenames()
        {
            // Arrange
            TMXMapReader reader = new TMXMapReader();

            // Assert
            Assert.True(reader.Accept(new File("example.tmx")));
            Assert.True(reader.Accept(new File("/tmp/example.tmx")));
            Assert.True(reader.Accept(new File("/tmp/example.tsx")));
            Assert.True(reader.Accept(new File("/tmp/example.tmx.gz")));
            Assert.False(reader.Accept(new File("/tmp/example.txt")));
            Assert.False(reader.Accept(new File("/tmp/example.xml")));
            Assert.False(reader.Accept(new File("/tmp/example.exe")));
            Assert.False(reader.Accept(new File("/tmp/example")));
        }

        [Test]
        public void TestReadmapWithSearchDirectory()
        {


            string resourceName = "resources/relative_paths/relative_paths.tmx";
            //URL _url = new URL($"file:///{typeof(MapReaderTests).Assembly.GetAssemblyLocation()}\\{resourceName}")

            ClassLoader loader = Thread.currentThread().getContextClassLoader();
            URL url = loader.getResource(resourceName);
            string parentDirectory = new File(url.getFile()).getParent();
            InputStream @in = loader.getResourceAsStream(resourceName);

            Map map = new TMXMapReader().ReadMap(@in, parentDirectory);
            Assert.IsTrue(1 == map.GetTileSets().Count);
        }
    }
}
