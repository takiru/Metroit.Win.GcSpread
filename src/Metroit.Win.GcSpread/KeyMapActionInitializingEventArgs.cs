using System;

namespace Metroit.Win.GcSpread
{
    /// <summary>
    /// KeyMapActionInitializing イベントが発生した時のイベント引数を提供します。
    /// </summary>
    public class KeyMapActionInitializingEventArgs : EventArgs
    {
        /// <summary>
        /// キーマップ制御マネージャーを取得します。
        /// </summary>
        public KeyMapActionManager Manager { get; }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="manager">キーマップ制御マネージャー。</param>
        public KeyMapActionInitializingEventArgs(KeyMapActionManager manager) : base()
        {
            Manager = manager;
        }
    }
}
