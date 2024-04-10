using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Metroit.Win.GcSpread
{
    /// <summary>
    /// カスタム検索ダイアログのベースとなる命令を提供します。
    /// </summary>
    public partial class CustomSearchDialog : Form
    {
        /// <summary>
        /// 検索ダイアログを扱う MetFpSpread を取得します。
        /// </summary>
        protected MetFpSpread FpSpread { get; private set; } = null;

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="fpSpread">MetFpSpread オブジェクト。</param>
        public CustomSearchDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 検索ダイアログを扱う MetFpSpread を設定します。
        /// </summary>
        /// <param name="fpSpread">MetFpSpread オブジェクト。</param>
        internal void SetSpread(MetFpSpread fpSpread)
        {
            if (fpSpread == null)
            {
                throw new ArgumentNullException(nameof(fpSpread));
            }
            FpSpread = fpSpread;
        }

        /// <summary>
        /// 検索ダイアログを開いた時に、呼出元で開いた検索ダイアログを認識する。
        /// </summary>
        /// <param name="e"></param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (FpSpread != null)
            {
                FpSpread.CustomSearchDialog = this;
            }
        }

        /// <summary>
        /// 検索ダイアログを閉じる前に、呼出元の制御を行う。
        /// </summary>
        /// <param name="e">キャンセルオブジェクト。</param>
        protected override void OnClosing(CancelEventArgs e)
        {
            FpSpread.PrepareCustomSearchDialogClose(this, e);
            base.OnClosing(e);

            if (!e.Cancel)
            {
                FpSpread.CustomSearchDialog = null;
            }
        }
    }
}
