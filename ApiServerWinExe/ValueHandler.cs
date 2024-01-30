namespace ApiServerWinExe
{
    /// <summary>値の変更を検知できるクラス</summary>
    /// <typeparam name="T">対象の型</typeparam>
    public class ValueHandler<T>
    {
        /// <summary>値変更イベントの型定義</summary>
        /// <param name="before">変更前の値</param>
        /// <param name="after">変更後の値</param>
        public delegate void ChangeHandler(T before, T after);

        /// <summary>値変更後に発生するイベント</summary>
        public event ChangeHandler OnChanged;

        /// <summary>値変更前に発生するイベント</summary>
        public event ChangeHandler OnChanging;

        /// <summary>コンストラクタ</summary>
        public ValueHandler()
        { }

        /// <summary>コンストラクタ</summary>
        /// <param name="value">監視対象の値</param>
        public ValueHandler(T value)
        {
            _value = value;
        }

        /// <summary>変更前の値</summary>
        private T _prevValue;

        /// <summary>現在の値</summary>
        private T _value;

        /// <summary>現在の値</summary>
        public T Value
        {
            get => _value;
            set
            {
                if (!_value.Equals(value))
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