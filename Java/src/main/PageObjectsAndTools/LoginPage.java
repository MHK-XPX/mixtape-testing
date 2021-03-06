package PageObjectsAndTools;
<<<<<<< Updated upstream
=======

import PageObjectsAndTools.BaseObject;
>>>>>>> Stashed changes
import PageObjectsAndTools.PageObject;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.interactions.Action;
import org.openqa.selenium.interactions.Actions;
import org.openqa.selenium.support.ui.WebDriverWait;

import javax.script.ScriptContext;


public class LoginPage extends PageObject {

    public LoginPage(WebDriver driver, WebDriverWait wait) {
        super(driver, wait);
    }

    public WebElement getNavItem(){return driver.findElement(By.cssSelector("[ngbdropdown]"));}

    public WebElement getButton() {
        return driver.findElement(By.cssSelector("form > button"));
    }

    public WebElement getDropDownItem() {return driver.findElement(By.cssSelector(".dropdown-item"));}

    public boolean buttonBlock() {return getButton().getAttribute("disabled").isEmpty();}

    public boolean dropDownShow() {return !getButton().getAttribute("class").contains("show");}

    public void actionNavItem() {
        Actions builder = new Actions(driver);
        Action action = builder
                .click(getNavItem())
                .click(getDropDownItem())
                .build();
        action.perform();
    }

    /**
     * takes you to the login page url
     */

    public void goToMixTapeLogin() {
        driver.navigate().to(baseURL + "#/login");
    }

    /**
     * @return username field
     */
    public WebElement UserNameLogin(){
        WebElement username = driver.findElement(By.id("inputEmail3"));
        return username;
    }

    /**
     * @return the password field
     */

    public WebElement PasswordLogin(){
        WebElement password = driver.findElement(By.id("inputPassword3"));
        return password;
    }

    /**
     * @return the "sign in" button
     */

    public WebElement SignInButton(){
        WebElement button = driver.findElement(By.cssSelector("form > button"));
        return button;
    }

    /**
     * creates the login for Madilena's mixtape page
     */
    public void MadilenaRobotLogin(){
        setLogin("MadilenaM" , "NickSurfsBirdRock");
    }

    /**
     * sends login credentials to the username and password fields
     * @param UsernameSearchText the username you want to input
     * @param PasswordSearchText the password you want to input
     */
    public void setLogin(String UsernameSearchText , String PasswordSearchText) {
        goToMixTapeLogin();
        UserNameLogin().clear();
        UserNameLogin().sendKeys(UsernameSearchText);
        PasswordLogin().clear();
        PasswordLogin().sendKeys(PasswordSearchText);
        SignInButton().click();

        try {
            Thread.sleep(5000);
        } catch (InterruptedException e) {
            System.out.println("DID NOT WAIT BEFORE CLICKING ENTER");
        }
    }
}
