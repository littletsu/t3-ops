using SharpDX.Direct3D11;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_61c1fe59_6b3d_416e_b50c_6a35642e7bcc
{
    public class GetVec4Var : Instance<GetVec4Var>
    {

        [Input(Guid = "504dcf7d-e321-417c-9e9a-d5094fab721a")]
        public readonly InputSlot<string> VariableName = new InputSlot<string>();

        [Input(Guid = "4e06ac21-d3d6-4177-905e-683a8c386d87")]
        public readonly InputSlot<System.Numerics.Vector4> FallbackDefault = new InputSlot<System.Numerics.Vector4>();

        [Output(Guid = "112eac4e-1733-4fbe-a14d-1c53621031ba")]
        public readonly Slot<System.Numerics.Vector4> Output = new Slot<System.Numerics.Vector4>();


    }
}

