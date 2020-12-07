using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

[TestFixture]
public class DynamiccontrolsTest {
    public int SleepTime = 5000;
  private IWebDriver driver;
  
  [SetUp]
  public void SetUp() 
  {
    driver = new ChromeDriver();
  }

  [TearDown]
  protected void TearDown() {
    driver.Quit();
  }
  [Test]
  public void dynamiccontrols() {
      
    driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_controls");
    Thread.Sleep(SleepTime);
    driver.Manage().Window.Maximize();
    Thread.Sleep(SleepTime);
    driver.FindElement(By.CssSelector("#checkbox > input")).Click();
    Thread.Sleep(SleepTime);
    driver.FindElement(By.CssSelector("#checkbox-example > button")).Click();
    Thread.Sleep(SleepTime);
    driver.FindElement(By.CssSelector("button:nth-child(1)")).Click();
    Thread.Sleep(SleepTime);
    driver.FindElement(By.CssSelector("button:nth-child(2)")).Click();
    Thread.Sleep(SleepTime);
    driver.FindElement(By.CssSelector("#input-example > input")).SendKeys("dsada");
    Thread.Sleep(SleepTime);
    driver.FindElement(By.CssSelector("button:nth-child(2)")).Click();
  }
}
