using System;
using System.Globalization;
using System.Resources;

namespace iPOS.Core.Helper
{
    public class Lang
    {
        public static string GetMessageByLanguage(string _key, CultureInfo _culture, ResourceManager _manager)
        {
            _culture = new CultureInfo(new Configuration().Language);
            return (string.IsNullOrEmpty(_key)) ? "" : _manager.GetString(_key, _culture);
        }
    }
}
