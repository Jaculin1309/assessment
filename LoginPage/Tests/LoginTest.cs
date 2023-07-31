using LoginPage.Source;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace LoginPage.Tests
{
    [TestFixture]
    public class LoginTest
    {
        private LoginModule loginModule;

        [SetUp]
        public void TestInitialize()
        {
            loginModule = new LoginModule(new ChromeDriver());
        }

        [Test]
        [TestCase("standard_user", "secret_sauce")]
        [TestCase("locked_out_user", "secret_sauce")]
        [TestCase("problem_user", "secret_sauce")]
        [TestCase("performance_glitch_user", "secret_sauce")]
        public void Test_Login_With_Different_Users(string username, string password)
        {
            // Arrange: Navigate to the login page
            Console.WriteLine("Navigating to the login page.");
            loginModule.Driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            // Act: Perform the login using LoginModule and different users
            Console.WriteLine($"Performing login with username: {username} and password: {password}");
            loginModule.EnterUsername(username);
            loginModule.EnterPassword(password);
            loginModule.ClickLoginButton();

            // Assert: Check if the login is successful or failed based on the user
            if (username == "locked_out_user")
            {
                NUnit.Framework.Assert.IsTrue(loginModule.Driver.Url.Contains("locked_out"), "Login was expected to fail for locked_out_user.");
            }
            else
            {
                NUnit.Framework.Assert.IsTrue(loginModule.Driver.Url.Contains("dashboard"), "Login was not successful. Redirect to dashboard failed.");
            }
        }
    }
}
