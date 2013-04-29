using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Craus.Model.Entity;

namespace CrausTest.Model.Entity
{
    /// <summary>
    /// ShortcutSettingItemのテスト
    /// </summary>
    [TestFixture]
    class ShortcutSettingItemTest
    {
        private ShortcutSettingItem.Param param = null;

        [SetUp]
        public void setup()
        {
            this.param = new ShortcutSettingItem.Param();

            this.param.ShortcutId = 1;
            this.param.Path = "software.exe";
            this.param.Option = "test";
            this.param.GroupId = 2;
        }

        [Test]
        public void GetShortcutIdTest()
        {
            var item = new ShortcutSettingItem( this.param );
            Assert.AreEqual( param.ShortcutId, item.GetShortcutId() );
        }

        [Test]
        public void GetPathTest()
        {
            var item = new ShortcutSettingItem( this.param );
            Assert.AreEqual( param.Path, item.GetPath() );
        }

        [Test]
        public void GetOptionTest()
        {
            var item = new ShortcutSettingItem( this.param );
            Assert.AreEqual( param.Option, item.GetOption() );
        }

        [Test]
        public void GetGroupIdTest()
        {
            var item = new ShortcutSettingItem( this.param );
            Assert.AreEqual( param.GroupId, item.GetGroupId() );
        }

        [Test]
        public void ImmutableShortcutIdTest()
        {
            var item = new ShortcutSettingItem( this.param );
            this.param.ShortcutId = 5;
            Assert.AreNotEqual( param.ShortcutId, item.GetShortcutId() );
        }

        [Test]
        public void ImmutablePathTest()
        {
            var item = new ShortcutSettingItem( this.param );
            this.param.Path = "newSoftwea.exe";
            Assert.AreNotEqual( param.Path, item.GetPath() );
        }

        [Test]
        public void ImmutableOptionTest()
        {
            var item = new ShortcutSettingItem( this.param );
            this.param.Option = "new option";
            Assert.AreNotEqual( param.Option, item.GetOption() );
        }

        [Test]
        public void ImmutableGroupIdTest()
        {
            var item = new ShortcutSettingItem( this.param );
            this.param.GroupId = 5;
            Assert.AreNotEqual( param.GroupId, item.GetGroupId() );
        }

    }
}
