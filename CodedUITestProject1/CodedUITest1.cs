using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace CodedUITestProject1
{
    using System.Diagnostics;

    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        public CodedUITest1()
        {
        }

        [TestMethod]
        public void TestCodedUIKeyboard()
        {
            var notepad = Process.Start("notepad.exe");

            var notepadWindow = new UITestControl();
            notepadWindow.TechnologyName = "MSAA";
            notepadWindow.SearchProperties.Add("ClassName", "Notepad");

            var editControl = new UITestControl(notepadWindow);
            editControl.SearchProperties.Add("ControlType", "Edit");

            Keyboard.SendKeys(editControl, "@");

            var actualText = editControl.GetProperty("Text");
            Assert.AreEqual("@", actualText);
            notepad.Kill();
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }
}
