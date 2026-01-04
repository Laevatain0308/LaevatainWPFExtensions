namespace LaevatainWPFExtensions.ComboBoxExtension.Models
{
    /// <summary>
    /// 将 ComboBox 的 Item 虚构为一个 Pair ，包含 Name 属性 -- Item 的显示名称，Value 属性 -- Item 的依赖实例
    /// </summary>
    /// <typeparam name="T">依赖实例类型</typeparam>
    public class ComboBoxPair<T>
    {
        public string Name { get; set; }
        public T Value { get; set; }

        public ComboBoxPair(string name, T value)
        {
            Name = name;
            Value = value;
        }

        public override string ToString() => Name;
    }
}
