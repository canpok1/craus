using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Craus.Model.Entity;

namespace CrausTest.Model.Entity
{
    // TODO [修正] LauncherSettingを使わないようにしたい

    [TestFixture]
    class ImmutableLauncherSettingTest
    {
        // TODO [実装]

        private LauncherSetting createSetting()
        {
            var setting = new LauncherSetting();
            setting.Set( LauncherSetting.Key.WINDOW_HEIGHT, 100 );
            setting.Set( LauncherSetting.Key.WINDOW_WIDTH, 200 );
            return setting;
        }

        /// <summary>
        /// GetStringで同じ値が取得できるかをチェックします。
        /// </summary>
        /// <param name="immutable"></param>
        /// <param name="mutable"></param>
        /// <param name="key"></param>
        private void checkGetStringSameValue( ImmutableLauncherSetting immutable,
                                              LauncherSetting mutable,
                                              LauncherSetting.Key key )
        {
            Assert.AreEqual( immutable.GetString( key ),
                             mutable.GetString( key ) );
        }

        /// <summary>
        /// GetIntで同じ値が取得できるかをチェックします。
        /// </summary>
        /// <param name="immutable"></param>
        /// <param name="mutable"></param>
        /// <param name="key"></param>
        private void checkGetIntSameValue( ImmutableLauncherSetting immutable,
                                           LauncherSetting mutable,
                                           LauncherSetting.Key key )
        {
            Assert.AreEqual( immutable.GetInt( key ),
                             mutable.GetInt( key ) );
        }

        [Test]
        public void GetStringTest()
        {
            var mutable = this.createSetting();
            var immutable = new ImmutableLauncherSetting( mutable );

            this.checkGetStringSameValue( immutable, mutable, LauncherSetting.Key.WINDOW_HEIGHT );
            this.checkGetStringSameValue( immutable, mutable, LauncherSetting.Key.WINDOW_WIDTH );
        }

        [Test]
        public void GetIntTest()
        {
            var mutable = this.createSetting();
            var immutable = new ImmutableLauncherSetting( mutable );

            this.checkGetIntSameValue( immutable, mutable, LauncherSetting.Key.WINDOW_HEIGHT );
            this.checkGetIntSameValue( immutable, mutable, LauncherSetting.Key.WINDOW_WIDTH );
        }

        [Test]
        public void ToMutableTest()
        {
            var immutable = new ImmutableLauncherSetting( this.createSetting() );
            var mutable = immutable.ToMutable();

            this.checkGetStringSameValue( immutable, mutable, LauncherSetting.Key.WINDOW_HEIGHT );
            this.checkGetStringSameValue( immutable, mutable, LauncherSetting.Key.WINDOW_WIDTH );
            this.checkGetIntSameValue( immutable, mutable, LauncherSetting.Key.WINDOW_HEIGHT );
            this.checkGetIntSameValue( immutable, mutable, LauncherSetting.Key.WINDOW_WIDTH );
        }

        [Test]
        public void ImmutableTest()
        {
            var mutable = this.createSetting();
            var immutable = new ImmutableLauncherSetting( mutable);

            var key = LauncherSetting.Key.WINDOW_WIDTH;
            int newWidth = mutable.GetInt( key ) + 4;
            mutable.Set( key, newWidth );

            Assert.AreNotEqual( mutable.GetInt( key ), immutable.GetInt( key ) );
        }
    }

}
