using System;
using System.IO;
using NUnit.Framework;

namespace HousesApiTest
{
    [TestFixture]
    public class BaseTest
    {
        [OneTimeSetUp]
        public void Init()
        {
            Environment.CurrentDirectory = Path.GetDirectoryName(GetType().Assembly.Location);
        }   
    }
}