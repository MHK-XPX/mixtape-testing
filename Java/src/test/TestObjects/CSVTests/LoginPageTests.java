package TestObjects.CSVTests;

import TestObjects.BaseTest;
import org.testng.Assert;
import org.testng.annotations.Test;

import java.io.IOException;

/**
 * Tests the functionality of the login screen
 */
public class LoginPageTests extends BaseTest{
    /**
     * Asserts "Sign In" button is unclickable without a user name and password passed to the two
     * form fields
     */
    @Test
    public void blankpage(){
        Assert.assertTrue(loginPage.getButton().getAttribute("disabled").equals("true"),"page button is enabled");
    }

    /**
     * Asserts the dropdown button in upper left corner produces a dropdown
     */
    @Test
    public void navItemDropDown(){
        loginPage.actionNavItem();
        Assert.assertTrue(loginPage.dropDownShow(), "Dropdown Button produces no dropdown");
    }

    /**
     * Asserts the signin functions correctly.  Uses the csv "Profile_Info" to enter the password
     */
    @Test
    public void signin() throws IOException {
        loginPage.setLogin("hvincent", loginPage.getCSVInfo(0, 3));
        Assert.assertTrue(loginPage.signedIn(), "Signin Failed");
    }
}
