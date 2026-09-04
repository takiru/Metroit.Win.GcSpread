using FarPoint.Win.Spread;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Metroit.Win.GcSpread
{
    /// <summary>
    /// <see cref="SheetView"/> の列インデックスを、行データ型 <typeparamref name="TRow"/> の定義名から検索できるようにキャッシュするクラスを表します。
    /// </summary>
    /// <typeparam name="TRow">インデックスを求めるための定義が含まれる型。</typeparam>
    public class ColumnIndexCache<TRow>
    {
        /// <summary>
        /// 列インデックスを定義名とペアで保持するキャッシュを表します。
        /// </summary>
        private readonly Dictionary<string, int> _indicesByName;

        /// <summary>
        /// <see cref="ColumnIndexCache{TRow}"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="indicesByName">列インデックスを定義名とペアで保持しているディクショナリ。</param>
        internal ColumnIndexCache(Dictionary<string, int> indicesByName)
        {
            _indicesByName = indicesByName;
        }

        /// <summary>
        /// 指定されたプロパティに対応する定義名のインデックスを取得します。
        /// </summary>
        /// <typeparam name="TProp">取得するプロパティの型。</typeparam>
        /// <param name="propertyExpression">
        /// インデックスを取得したいプロパティを指定する式。<br/>
        /// 例: <c>x => x.CustomerName</c></param>
        /// <returns>
        /// 対応する定義名を持つ列が存在する場合はその列インデックスを返却します。存在しない場合は -1 を返却します。
        /// </returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="propertyExpression"/> がプロパティメンバーを指す式ではない場合にスローされます。
        /// </exception>
        public int GetIndex<TProp>(Expression<Func<TRow, TProp>> propertyExpression)
        {
            if (!(propertyExpression.Body is MemberExpression member))
            {
                throw new ArgumentException("プロパティを指定する式を渡してください。", nameof(propertyExpression));
            }

            if (_indicesByName.TryGetValue(member.Member.Name, out var index))
            {
                return index;
            }

            return -1;
        }

        /// <summary>
        /// 指定された定義名に対応する列のインデックスを取得します。
        /// </summary>
        /// <param name="name">インデックスを取得したい定義名。</param>
        /// <returns>
        /// 対応する定義名を持つ列が存在する場合はその列インデックスを返却します。存在しない場合は -1 を返却します。
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="name"/> が <see langword="null"/> の場合にスローされます。
        /// </exception>
        public int GetIndex(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (_indicesByName.TryGetValue(name, out var index))
            {
                return index;
            }

            return -1;
        }
    }
}
