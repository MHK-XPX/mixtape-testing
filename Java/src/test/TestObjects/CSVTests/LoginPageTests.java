package TestObjects.CSVTests;

import PageObjectsAndTools.LoginPage;
import PageObjectsAndTools.PageObject;
import TestObjects.BaseTest;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.testng.Assert;
import org.testng.annotations.Test;

public class LoginPageTests extends BaseTest{

    LoginPage loginPage;
    PageObject pageObject;
    /**
     * Asserts "Sign In" button is unclickable without a user name and password passed to the two
     * form fields
     */
    @Test
    public void blankpage(){
        System.out.println("Here we are");
        loginPage.getButton();
        Assert.assertTrue(loginPage.buttonBlock(),"page button is enabled");
    }

    @Test
    public void navItemDropDown(){
        loginPage.actionNavItem();
        Assert.assertTrue(loginPage.dropDownShow(), "Dropdown Button produces no dropdown");
    }

/*
    @Test
    public void signin(){
        pageObject.actionSignin();
        Assert.assertTrue(pageObject.getCurrentUrl().contains("home"), "Signin Failed");
    }
*/
}