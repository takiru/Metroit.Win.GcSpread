using FarPoint.Win.Spread;
using System;
using System.Windows.Forms;

namespace Metroit.Win.GcSpread
{
    /// <summary>
    /// MetroitFpSpread のキーマップ制御を提供します。
    /// </summary>
    public class KeyMapAction
    {
        /// <summary>
        /// マップするキーを取得します。
        /// </summary>
        /// <returns></returns>
        public Keys[] MapKeys { get; } = { };

        /// <summary>
        /// マップされた処理を取得します。
        /// </summary>
        /// <returns></returns>
        public Action<Cell> Execute { get; } = (x) => { };

        /// <summary>
        /// マップされた処理実行可否を取得します。
        /// </summary>
        /// <returns></returns>
        public Func<Cell, bool> IsExecutable { get; } = (x) => true;

        /// <summary>
        /// 新しい KeyMapAction インスタンスを生成します。
        /// </summary>
        /// <param name="mapKeys">マップするキー。</param>
        /// <param name="execute">マップする処理。</param>
        /// <param name="isExecutable">マップする処理実行可否。</param>
        public KeyMapAction(Keys[] mapKeys, Action<Cell> execute, Func<Cell, bool> isExecutable = null)
        {
            if (mapKeys != null)
            {
                MapKeys = mapKeys;
            }
            if (execute != null)
            {
                Execute = execute;
            }
            if (isExecutable != null)
            {
                IsExecutable = isExecutable;
            }
        }
    }
}
