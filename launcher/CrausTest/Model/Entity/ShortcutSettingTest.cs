using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Craus.Model.Entity;

namespace CrausTest.Model.Entity
{
    // TODO [修正]ShortcutSettingItemを使わないようにしたい

    [TestFixture]
    class ShortcutSettingTest
    {
        /// <summary>
        /// パラメータを指定してShortcutSettingItemを生成
        /// </summary>
        /// <param name="shortcutId"></param>
        /// <param name="path"></param>
        /// <param name="option"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        private ShortcutSettingItem createItem( int shortcutId, String path, String option, int groupId )
        {
            var param = new ShortcutSettingItem.Param();
            param.ShortcutId = shortcutId;
            param.Path = path;
            param.Option = option;
            param.GroupId = groupId;
            return new ShortcutSettingItem( param );
        }

        /// <summary>
        /// デフォルト値を保持するShortcutSettingItemを生成
        /// </summary>
        /// <returns>ShortcutSettingItem</returns>
        private ShortcutSettingItem createDefaultItem()
        {
            return this.createItem( 1, "path", "option", 4 );
        }

        private ShortcutSetting setting = null;

        [SetUp]
        public void Setup()
        {
            this.setting = new ShortcutSetting();
        }

        [Test]
        public void GetByShortcutIdで同じパラメータのものが取得できる()
        {
            var item = this.createItem( 1, "path", "option", 4 );
            this.setting.Set( item );

            Assert.IsTrue( this.setting.GetByShortcutId( 1 ).Equals( item ) );
        }

        [Test]
        public void GetByGroupIdで同じグループのものが取得できる()
        {
            var item1 = this.createItem( 1, "path", "option", 10 );
            var item2 = this.createItem( 2, "path", "option", 10 );
            var item3 = this.createItem( 3, "path", "option", 20 );

            this.setting.Set( item1 );
            this.setting.Set( item2 );
            this.setting.Set( item3 );

            Assert.AreEqual( 2, this.setting.GetByGroupId( 10 ).Count );
            Assert.AreEqual( 1, this.setting.GetByGroupId( 20 ).Count );

            Assert.IsTrue( this.setting.GetByGroupId( 20 )[0].Equals( item3 ) );
        }

        [Test]
        public void GetByGroupIdの戻り値に要素を追加しても影響ない()
        {
            this.setting.Set( this.createItem( 1, "path", "option", 10 ) );
            this.setting.GetByGroupId( 10 ).Add( this.createItem( 2, "path", "option", 10 ) );
            Assert.AreEqual( 1, this.setting.GetByGroupId( 10 ).Count );
        }

        [Test]
        public void 追加した数分がGetAllで取得できる()
        {
            this.setting.Set( this.createItem( 1, "path", "option", 10 ) );
            this.setting.Set( this.createItem( 2, "path", "option", 20 ) );

            Assert.AreEqual( 2, this.setting.GetAll().Count );
        }

        [Test]
        public void GetAllの戻り値に要素を追加しても影響ない()
        {
            this.setting.Set( this.createItem( 1, "path", "option", 10 ) );
            this.setting.GetAll().Add( this.createItem( 2, "path", "option", 20 ) );

            Assert.AreEqual( 1, this.setting.GetAll().Count );
        }


        [Test]
        public void コピーコンストラクタで作ったのが同じ値を持つ()
        {
            this.setting.Set( this.createItem( 1, "path", "option", 10 ) );
            var copy = new ShortcutSetting( this.setting );

            Assert.IsTrue( this.setting.GetByShortcutId( 1 ).Equals( copy.GetByShortcutId( 1 ) ) );
        }

        [Test]
        public void コピーにSetしてもオリジナルに影響しない()
        {
            this.setting.Set( this.createItem( 1, "path", "option", 10 ) );
            var copy = new ShortcutSetting( this.setting );
            copy.Set( this.createItem( 2, "path", "option", 20 ) );

            Assert.AreNotEqual( this.setting.GetAll().Count, copy.GetAll().Count );
        }
    }
}
