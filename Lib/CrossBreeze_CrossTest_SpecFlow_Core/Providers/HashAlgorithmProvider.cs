using System.Security.Cryptography;

namespace CrossBreeze.CrossTest.SpecFlow.Providers
{
    public class HashAlgorithmProvider
    {
        private static HashAlgorithm _hashAlgorithm;
        public static HashAlgorithm HashAlgorithm
        {
            get
            {
                if (_hashAlgorithm == null)
                    _hashAlgorithm = new MD5CryptoServiceProvider();
                return _hashAlgorithm;
            }
        }
    }
}
