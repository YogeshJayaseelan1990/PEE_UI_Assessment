
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using NUnit.Framework;
using PEI_UI_Ass.PagesObjects;
using PEI_UI_Ass.Baseclass;
using PEI_UI_Ass.PageObjects;

namespace PEI_UI_Ass.TestCases
{
    public class LoginTest :BaseTest

    {
        private Dictionary<string, Dictionary<string, string>> dictionary;

        private LoginPage loginPage;
        //public LoginTest()
        //{
        //    DataFromExcel();
        //}

        [SetUp]
        public void DataFromExcel()
        {

            //String basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace("bin\\debug\\net6.0", "InputData\\");
            String basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            String path = Path.Combine(basePath, @"InputData\LoginTest.csv");
           
            dictionary = Import(path);
        }

        [Test]
        public void Perform_Login()
        {
            driver.Navigate().GoToUrl(D365Url);
            LoginPage loginPage = new LoginPage(driver);
            loginPage.TypeUserName(dictionary["LoginPage"]["UserName"]);
            loginPage.TypePassword(dictionary["LoginPage"]["PassWord"]);
            Homepage homepage = loginPage.ClickLoginBtn();
            homepage.GetHomePageHeader();

        }

        //Dictionary Import method to get the input formt the Excel file
        public Dictionary<string, Dictionary<string, string>> Import(String path)
        {
            Dictionary<String, Dictionary<String, String>> dict = new Dictionary<string, Dictionary<string, string>>();
            dict.Add("LoginPage", File.ReadLines(path).Select(line => line.Split(',')).Where(line => line[0].Equals("LoginPage")).ToDictionary(line => line[1], line => line[2]));
            return dict;
        }
    }
}
