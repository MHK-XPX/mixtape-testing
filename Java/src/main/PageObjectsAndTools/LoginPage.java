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


}
