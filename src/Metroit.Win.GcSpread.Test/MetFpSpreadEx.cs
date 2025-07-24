using FarPoint.Win.Spread;
using System.ComponentModel;

namespace Metroit.Win.GcSpread.Test
{
    public class MetFpSpreadEx : MetFpSpread
    {
        public MetFpSpreadEx() : base()
        {

        }

        public MetFpSpreadEx(LegacyBehaviors legacyBehaviors) : base(legacyBehaviors)
        {

        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public MetFpSpreadEx(LegacyBehaviors legacyBehaviors, object resourceData) : base(legacyBehaviors, resourceData)
        {

        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public MetFpSpreadEx(LegacyBehaviors legacyBehaviors, object resourceData, bool enhancedShapeEngine) : base(legacyBehaviors, resourceData, enhancedShapeEngine)
        {

        }
    }
}
