using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Craus.Model.Entity;

namespace CrausTest.Model.Entity
{
    // TODO [修正]GroupSettingItemを使わないようにしたい

    [TestFixture]
    class GroupSettingTest
    {
        private GroupSettingItem createItem(int id, String name)
        {
            var param = new GroupSettingItem.Param();
            param.GroupId = id;
            param.GroupName = name;
            return new GroupSettingItem( param );
        }

        private GroupSetting setting = null;

        [SetUp]
        public void Setup()
        {
            this.setting = new GroupSetting();
        }

        [Test]
        public void GetSuccess()
        {
            int id = 3;
            String name = "test";
            var item = this.createItem( id, name );
            this.setting.Set( item );

            Assert.AreEqual( id, this.setting.Get( id ).GetGroupId() );
            Assert.AreEqual( name, this.setting.Get( id ).GetGroupName() );
        }

        [Test]
        public void GetSameItem()
        {
            int id = 2;
            var item = this.createItem( id, "test" );
            this.setting.Set( item );

            Assert.AreEqual( item, this.setting.Get( id ) );
        }

        [Test]
        public void GetAllTest()
        {
            var item1 = this.createItem( 1, "test1" );
            var item2 = this.createItem( 2, "test2" );

            this.setting.Set( item1 );
            this.setting.Set( item2 );

            Assert.AreEqual( 2, this.setting.GetAll().Count );
        }

        [Test]
        public void GetAllIsReturnCopyTest()
        {
            this.setting.Set( this.createItem( 1, "test1" ) );

            var all = this.setting.GetAll();
            all.Add( this.createItem( 2, "test2" ) );

            Assert.AreEqual( 1, this.setting.GetAll().Count );
        }

        [Test]
        public void ImmutableTest()
        {
            var item1 = this.createItem( 1, "test1" );
            var item2 = this.createItem( 2, "test2" );

            this.setting.Set( item1 );
            var copy = new GroupSetting( this.setting );

            this.setting.Set( item2 );

            Assert.AreNotEqual( copy.GetAll().Count, this.setting.GetAll().Count );
        }
    }
}
