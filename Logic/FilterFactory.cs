namespace RecImage.Logic
{
    public class FilterFactory
    {
        public FilterFactory()
        {
        }
        private static IFilter createFilterByName(string filterName)
        {
            switch (filterName)
            {
                case "Inverse":
                    return new InverseFilter();
                case "Flip":
                    return new FlipFilter();
                case "Blur":
                    return new BlurFilter();
                default:
                    return null;
            }
        }
        public static List<IFilter> buildFilters(IEnumerable<string> filterNames)
        {
            var result = new List<IFilter>();
            foreach (var filterName in filterNames)
            {
                var newFilter = createFilterByName(filterName);
                if (newFilter == null)
                {
                    throw new ArgumentException("Invalid filter name passed");
                }
                result.Add(newFilter);
            }
            return result;
        }
    }
}