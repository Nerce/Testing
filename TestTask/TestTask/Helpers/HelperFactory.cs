using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace TestTask
{
    [Binding]
    public class HelperFactory
    {
        public static By SelectorByAttributeValue(string pStrAttributeName, string pStrAttributeValue)
        {
            return (By.XPath(string.Format(("//*[@{0} = '{1}']"), pStrAttributeName, pStrAttributeValue)));
        }
    }
}