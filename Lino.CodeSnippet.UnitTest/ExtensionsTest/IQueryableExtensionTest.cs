using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Lino.CodeSnippet.Extensions;

namespace Lino.CodeSnippet.UnitTest
{
    [TestClass]
    public class IQueryableExtensionTest
    {
        [TestMethod]
        public void QueryTest()
        {
            var list = Enumerable.Range(1, 10).Select(o => string.Join("", Enumerable.Repeat("A", o))).ToList();

            string queryStr = null;
            var result = list.AsQueryable().Query(o => string.IsNullOrEmpty(queryStr) || o.Equals(queryStr)).ToList();
            Assert.IsNotNull(result);
            Assert.AreEqual<int>(list.Count, result.Count);

            queryStr = "AAA";
            result = list.AsQueryable().Query(o => string.IsNullOrEmpty(queryStr) || o.Equals(queryStr)).ToList();
            Assert.IsNotNull(result);
            Assert.AreEqual<string>(queryStr, result.FirstOrDefault());
        }
    }
}
