using System.Runtime.Serialization.Formatters.Binary;

namespace CrossBreeze.CrossTest.SpecFlow.Providers
{
    public class BinaryFormatterProvider
    {
        private static BinaryFormatter _binaryFormatter;
        public static BinaryFormatter BinaryFormatter
        {
            get
            {
                if (_binaryFormatter == null)
                    _binaryFormatter = new BinaryFormatter();
                return _binaryFormatter;
            }
        }
    }
}
