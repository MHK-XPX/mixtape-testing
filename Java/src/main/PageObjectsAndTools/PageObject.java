package PageObjectsAndTools;

import org.apache.commons.lang3.StringUtils;
import org.openqa.selenium.By;
import org.openqa.selenium.Keys;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.interactions.Action;
import org.openqa.selenium.interactions.Actions;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;
import org.openqa.selenium.support.ui.ExpectedConditions;
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
    static String URL = "https://mhk-xpx.github.io/mixtape-frontend/#/home";
    protected WebDriver driver;
    protected WebDriverWait wait;
    protected String baseURL = "https://mhk-xpx.github.io/mixtape-frontend/";

    public WebElement getYouTubeButton(){
        WebElement youTubeButton = driver.findElement(By.xpath("//a[@class= 'ytp-youtube-button ytp-button yt-uix-sessionlink']"));
        return youTubeButton;
    }

    public String getYouTubeVideoName(){
        String videoName = driver
                .findElement(By.xpath("//h1[@class = 'title style-scope ytd-video-primary-info-renderer']"))
                .getText();
        return videoName;
    }

    /*public void goToMixTapeHome() {
        driver.navigate().to(baseURL + "#/home");
    }*/

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

    public WebElement getMixtapeLogo(){
        WebElement logo = driver.findElement(By.xpath("//h4[@class = d'-inline']"));
        return logo;
    }

    public WebElement getPlaylistLogo(){
        WebElement playlistlogo = driver.findElement(By.xpath("//div[@class = 'card-header text-center font-weight-bold']"));
        return playlistlogo;
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
        wait = new WebDriverWait(driver, 20);
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
 * Clicks songLink, navigates to new page, and verifies that the title of the page equals the expectedVideoName title.
 * @param songLink we are testing
 * @param expectedVideoName title of page navigated to
 * @return boolean as to whether the title of the page navigated to equals the expectedVideoName title
 */
    public boolean runMadilenaPlaylist(String playlistLink , String songLink, String expectedVideoName){
        MadilenaRobotLogin();
        return runPlaylistLinksMethod(playlistLink , songLink, expectedVideoName);
    }

    public boolean runPlaylistLinksMethod(String playlistLink , String songLink, String expectedVideoName) {
        clickDesiredPlaylist(playlistLink);
        clickPlaylistSong(songLink);
        getYouTubeButton().click();
        String title = getYouTubeVideoName();
        goToMixTapeHome();
        return title.equals(expectedVideoName);
    }

    /**
     Clicks the links specified from Requirement 1.
     */
    protected void clickPlaylistSong(String songLink) {
        driver
                .findElement(By.xpath("//div[@class = 'card ng-tns-c4-10']"))
                .findElement(By.linkText(songLink)).click();
        try {
            Thread.sleep(5000);
        } catch (InterruptedException e) {
            System.out.println("DID NOT WAIT BEFORE CLICKING ENTER");
        }
    }

    protected void clickDesiredPlaylist(String playlistLink){
        wait.until(ExpectedConditions.visibilityOf(getPlaylistLogo()));
        driver.findElement(By.cssSelector(".col-sm-2 shadow no-padding"))
                .findElement(By.linkText(playlistLink))
                .click();
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

