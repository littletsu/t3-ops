using System;
using System.Collections.Generic;
using T3.Core.Logging;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;
using T3.Core.Utils;

namespace T3.Operators.Types.Id_2d1a25d6_e851_47b9_b677_6bd2755273ac
{
    public class KeepFloatValuesMinMax : Instance<KeepFloatValuesMinMax>
    {
        private const float DefaultMin = float.MaxValue;
        private const float DefaultMax = float.MinValue;
        [Output(Guid = "c328b1d9-f801-4bc0-8636-c0ccde5783db")]
        public readonly Slot<List<float>> Result = new(new List<float>(20));

        [Output(Guid = "77e68697-57cb-498f-b1be-a97edd850ad0")]
        public readonly Slot<float> Min = new Slot<float>();

        [Output(Guid = "a9d97797-701b-4292-b723-198e2f373387")]
        public readonly Slot<float> Max = new Slot<float>();

        public KeepFloatValuesMinMax()
        {
            Result.UpdateAction = Update;
            Min.UpdateAction = Update;
            Max.UpdateAction = Update;
        }

        private void _resetMin()
        {
            _min = DefaultMin;
            _minIndex = 0;
            _removedSinceMin = 0;
        }

        private void _resetMax()
        {
            _max = DefaultMax;
            _maxIndex = 0;
            _removedSinceMax = 0;
        }
        private void _resetMinMax()
        {
            _resetMin();
            _resetMax();
        }
        
        private void Update(EvaluationContext context)
        {
            var addValueToList = AddValueToList.GetValue(context);
            var length = BufferLength.GetValue(context).Clamp(1, 100000);
            var newValue = Value.GetValue(context);

            var reset = Reset.GetValue(context);
            
            if(reset)
            {
                _resetMinMax();
                _list.Clear();
            }

            try
            {
                if (_list.Count != length)
                {
                    while (_list.Count < length)
                    {
                        _list.Add(0);
                    }
                }

                if (addValueToList)
                {

                    _list.Insert(0, newValue);
                    if (newValue < _min)
                    {
                        _min = newValue;
                        _minIndex = length;
                        _removedSinceMin = 0;
                    }

                    if (newValue > _max)
                    {
                        _max = newValue;
                        _maxIndex = length;
                        _removedSinceMax = 0;
                    }
                    
                    
                }

                if (_list.Count > length)
                {
                    _list.RemoveRange(length, _list.Count - length);
                    _minIndex--;
                    _maxIndex--;
                    if (_minIndex == 0)
                    {
                        _resetMin();
                    }

                    if (_maxIndex == 0)
                    {
                        _resetMax();
                    }
                    // _removedSinceMax++;
                    // _removedSinceMin++;
                    // if (_removedSinceMax == _maxIndex)
                    // {
                    //     _resetMax();
                    //}

                    //if (_removedSinceMin == _minIndex)
                    //
                    //    _resetMin();
                    //}
                    //System.Console.WriteLine(String.Format("Min: {0}, Max: {1}, rem: {2} idx {3}, {4} idx {5}", _min, _max, _removedSinceMin, _minIndex, _removedSinceMax, _maxIndex));
                }
                
                
                Max.Value = _max;
                Min.Value = _min;
                Result.Value = _list;
            }
            catch (Exception e)
            {
                Log.Warning("Failed to generate list:" + e.Message);
            }

        }

        private List<float> _list = new();
        private float _min = DefaultMin;
        private int _minIndex = 0;
        private float _max = DefaultMax;
        private int _maxIndex = 0;
        private int _removedSinceMax = 0;
        private int _removedSinceMin = 0;
        
        [Input(Guid = "33373d25-dabf-4a4a-97b4-fef45fcaac11")]
        public readonly InputSlot<float> Value = new();
        
        [Input(Guid = "1f2edafb-8913-4eb8-ba03-e1fe446381e7")]
        public readonly InputSlot<bool> AddValueToList = new();
        
        [Input(Guid = "29f6fca5-aaf5-49d7-abeb-f8c619c14436")]
        public readonly InputSlot<int> BufferLength = new();

        [Input(Guid = "40105da2-b094-4e06-bed5-10b2dc23fc7c")]
        public readonly InputSlot<bool> Reset = new();

        
    }
}