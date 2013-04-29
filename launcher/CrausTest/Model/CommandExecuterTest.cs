using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Craus.Model;

namespace CrausTest.Model
{
    [TestFixture]
    class CommandExecuterTest
    {
        private CommandExecuter executer = null;

        [SetUp]
        public void setup()
        {
            this.executer = new CommandExecuter();
        }

        [Test]
        [ExpectedException( typeof( ArgumentNullException ) )]
        public void ExecuteNullPath()
        {
            this.executer.Execute( null, "" );
        }

        [Test]
        [ExpectedException( typeof( ArgumentException ) )]
        public void ExecuteEmptyPath()
        {
            this.executer.Execute( "", "" );
        }

        [Test]
        public void BuildCommand()
        {
            String arg1 = "aaaa.exe";
            String arg2 = "-f";
            String arg3 = @"c:\ファイル";

            Assert.AreEqual( arg1 + " " + arg2 + " " + arg3,
                             CommandExecuter.BuildCommand( arg1, arg2, arg3 ) );
        }
    }

}
