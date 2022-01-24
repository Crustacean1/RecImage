namespace RecImage.Logic
{
    public class FilterFactory
    {
        public FilterFactory()
        {
        }
        private static IFilter CreateFilter<T>() where T : IFilter, new(){
            return new T();
        }
        private static Dictionary<string,Func<IFilter>> _filterDict = new Dictionary<string,Func<IFilter>>();
        public static void AddFilter<T>(string name) where T : IFilter, new(){
            if(_filterDict.ContainsKey(name)){
                throw new InvalidDataException("Can't have filters with the same names");
            }
            _filterDict[name] = CreateFilter<T>;

        }
        public static List<IFilter> buildFilters(IEnumerable<string> filterNames)
        {
            var result = new List<IFilter>();
            foreach (var filterName in filterNames)
            {
                if(_filterDict.ContainsKey(filterName)){
                    throw new ArgumentException("Invalid filter name");
                }
                var newFilter = _filterDict[filterName]();
                result.Add(newFilter);
            }
            return result;
        }
        public static List<string> GetFilterNames(){
            List<string> names = new List<string>();
            foreach(var name in _filterDict){
                names.Add(name.Key);
            }
            return names;
        }
    }
}