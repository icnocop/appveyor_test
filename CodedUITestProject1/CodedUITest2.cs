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
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

    /// <summary>
    /// Summary description for CodedUITest2
    /// </summary>
    [CodedUITest]
    public class CodedUITest2
    {
        [TestMethod]
        public void CodedUITestMethod1()
        {
            var calc = Process.Start("calc.exe");

            var calcWindow = new WinWindow();
            
            calcWindow.SearchProperties[WinWindow.PropertyNames.Name] = "Calculator";
            calcWindow.SearchProperties[WinWindow.PropertyNames.ClassName] = "CalcFrame";
            calcWindow.WindowTitles.Add("Calculator");
            calcWindow.TechnologyName = "MSAA";

            WinText textControl = new WinText(calcWindow);
            textControl.SearchProperties[WinText.PropertyNames.Name] = "Result";

            Keyboard.SendKeys(textControl, "{NumPad1}{Add}{NumPad1}{Enter}");

            var actualText = textControl.DisplayText;
            Assert.AreEqual("2", actualText);
            calc.Kill();
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
