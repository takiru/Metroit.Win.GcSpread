using System.Collections.Generic;

namespace Metroit.Win.GcSpread.Validation
{
    /// <summary>
    /// 項目の値検証情報を提供します。
    /// </summary>
    public class ValidationItem
    {
        /// <summary>
        /// 列インデックスを取得します。
        /// </summary>
        public int Column { get; } = -1;

        /// <summary>
        /// DataField 値を取得します。
        /// </summary>
        public string DataField { get; }

        /// <summary>
        /// 値検証の振る舞いを取得します。
        /// </summary>
        /// <returns></returns>
        public List<ValidationBehavior> ValidationBehaviors { get; } = new List<ValidationBehavior>();

        /// <summary>
        /// 新しい ValidationItem インスタンスを生成します。
        /// </summary>
        /// <param name="column">列インデックス。</param>
        public ValidationItem(int column)
        {
            Column = column;
        }

        /// <summary>
        /// 新しい ValidationItem インスタンスを生成します。
        /// </summary>
        /// <param name="dataField">DataField 値。</param>
        public ValidationItem(string dataField)
        {
            DataField = dataField;
        }

        /// <summary>
        /// 新しい ValidationItem インスタンスを生成します。
        /// </summary>
        /// <param name="column">列インデックス。</param>
        /// <param name="validationBehavior">値検証の振る舞い。</param>
        public ValidationItem(int column, ValidationBehavior validationBehavior)
        {
            Column = column;
            ValidationBehaviors.Add(validationBehavior);
        }

        /// <summary>
        /// 新しい ValidationItem インスタンスを生成します。
        /// </summary>
        /// <param name="dataField">DataField 値。</param>
        /// <param name="validationBehavior">値検証の振る舞い。</param>
        public ValidationItem(string dataField, ValidationBehavior validationBehavior)
        {
            DataField = dataField;
            ValidationBehaviors.Add(validationBehavior);
        }

        /// <summary>
        /// 新しい ValidationItem インスタンスを生成します。
        /// </summary>
        /// <param name="column">列インデックス。</param>
        /// <param name="validationBehaviors">値検証の振る舞い。</param>
        public ValidationItem(int column, List<ValidationBehavior> validationBehaviors)
        {
            Column = column;
            ValidationBehaviors = validationBehaviors;
        }

        /// <summary>
        /// 新しい ValidationItem インスタンスを生成します。
        /// </summary>
        /// <param name="dataField">DataField 値。</param>
        /// <param name="validationBehaviors">値検証の振る舞い。</param>
        public ValidationItem(string dataField, List<ValidationBehavior> validationBehaviors)
        {
            DataField = dataField;
            ValidationBehaviors = validationBehaviors;
        }
    }
}
