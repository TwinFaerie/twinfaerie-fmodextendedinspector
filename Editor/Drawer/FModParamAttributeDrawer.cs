using System.Collections.Generic;
using System.Linq;
using FMODUnity;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using TF.OdinExtendedInspector.Editor;

namespace TF.FModExtendedInspector.Editor
{
    public class FModParamAttributeDrawer : ItemSelectorAttributeDrawer<FModParamAttribute, string>
    {
        private IEnumerable<string> sourceData;

        protected override IEnumerable<string> GetSourceData()
        {
            if (Attribute.EventName is null) return null;

            var eventReference = ValueResolver.Get<EventReference>(Property, Attribute.EventName).GetValue();
            if (!eventReference.IsNull)
            {
                return EventManager.EventFromGUID(eventReference.Guid).LocalParameters.Select(param => param.Name);
            }
            
            var emitterReference = ValueResolver.Get<StudioEventEmitter>(Property, Attribute.EventName).GetValue();
            return emitterReference.Params.Select(param => param.Name);
        }
    }
}