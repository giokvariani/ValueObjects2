using CSharpFunctionalExtensions;

namespace ValueObjects
{
    public class Symbol : SimpleValueObject<char>
    {
        public Symbol(char value) : base(value)
        {
        }
        public static Symbol Semicolon = new(';');
        public static Symbol Dot = new('.');
        public static Symbol OpenBracket = new('(');
        public static Symbol CloseBracket = new(')');
        public static Symbol Dash = new('—');
        public static Symbol SmallDash = new('-');
        public static Symbol Slash = new('/');
        public static Symbol Space = new(' ');
        public string StringValue => Value.ToString();
    }
}