using Metroit.Win.GcSpread.Validation;

namespace Metroit.Win.GcSpread.Test
{
    /// <summary>
    /// サンプルのFpSpreadのバリデーター。
    /// </summary>
    public class SampleValidator : RowValidatorBase
    {
        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="title">メッセージタイトル。</param>
        /// <param name="messageBoxIcon">メッセージアイコン。</param>
        public SampleValidator(string title, MessageBoxIcon messageBoxIcon) : base(title, messageBoxIcon)
        {

        }

        protected override void Configuration(List<ValidationItem> validationItems)
        {
            // A列の必須チェック
            var column1Validation1 = new ValidationItem(0);
            column1Validation1.ValidationBehaviors.Add(ValidationBehavior.CreateNotNullOrEmptyBehavior("列A", null, "{0}が未入力"));
            ValidationItems.Add(column1Validation1);

            // A列の重複チェック
            var column1Validation2 = new ValidationItem(0);
            column1Validation2.ValidationBehaviors.Add(ValidationBehavior.CreateNotDuplicateBehavior(0, "列A", null, null, "重複している{0}"));
            ValidationItems.Add(column1Validation2);
        }
    }
}
