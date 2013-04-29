using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Craus.Model.Entity;

namespace CrausTest.Model.Entity
{
    /// <summary>
    /// GroupSettingItemのテスト
    /// </summary>
    [TestFixture]
    class GroupSettingItemTest
    {
        private GroupSettingItem.Param param = null;

        [SetUp]
        public void setup()
        {
            this.param = new GroupSettingItem.Param();

            this.param.GroupId = 1;
            this.param.GroupName = "test";
        }

        [Test]
        public void GetGroupNameTest()
        {
            var item = new GroupSettingItem( this.param );
            Assert.AreEqual( param.GroupName, item.GetGroupName() );
        }

        [Test]
        public void GetGroupIdTest()
        {
            var item = new GroupSettingItem( this.param );
            Assert.AreEqual( param.GroupId, item.GetGroupId() );
        }

        [Test]
        public void ImmutableGroupNameTest()
        {
            var item = new GroupSettingItem( this.param );
            this.param.GroupName = "new test";
            Assert.AreNotEqual( param.GroupName, item.GetGroupName() );
        }

        [Test]
        public void ImmutableGroupIdTest()
        {
            var item = new GroupSettingItem( this.param );
            this.param.GroupId = 5;
            Assert.AreNotEqual( param.GroupId, item.GetGroupId() );
        }
    }
}
