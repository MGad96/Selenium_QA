using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;


[TestFixture]

public class webTableSort 
{
  public IDictionary<string, object> vars {get; private set;}
  [Test]
  public static void Main (string[] args) 
  {
        IWebDriver driver; 
        
    driver = new ChromeDriver();
    driver.Url = "https://the-internet.herokuapp.com/tables";
    driver.Manage().Window.Maximize();

    List <IWebElement> names = driver.FindElements(By.XPath("//table[@id='table1']/tbody/tr")).ToList();
    String[] sortByNames = new string [names.Count()];

    Console.WriteLine("*******NAMES BEFORE SORTING*******");

    //Looping through the list of names 
    for (int i=0; i<names.Count();i++) 
    {
      sortByNames[i] = names[i].Text;
      Console.WriteLine(sortByNames[i]);
    }
    // Sorting the list of names by alphabetical order 
    Array.Sort(sortByNames);
    Thread.Sleep(1000);
    // Automating the filtering process on the website by "last name" 
    driver.FindElement(By.XPath("//table[@id='table1']/thead/tr/th/span")).Click();

    Console.WriteLine("\n*******NAMES AFTER SORTING*******");

    for (int i=0; i<names.Count();i++) 
    {
      Console.WriteLine(sortByNames[i]);
    }
  }
}




