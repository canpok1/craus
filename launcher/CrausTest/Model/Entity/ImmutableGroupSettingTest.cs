using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Craus.Model.Entity;

namespace CrausTest.Model.Entity
{
    // TODO [修正]GroupSettingを使わないようにしたい

    [TestFixture]
    class ImmutableGroupSettingTest
    {
        /// <summary>
        /// GroupSettingItemを生成
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private GroupSettingItem createItem( int id, String name )
        {
            var param = new GroupSettingItem.Param();
            param.GroupId = id;
            param.GroupName = name;

            return new GroupSettingItem( param );
        }

        /// <summary>
        /// GroupSettingを生成
        /// </summary>
        /// <returns></returns>
        private GroupSetting createSetting( GroupSettingItem item )
        {
            var setting = new GroupSetting();
            setting.Set( item );
            return setting;
        }

        /// <summary>
        /// GroupSettingItemが同じ値を持っているか確認
        /// </summary>
        /// <param name="immutable"></param>
        /// <param name="mutable"></param>
        /// <param name="id"></param>
        private void checkGetSameValue( ImmutableGroupSetting immutable,
                                        GroupSetting mutable,
                                        int id)
        {
            Assert.AreEqual( immutable.Get( id ).GetGroupId(), mutable.Get( id ).GetGroupId() );
            Assert.AreEqual( immutable.Get( id ).GetGroupName(), mutable.Get( id ).GetGroupName() );
        }

        [Test]
        public void GetTest()
        {
            var mutable = this.createSetting( this.createItem( 1, "test" ) );
            var immutable = new ImmutableGroupSetting( mutable );

            this.checkGetSameValue( immutable, mutable, 1 );
        }

        [Test]
        public void ToMutableTest()
        {
            var immutable = new ImmutableGroupSetting( this.createSetting( this.createItem( 1, "test" ) ) );
            var mutable = immutable.ToMutable();

            this.checkGetSameValue( immutable, mutable, 1 );
        }

        [Test]
        public void ImmutableTest()
        {
            var item1 = this.createItem( 1, "test1" );
            var item2 = this.createItem( 2, "test2" );
            var mutable = this.createSetting( item1 );
            var immutable = new ImmutableGroupSetting( mutable );

            mutable.Set( item2 );

            Assert.AreNotEqual( mutable.GetAll().Count, immutable.GetAll().Count );
        }
    }
}
