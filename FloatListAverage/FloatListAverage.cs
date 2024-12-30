using SharpDX.Direct3D11;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_2526c400_59a9_41cf_8292_c9b75999b97a
{
    public class FloatListAverage : Instance<FloatListAverage>
    {

        [Input(Guid = "00c2bfa4-1754-4eb1-a3e2-225130a2cecb")]
        public readonly InputSlot<System.Collections.Generic.List<float>> List = new InputSlot<System.Collections.Generic.List<float>>();

        [Output(Guid = "c4310c75-42b0-4bc4-8c4e-0894c9ed3ace")]
        public readonly Slot<float> Average = new Slot<float>();


    }
}

