using System.Windows.Controls;
using LaevatainWPFExtensions.ComboBoxExtension.Models;

namespace LaevatainWPFExtensions.ComboBoxExtension.Helpers
{
    public static class ComboBoxPairHelper
    {
        private const string DisplayMemberPath = "Name";
        private const string SelectedValuePath = "Value";


        /// <summary>
        /// 根据 ComboBoxPair 列表，填充 ComboBox 容器
        /// </summary>
        /// <typeparam name="T">ComboBox 内容物依赖类</typeparam>
        /// <param name="box">待填充 ComboBox</param>
        /// <param name="pairs">ComboBoxPair 列表</param>
        /// <param name="defaultItemIndex">默认项索引</param>
        /// <param name="isEditable">是否可编辑</param>
        public static void FillComboBox<T>(ref ComboBox box, List<ComboBoxPair<T>> pairs, int defaultItemIndex = 0,
            bool isEditable = false)
        {
            if (box == null) return;
            if (pairs == null || pairs.Count < 0) return;

            if (defaultItemIndex < 0 || defaultItemIndex >= pairs.Count)
                defaultItemIndex = 0;

            box.ItemsSource = pairs;

            box.DisplayMemberPath = DisplayMemberPath;
            box.SelectedValuePath = SelectedValuePath;
            box.SelectedItem = pairs[defaultItemIndex];

            box.IsEditable = isEditable;
        }


        /// <summary>
        /// 手动构造 ComboBoxPair 列表，当传入参数为空时返回 null
        /// </summary>
        public static List<ComboBoxPair<T>> CreatePairsList<T>(params ComboBoxPair<T>[] pairs)
        {
            return pairs ? .ToList() ?? [];
        }


        /// <summary>
        /// 根据 枚举类型的所有枚举值 自动生成 ComboBoxPair 列表
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        public static List<ComboBoxPair<TEnum>> CreatePairsListFromEnum<TEnum>() where TEnum : Enum
        {
            var enumValues = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
            var pairs = enumValues.Select(
                value => new ComboBoxPair<TEnum>(value.ToString() , value)
                ).ToList();

            return pairs;
        }


        /// <summary>
        /// 根据 枚举类型的所有枚举值 与 自定义命名规则 自动生成 ComboBoxPair 列表
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="nameConverter">自定义命名规则</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">自定义命名规则为 null</exception>
        public static List<ComboBoxPair<TEnum>> CreatePairsListFromEnum<TEnum>(Func<TEnum , string> nameConverter) where TEnum : Enum
        {
            // 当 nameConverter 为 null 抛出异常
            ArgumentNullException.ThrowIfNull(nameConverter);

            var enumValues = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
            var pairs = enumValues.Select(
                value => new ComboBoxPair<TEnum>(nameConverter(value), value)
                ).ToList();

            return pairs;
        }
    }
}
