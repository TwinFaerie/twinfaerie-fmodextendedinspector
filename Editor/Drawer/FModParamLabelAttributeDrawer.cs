using System.Collections.Generic;
using FMODUnity;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using TF.OdinExtendedInspector.Editor;

namespace TF.FModExtendedInspector.Editor
{
    public class FModParamLabelAttributeDrawer : ItemSelectorAttributeDrawer<FModParamLabelAttribute, string>
    {
        private IEnumerable<string> sourceData;

        protected override IEnumerable<string> GetSourceData()
        {
            if (Attribute.EventName is null) return null;
            if (Attribute.ParamName is null) return null;
            
            var paramName = ValueResolver.Get<string>(Property, Attribute.ParamName);
            if (paramName is null) return null;

            var eventReference = ValueResolver.Get<EventReference>(Property, Attribute.EventName).GetValue();
            if (!eventReference.IsNull)
            {
                var paramReference = EventManager.EventFromGUID(eventReference.Guid).LocalParameters
                    .Find(param => param.Name == paramName.GetValue() && param.Type is ParameterType.Labeled);
                return paramReference?.Labels;
            }
            
            var emitterReference = ValueResolver.Get<StudioEventEmitter>(Property, Attribute.EventName).GetValue();
            if (emitterReference is not null)
            {
                var paramReference = EventManager.EventFromGUID(emitterReference.EventReference.Guid).LocalParameters
                    .Find(param => param.Name == paramName.GetValue() && param.Type is ParameterType.Labeled);
                return paramReference?.Labels;
            }

            return null;
        }
    }
}