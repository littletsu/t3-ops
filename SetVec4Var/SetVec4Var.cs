using SharpDX.Direct3D11;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_0314b07c_a978_4dea_b262_355346c852c1
{
    public class SetVec4Var : Instance<SetVec4Var>
    {

        [Input(Guid = "a5d8b5f6-d36b-4ea5-ba97-098edcfe37f9")]
        public readonly InputSlot<T3.Core.DataTypes.Command> Command = new InputSlot<T3.Core.DataTypes.Command>();

        [Input(Guid = "9f6fea4d-acc0-4a0c-b3a4-96da46f34cfa")]
        public readonly InputSlot<string> VariableName = new InputSlot<string>();

        [Input(Guid = "f0ca93f6-c480-40f4-93be-4414ec368156")]
        public readonly InputSlot<bool> ClearAfterExecution = new InputSlot<bool>();

        [Input(Guid = "1772faef-4dd4-4528-ae30-7aca2e6e39db")]
        public readonly InputSlot<System.Numerics.Vector4> Vec4Value = new InputSlot<System.Numerics.Vector4>();

        [Output(Guid = "f62a4960-c905-4982-b037-93520ba70233")]
        public readonly Slot<T3.Core.DataTypes.Command> Output = new Slot<T3.Core.DataTypes.Command>();


    }
}

