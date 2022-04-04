using System.Collections;

namespace WestPac.BuggyCarsRating.UITest.Support
{
    public static class CollectionExtensions
    {
        public static object GetValue(this IDictionary dictionary, object key)
        {
            if (dictionary.Contains(key))
                return dictionary[key];
            return null;
        }
    }
}
