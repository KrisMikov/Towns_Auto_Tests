using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Towns;

namespace TownsTests
{
    public class TownsProcessorTests
    {
        [Test]
        public void Test_Execute_Command_InvalidOperatiov()
        {
            var townProcessor = new TownsProcessor();
            var actual = townProcessor.ExecuteCommand("Osas");
            Assert.That(actual, Is.EqualTo("Invalid command: Osas"));
        }

        [Test]
        public void Test_Execute_Command_Create()
        {
            var townProcessor = new TownsProcessor();
            var createCommand = "CREATE Paris, London";
            var actual = townProcessor.ExecuteCommand(createCommand);
            Assert.That(actual, Is.EqualTo("Successfully created collection of towns."));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(2));
        }

        [Test]
        public void Test_Execute_Command_Print()
        {
            var townProcessor = new TownsProcessor();
            string createCommand = "CREATE Paris, London";
            townProcessor.ExecuteCommand(createCommand);

            var printCommand = "PRINT";

            var actual = townProcessor.ExecuteCommand(printCommand);
            Assert.That(actual, Is.EqualTo("Towns: Paris, London"));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(2));
        }

        [Test]
        public void Test_Execute_Command_Add()
        {
            var townProcessor = new TownsProcessor();
            string createCommand = "CREATE Paris, London";
            townProcessor.ExecuteCommand(createCommand);

            var addCommand = "ADD Sofia";

            var actual = townProcessor.ExecuteCommand(addCommand);
            Assert.That(actual, Is.EqualTo("Successfully added: Sofia"));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(3));
        }
    }
}
