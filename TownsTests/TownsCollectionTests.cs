using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownsTests
{
    public class TownsCollectionTests
    {

        [Test]
        public void Test_Constructor_EmptyConstructor()
        {
            var gradove = new TownsCollection(); 
            Assert.That(gradove.Towns.Count, Is.EqualTo(0));
            Assert.That(gradove.ToString(), Is.Empty); 
        }

        [Test]
        public void Test_Constructor_SingleTown()
        {
            var gradove = new TownsCollection("Paris");
            Assert.That(gradove.Towns.Count, Is.EqualTo(1));
            Assert.That(gradove.ToString(), Is.EqualTo("Paris"));
        }

        [Test]
        public void Test_Constructor_TwoTowns()
        {
            var gradove = new TownsCollection("Paris, London");
            Assert.That(gradove.Towns.Count, Is.EqualTo(2));
            Assert.That(gradove.ToString(), Is.EqualTo("Paris, London"));
        }

        [Test]
        public void Test_Constructor_Add_SingleTown()
        {
            var gradove = new TownsCollection("Paris, London");
            gradove.Add("Sofia");
            Assert.That(gradove.ToString(), Is.EqualTo("Paris, London, Sofia"));
        }

        [Test]
        public void Test_Constructor_Add_Empty()
        {
            var gradove = new TownsCollection();
            gradove.Add("");
            Assert.That(gradove.ToString(), Is.EqualTo(""));
        }

        [Test]
        public void Test_Constructor_Add_Duplicate_Town()
        {
            var gradove = new TownsCollection("Paris, London");
            gradove.Add("Paris");
            Assert.That(gradove.Towns.Count, Is.EqualTo(2));
            Assert.That(gradove.ToString(), Is.EqualTo("Paris, London"));
        }


        [Test]
        public void Test_Constructor_Remove_At_Index()
        {
            var gradove = new TownsCollection("Paris, London");
            gradove.RemoveAt(0);
            Assert.That(gradove.Towns.Count, Is.EqualTo(1));
            Assert.That(gradove.ToString(), Is.EqualTo("London"));
        }

        [Test]
        public void Test_Constructor_Remove_At_Invalid_Index()
        {
            var gradove = new TownsCollection("Sofia, Plovdiv");
            Assert.That(() => gradove.RemoveAt(5), Throws.InstanceOf<ArgumentException>()); //ili samo Exeprion

        }

        [Test]
        public void Test_Reverse_Index()
        {
            var gradove = new TownsCollection("Paris, London");
            gradove.Reverse();
            Assert.That(gradove.Towns.Count, Is.EqualTo(2));
            Assert.That(gradove.ToString(), Is.EqualTo("London, Paris"));
        }

        [Test]
        public void Test_Reverse_Index_One_Town()
        {
            var gradove = new TownsCollection("London");
            Assert.That(() => gradove.Reverse(), Throws.InstanceOf<Exception>());
           
        }
    

    }
}
