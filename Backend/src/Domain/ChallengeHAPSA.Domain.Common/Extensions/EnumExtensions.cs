using System.ComponentModel.DataAnnotations;

namespace ChallengeHAPSA.Domain.Common.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());

            if (field is null)
                return value.ToString();

            var attribute = Attribute.GetCustomAttribute(field, typeof(DisplayAttribute)) as DisplayAttribute;

            return attribute?.Name ?? value.ToString();
        }

        public static IEnumerable<EnumModel> GetItems<T>() where T : Enum
        {
            return ((T[])Enum.GetValues(typeof(T))).Select(x => new EnumModel(Convert.ToInt32(x), x.GetDisplayName()));
        }
    }

    public class EnumModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        internal EnumModel(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public EnumModel()
        {

        }
    }
}
