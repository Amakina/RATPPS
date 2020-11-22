using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RATPPS1
{
    [TestFixture]
    public class Tests
    {
        private string jsonTest = "{\"K\":10,\"Sums\":[1.01,2.02],\"Muls\":[1,4]}";
        private string xmlTest = "<Input><K>10</K><Sums><decimal>1.01</decimal><decimal>2.02</decimal></Sums><Muls><int>1</int><int>4</int></Muls></Input>";

        private string jsonExpected = "{\"SumResult\":30.30,\"MulResult\":4,\"SortedInputs\":[1.0,1.01,2.02,4.0]}";
        private string xmlExpected = "<Output><SumResult>30.30</SumResult><MulResult>4</MulResult><SortedInputs><decimal>1</decimal><decimal>1.01</decimal><decimal>2.02</decimal><decimal>4</decimal></SortedInputs></Output>";

        private Input expectedInput = new Input()
        {
            K = 10,
            Sums = new[] { 1.01m, 2.02m },
            Muls = new[] { 1, 4 }
        };

        [Test]
        public void DeserializeJson()
        {

            var input = JSONParser.Deserialize<Input>(jsonTest);

            Assert.AreEqual(input, expectedInput);
        }

        [Test]
        public void SerializeJson()
        {

            var input = JSONParser.Deserialize<Input>(jsonTest);

            var output = new Output(input);

            var result = JSONParser.Serizalize(output);

            Assert.AreEqual(jsonExpected, result);
        }

        [Test]
        public void DeserializeXML()
        {

            var input = XMLParser.Deserialize<Input>(xmlTest);

            Assert.AreEqual(input, expectedInput);
        }

        [Test]
        public void SerializeXML()
        {

            var input = XMLParser.Deserialize<Input>(xmlTest);

            var output = new Output(input);

            var result = XMLParser.Serizalize(output);

            Assert.AreEqual(xmlExpected, result);
        }
    }
}
