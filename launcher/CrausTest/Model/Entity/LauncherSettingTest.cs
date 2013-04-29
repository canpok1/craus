using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Craus.Model.Entity;

namespace CrausTest.Model.Entity
{
    [TestFixture]
    class LauncherSettingTest
    {
        private LauncherSetting setting = null;

        [SetUp]
        public void setup()
        {
            this.setting = new LauncherSetting();
        }

        [Test]
        public void GetStringSuccess()
        {
            var value = "test";
            var key = LauncherSetting.Key.WINDOW_HEIGHT;
            this.setting.Set( key, value );
            Assert.AreEqual( value, this.setting.GetString( key ) );
        }

        [Test]
        public void GetIntSuccess()
        {
            var value = 1;
            var key = LauncherSetting.Key.WINDOW_HEIGHT;
            this.setting.Set( key, value );
            Assert.AreEqual( value, this.setting.GetInt( key ) );
        }

        [Test]
        [ExpectedException( typeof( KeyNotFoundException ) )]
        public void GetStringFail()
        {
            var key = LauncherSetting.Key.WINDOW_HEIGHT;
            this.setting.GetString( key );
        }

        [Test]
        [ExpectedException( typeof( KeyNotFoundException ) )]
        public void GetIntFail()
        {
            var key = LauncherSetting.Key.WINDOW_HEIGHT;
            this.setting.GetInt( key );
        }

        [Test]
        [ExpectedException( typeof( FormatException ) )]
        public void GetIntFormatFail()
        {
            var value = "abc";
            var key = LauncherSetting.Key.WINDOW_HEIGHT;
            this.setting.Set( key, value );
            this.setting.GetInt( key );
        }

    }
}
