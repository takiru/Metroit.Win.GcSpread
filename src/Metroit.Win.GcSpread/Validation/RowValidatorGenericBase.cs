using System.Windows.Forms;

namespace Metroit.Win.GcSpread.Validation
{
    /// <summary>
    /// 行の検証情報の既定動作を提供します。
    /// </summary>
    public abstract class RowValidatorBase<T> : RowValidatorBase where T : ValidationOptionBase, new()
    {
        /// <summary>
        /// 検証のオプションを取得します。
        /// </summary>
        /// <returns></returns>
        public new T Options { get; } = new T();

        /// <summary>
        /// 新しい RowValidatorBase インスタンスを生成します。
        /// </summary>
        public RowValidatorBase() : this(string.Empty) { }

        /// <summary>
        /// 新しい RowValidatorBase インスタンスを生成します。
        /// </summary>
        /// <param name="owner">呼出元コントロール。</param>
        /// <param name="messageBoxIcon">エラーメッセージのアイコン。</param>
        public RowValidatorBase(Control owner, MessageBoxIcon messageBoxIcon = MessageBoxIcon.Exclamation) : this(owner, new T(), messageBoxIcon)
        {
        }

        /// <summary>
        /// 新しい RowValidatorBase インスタンスを生成します。
        /// </summary>
        /// <param name="owner">呼出元コントロール。</param>
        /// <param name="options">検証のオプション。</param>
        /// <param name="messageBoxIcon">エラーメッセージのアイコン。</param>
        public RowValidatorBase(Control owner, T options, MessageBoxIcon messageBoxIcon = MessageBoxIcon.Exclamation) : base(owner, options, messageBoxIcon)
        {
        }

        /// <summary>
        /// 新しい RowValidatorBase インスタンスを生成します。
        /// </summary>
        /// <param name="messageTitle">エラーメッセージのタイトル。</param>
        /// <param name="messageBoxIcon">エラーメッセージのアイコン。</param>
        public RowValidatorBase(string messageTitle, MessageBoxIcon messageBoxIcon = MessageBoxIcon.Exclamation) : this(messageTitle, new T(), messageBoxIcon)
        {
        }

        /// <summary>
        /// 新しい RowValidatorBase インスタンスを生成します。
        /// </summary>
        /// <param name="messageTitle">エラーメッセージのタイトル。</param>
        /// <param name="options">検証のオプション。</param>
        /// <param name="messageBoxIcon">エラーメッセージのアイコン。</param>
        public RowValidatorBase(string messageTitle, T options, MessageBoxIcon messageBoxIcon = MessageBoxIcon.Exclamation) : base(messageTitle, options, messageBoxIcon)
        {
        }
    }
}
