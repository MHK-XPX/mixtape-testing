package PageObjectsAndTools;

import org.apache.commons.lang3.StringUtils;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.interactions.Action;
import org.openqa.selenium.interactions.Actions;
import org.openqa.selenium.support.PageFactory;

import java.util.List;

/**
 * <p>Base PageObject class.
 *
 * <p>This class is the intended root class for all Selenium Page Objects.  All page objects should
 * extend this class, and provide the Selenium WebDriver object as an argument constructor to
 * interact with the current web page.
 *
 *
 */
public class PageObject {

    protected WebDriver driver;

    static String URL = "https://mhk-xpx.github.io/mixtape-frontend/#/home";

    public WebElement getYouTubeButton(){
        WebElement youTubeButton = driver.findElement(By.cssSelector(".ytp-youtube-button ytp-button yt-uix-sessionlink"));
        return youTubeButton;
    }

    public String getYouTubeVideoName(){
        String videoName = driver
                .findElement(By.cssSelector(".title style-scope ytd-video-primary-info-renderer"))
                .getText();
        return videoName;
    }

    /**
     * Instantiates this PageObject and subsequently loads all of the WebElements associated
     * with this PageObject, annotated with @FindBy and other Selenium PageFactory annotations.
     *
     * <p>This constructor assumes the required page has already been opened and loaded.
     *
     * @param driver The WebDriver object to use. This should be passed in from the test method.
     */
    public PageObject(WebDriver driver) {

        this(driver, null);
    }

    /**
     * Instantiates this PageObject and subsequently loads all of the WebElements associated
     * with this PageObject, annotated with @FindBy and other Selenium PageFactory annotations.
     *
     * <p>If <b>url</b> is provided, that URL will be opened prior to instantiation.
     *
     * @param driver The WebDriver object to use. This should be passed in from the test method.
     * @param url The URL to load prior to instantiation.
     */
    public PageObject(WebDriver driver, String url) {
        this.driver = driver;

        if (!StringUtils.isEmpty(url)) {
            this.driver.get(url);
        }
        this.load();
    }

    /**
     * Initializes the PageFactory annotated WebElements associated with this PageObject instance.
     *
     * This method is called as a consequence of creating a new instance of this PageObject.
     */
    public void load() {
        PageFactory.initElements(this.driver, this);
    }


/**
 * Clicks link, navigates to new page, and verifies that the title of the page equals the expected title.
 * @param link we are testing
 * @param expected title of page navigated to
 * @return boolean as to whether the title of the page navigated to equals the expected title
 */

    public boolean runPlaylistLinksMethod(String link, String expected) {
    clickPlaylistSong(link);
    getYouTubeButton().click();
    String title = getYouTubeVideoName();
    return title.equals(expected);
    }

    /**
     Clicks the links specified from Requirement 1.
     */
    protected void clickPlaylistSong(String link) {
        driver
                .findElement(By.cssSelector(".col-12 playlist-container playlist-song-list shadow margin-top ng-tns-c4-0"))
                .findElement(By.linkText(link))
                .click();
    }

    public void goToMixTapeHome() {
        driver.navigate().to(URL);
    }

    public WebElement getNavItem(){return driver.findElement(By.cssSelector("[ngbdropdown]"));}

    public WebElement getButton() {return driver.findElement(By.cssSelector("button"));}

    public WebElement getDropDownItem() {return driver.findElement(By.cssSelector(".dropdown-item"));}

    public boolean buttonBlock() {return getButton().getAttribute("disabled").equals("null");}

    public boolean dropDownShow() {return !getButton().getAttribute("class").contains("show");}

    public void actionNavItem() {
        Actions builder = new Actions(driver);
        Action action = builder
                .click(getNavItem())
                .click(getDropDownItem())
                .build();
        action.perform();
    }


    public void actionSignin() {
        Actions builder = new Actions(driver);
        builder
            .sendKeys(getSigninField(0), "hvincent")
            .sendKeys(getSigninField(1), "d1r9a8g5o")
            .click(getButton())
            .build()
            .perform();
    }

    private WebElement getSigninField(int i) {return driver.findElements(By.cssSelector("form > input")).get(i);}

    public boolean frontEnd() {return driver.getCurrentUrl().contains("home");}
}
