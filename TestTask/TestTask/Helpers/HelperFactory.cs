﻿using OpenQA.Selenium;

namespace TestTask
{
    public class HelperFactory
    {
        public static By SelectorByAttributeValue(string pStrAttributeName, string pStrAttributeValue)
        {
            return (By.XPath(string.Format(("//*[@{0} = '{1}']"), pStrAttributeName, pStrAttributeValue)));
        }
    }
}