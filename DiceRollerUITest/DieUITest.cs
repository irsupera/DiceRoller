using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace DiceRollerUITest
{
    [TestFixture(Platform.Android)]
    public class DieUITest
    {
        IApp app;
        Platform platform;

        public DieUITest(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        //[Test]
        //public void WelcomeTextIsDisplayed()
        //{
        //    AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to Xamarin.Forms!"));
        //    //AppResult[] results = app.WaitForElement(c => c.Marked("xdfsdgfas!"));
        //    Assert.IsTrue(results.Any());
        //}

        [Test]
        [Category("UI")]
        public void PromptLabelIsDisplayed()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("Select a die:"));
            Assert.IsTrue(results.Any());
        }

        [Test]
        [Category("UI")]
        public void OptionsAreDisplayed()
        {
            //single line option
            Assert.IsTrue(app.Query(c => c.Marked("d4")).Any());
            Assert.IsTrue(app.Query(c => c.Marked("d6")).Any());
            Assert.IsTrue(app.Query(c => c.Marked("d8")).Any());
            Assert.IsTrue(app.Query(c => c.Marked("d10")).Any());
            Assert.IsTrue(app.Query(c => c.Marked("d12")).Any());
            //multi line option
            AppResult[] results = app.Query(c => c.Marked("d20"));
            Assert.IsTrue(results.Any());
        }

        [Test]
        [Category("UI")]
        public void OptionsCanBeChecked()
        {
            app.Tap(c => c.Marked("d4"));
            
            Assert.IsTrue(app.Query(c =>
            c.Marked("d4")          //look for items marked d4
            .Invoke("isChecked"))   //call the isChecked method of radiobutton
                .FirstOrDefault()
                .Equals(true));

            app.Tap(c => c.Marked("d6"));

            Assert.IsTrue(app.Query(c =>
            c.Marked("d6")          //look for items marked d6
            .Invoke("isChecked"))   //call the isChecked method of radiobutton
                .FirstOrDefault()
                .Equals(true));

            Assert.IsTrue(app.Query(c =>
            c.Marked("d4")          //look for items marked d4
            .Invoke("isChecked"))   //call the isChecked method of radiobutton
                .FirstOrDefault()
                .Equals(false));

        }

        [Test]
        [Category("UI")]
        public void RollButtonsAreDisplayed()
        {
            //Assert.IsTrue(app.Query("Display one result").Any());
            //Assert.IsTrue(app.Query("Display two results").Any());

            //AppResult[] results = app.Query(c => c.Property("text").Contains("Display "));
            AppResult[] results = app.Query(c => c.Property("text").Like("Display * result*"));
            Assert.IsTrue(results.Length == 2);
        }

        [Test]
        [Category("UI")]
        public void ButtonsCanBeClickedAndResultsAreDisplayed()
        {
            app.Tap(c => c.Marked("Display one result"));

            AppResult[] results = app.Query(c => c.Property("text").Like("'*'"));
            Assert.IsTrue(results.Length == 1);

            app.Tap(c => c.Marked("Display two results"));
            AppResult[] results2 = app.Query(c => c.Property("text").Like("'*'"));
            Assert.IsTrue(results2.Length == 2);
        }
    }
}
