using FarPoint.Win.Spread;
using Metroit.Win.GcSpread.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Metroit.Win.GcSpread
{
    /// <summary>
    /// FpSpread のキーマップ制御の動作を提供します。
    /// </summary>
    public class KeyMapActionManager
    {
        /// <summary>
        /// キーマップ制御を取得します。
        /// </summary>
        /// <returns></returns>
        public List<KeyMapAction> KeyMapActions { get; } = new List<KeyMapAction>();

        /// <summary>
        /// 新しい KeyMapActionManager インスタンスを生成します。
        /// </summary>
        public KeyMapActionManager()
        {

        }

        /// <summary>
        /// 指定したキーマップに対して、マップされた処理が実行可能かどうかを取得します。
        /// force = false の時、行、列、セルのいずれかがロックされている場合は実行不可となります。
        /// </summary>
        /// <param name="keyData">キーデータ。</param>
        /// <param name="cell">Cell オブジェクト。</param>
        /// <param name="ignoreLock">シートのプロテクト、セルのロックを無視するかどうか。</param>
        /// <returns>true:実行可能, false:実行不可。</returns>
        public bool CanExecute(Keys keyData, Cell cell, bool ignoreLock = false)
        {
            if (cell == null)
            {
                return false;
            }

            if (!ignoreLock && !cell.CanEditable())
            {
                return false;
            }

            foreach (var keyMapAction in KeyMapActions.Where(x => x.MapKeys.Contains(keyData)))
            {
                if (!keyMapAction.IsExecutable.Invoke(cell))
                {
                    continue;
                }
                return true;
            }

            return false;
        }

        /// <summary>
        /// 設定されたキーマップ制御を実行します。
        /// ignoreLock = false の時、行、列、セルのいずれかがロックされている場合はキーマップ制御は動作しません。
        /// </summary>
        /// <param name="keyData">キーデータ。</param>
        /// <param name="cell">Cell オブジェクト。</param>
        /// <param name="ignoreLock">シートのプロテクト、セルのロックを無視するかどうか。</param>
        public void Execute(Keys keyData, Cell cell, bool ignoreLock = false)
        {
            if (cell == null)
            {
                return;
            }

            if (!ignoreLock && !cell.CanEditable())
            {
                return;
            }

            foreach (var keyMapAction in KeyMapActions.Where((x) => x.MapKeys.Contains(keyData)))
            {
                if (!keyMapAction.IsExecutable.Invoke(cell))
                {
                    continue;
                }
                keyMapAction.Execute.Invoke(cell);
            }
        }
    }
}
