using System.Reflection;
using FastMember;

namespace ValueCopier
{
    public static class ObjectExtension
    {
        public static T Assign<T>(T target, params T[] sources)
        {
            var defaultValue = default(T);
            var targetAccessor = ObjectAccessor.Create(target);
            var targetProperties = target.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var source in sources)
            {
                var sourceAccessor = ObjectAccessor.Create(source);
                foreach (var targetProperty in targetProperties)
                {
                    var value = sourceAccessor[targetProperty.Name];
                    if (value != null && !value.Equals(defaultValue))
                        targetAccessor[targetProperty.Name] = value;
                }
            }

            return target;
        }
    }
}
