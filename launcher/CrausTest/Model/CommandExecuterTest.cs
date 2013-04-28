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
    }

}
