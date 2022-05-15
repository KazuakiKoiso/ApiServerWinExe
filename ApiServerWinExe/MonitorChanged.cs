namespace ApiServerWinExe
{
    /// <summary>値の変更を検知できるクラス</summary>
    /// <typeparam name="T">対象の型</typeparam>
    public class MonitorChanged<T>
    {
        public delegate void ChangeHandler(T before, T after);
        public event ChangeHandler OnChanged;
        public event ChangeHandler OnChanging;

        public MonitorChanged() { }
        public MonitorChanged(T value)
        {
            _value = value;
        }

        private T _prevValue;
        private T _value;
        public T Value
        {
            get => _value;
            set
            {
                if(!_value.Equals(value))
                {
                    OnChanging?.Invoke(_value, value);
                    _prevValue = _value;
                    _value = value;
                    OnChanged?.Invoke(_prevValue, _value);
                }
            }
        }
    }
}
