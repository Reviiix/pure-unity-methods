namespace pure_unity_methods
{
    /// <summary>
    /// This ValueChangeInformation struct is just an alternative to using key value pairs or tuples or something that give greater control/descriptions of the data
    /// </summary>
    public readonly struct ValueChangeStruct
    {
        public long OldValue { get; }
        public  long NewValue { get; }

        public ValueChangeStruct(long oldValue, long newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}