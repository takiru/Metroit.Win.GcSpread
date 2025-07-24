# Metroit.Win.GcSpread
GrapeCity SPREAD for Windows Forms を少し使いやすくするライブラリです。

SPREAD対象バージョン：17.2.0

[GrapeCity.Spread.WinForms.ja](https://www.nuget.org/packages/GrapeCity.Spread.WinForms.ja/17.2.0) を利用します。


継承したい場合、少なくとも下記のコンストラクタが必要になります。
```cs
public class FpSpreadEx : MetFpSpread
{
    public FpSpreadEx() : base()
    {
        
    }

    public FpSpreadEx(LegacyBehaviors legacyBehaviors) : base(legacyBehaviors)
    {
        
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public FpSpreadEx(LegacyBehaviors legacyBehaviors, object resourceData) : base(legacyBehaviors, resourceData)
    {
        
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public FpSpreadEx(LegacyBehaviors legacyBehaviors, object resourceData, bool enhancedShapeEngine) : base(legacyBehaviors, resourceData, enhancedShapeEngine)
    {
        
    }
}
```

コントロールを配置したときに、FpSpread は LegacyBehaviors.None として配置されます。  
しかし、コード上で引数を指定せずインスタンス化したとき、FpSpread は LegacyBehaviors.All として生成されます。  
コントロール配置で同様の動作を既定とさせるため、MetFpSpread の引数がないコンストラクタは LegacyBehaviors.None として動作します。  
そのため、コード上でインスタンス化し、LegacyBehaviors.All などとしたいときは下記のようにコードする必要があります。

```cs
var fpSpread = new MetFpSpread(LegacyBehaviors.All);
```
