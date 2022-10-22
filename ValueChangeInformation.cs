namespace Credits
{
    public readonly struct ValueChangeInformation
    {
        public int OldValue { get; }
        public  int NewValue { get; }

        public ValueChangeInformation(int oldValue, int newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}