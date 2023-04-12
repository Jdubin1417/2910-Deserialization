namespace Deserialization
{
    public class MonsterAction
    {
        public string Name { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{Name} -- {Desc}";
        }
    }
}
