package PageObjectsAndTools;
import PageObjectsAndTools.PageObject;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.interactions.Action;
import org.openqa.selenium.interactions.Actions;

import javax.script.ScriptContext;


public class LoginPage extends PageObject {


    public LoginPage(WebDriver driver) {
        super(driver);
    }

    public WebElement getNavItem(){return driver.findElement(By.cssSelector("[ngbdropdown]"));}

    public WebElement getButton() {return driver.findElement(By.cssSelector("button"));}

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

    public void goToMixTapeLogin() {
        driver.navigate().to(baseURL + "#/login");
    }

    public WebElement UserNameLogin(){
        WebElement username = driver.findElement(By.id("inputEmail3"));
        return username;
    }

    public WebElement PasswordLogin(){
        WebElement password = driver.findElement(By.id("inputPassword3"));
        return password;
    }

    public WebElement SignInButton(){
        WebElement button = driver.findElement(By.cssSelector("form > button"));
        return button;
    }

    public void MadilenaRobotLogin(){
        setLogin("MadilenaM" , "NickSurfsBirdRock");
    }
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
