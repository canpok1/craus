using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Craus.Model.Entity;

namespace CrausTest.Model.Entity
{
    // TODO [修正] Shortcutsettingを使わないようにしたい

    [TestFixture]
    class ImmutableShortcutSettingTest
    {
        private ShortcutSettingItem createItem( int shortcutId, int groupId )
        {
            var param = new ShortcutSettingItem.Param();
            param.ShortcutId = shortcutId;
            param.Path = "path";
            param.Option = "option";
            param.GroupId = groupId;
            return new ShortcutSettingItem( param );
        }

        private ShortcutSetting createSetting( ShortcutSettingItem item )
        {
            var setting = new ShortcutSetting();
            setting.Set( item );
            return setting;
        }

        /// <summary>
        /// ShortcutSettingItemが同じ値を持っているか確認
        /// </summary>
        /// <param name="immutable"></param>
        /// <param name="mutable"></param>
        /// <param name="id"></param>
        private void checkGetSameValue( ImmutableShortcutSetting immutable,
                                        ShortcutSetting mutable,
                                        int shortcutId )
        {
            var mutableItem = mutable.GetByShortcutId( shortcutId );
            var immutableItem = immutable.GetByShortcutId( shortcutId );
            Assert.IsTrue( immutableItem.Equals( mutableItem ) );
        }

        [Test]
        public void 生成元の可変インスタンスと同じ値を持つこと()
        {
            var mutable = this.createSetting( this.createItem( 1, 2 ) );
            var immutable = new ImmutableShortcutSetting( mutable );

            this.checkGetSameValue( immutable, mutable, 1 );
        }

        [Test]
        public void 生成した可変インスタンスと同じ値を持つこと()
        {
            var immutable = new ImmutableShortcutSetting( this.createSetting( this.createItem( 1, 2 ) ) );
            var mutable = immutable.ToMutable();

            this.checkGetSameValue( immutable, mutable, 1 );
        }

        [Test]
        public void 生成元の可変インスタンスに加えた変更が影響ないこと()
        {
            var mutable = this.createSetting( this.createItem( 1, 2 ) );
            var immutable = new ImmutableShortcutSetting( mutable );

            mutable.Set( this.createItem( 2, 3 ) );

            Assert.AreNotEqual( mutable.GetAll().Count, immutable.GetAll().Count );
        }

        [Test]
        public void 生成した可変インスタンスに加えた変更が影響ないこと()
        {
            var immutable = new ImmutableShortcutSetting( this.createSetting( this.createItem( 1, 2 ) ) );
            var mutable = immutable.ToMutable();

            mutable.Set( this.createItem( 2, 3 ) );

            Assert.AreNotEqual( mutable.GetAll().Count, immutable.GetAll().Count );
        }
        // TODO [実装]
    }
}
