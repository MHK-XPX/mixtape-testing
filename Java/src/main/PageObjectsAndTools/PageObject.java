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

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.List;
/**
 * <p>Base PageObject class.
 *
 * <p>This class is the intended root class for all Selenium Page Objects.  All page objects should
 * extend this class, and provide the Selenium WebDriver object as an argument constructor to
 * interact with the current web page.
 */
public class PageObject {
    static String URL = "https://mhk-xpx.github.io/mixtape-frontend/#/home";
    protected WebDriver driver;
    protected WebDriverWait wait;
    protected String baseURL = "https://mhk-xpx.github.io/mixtape-frontend/";
    protected LoginPage loginPage;
    protected String PROFILEINFO = "main/resources/Profile_Info";
    protected BufferedReader br = new BufferedReader(new FileReader(PROFILEINFO));

    /**
     * @return youtubebutton webelement within the video that is displayed when a song is played.
     */

    public WebElement getYouTubeButton(){
        WebElement youTubeButton = driver.findElement(By.cssSelector("youtube-player"));
        return youTubeButton;
    }

    /**
     * @return the text of the video name that youtube displays
     */

    public String getYouTubeVideoName(){
        String videoName = driver
                .findElement(By.xpath("//h1[@class = 'title style-scope ytd-video-primary-info-renderer']"))
                .getText();
        return videoName;
    }

    public void goToMixTapeHome() {
        driver.navigate().to(baseURL + "#/home");
    }



    public WebElement getMixtapeLogo(){
        WebElement logo = driver.findElement(By.xpath("//h4[@class = d'-inline']"));
        return logo;
    }

    /**
     * @return the playlist header above the list of playlists you make
     */

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
    public PageObject(WebDriver driver, WebDriverWait wait) throws FileNotFoundException {
        this.driver = driver;
        this.wait = wait;
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
    public PageObject(WebDriver driver, String url) throws FileNotFoundException {
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
     * runMadilenaPlaylist will run the songs within a specific playlist of Madilena and then check that they generate
     * an expected youtube video
     * @param playlistLink selects a playlist from Madilena's mixtape page
     * @param songLink selects a song from a specific playlist within Madilena's mixtape page
     * @param expectedVideoName the name of the video that YouTube displays
     * @return a boolean value as to whether the title that youtube displays is truly the desired titled
     */

    public boolean runMadilenaPlaylist(String playlistLink , String songLink, String expectedVideoName){
        loginPage.MadilenaRobotLogin();
        return runPlaylistLinksMethod(playlistLink , songLink, expectedVideoName);
    }

    /**
     * runPlaylistLinksMethod will run the songs within a specific playlist of a mixtape page and then chack that they
     * generate the correct youtube video
     * @param playlistLink selects a playlist from mixtape page
     * @param songLink selects a song from a specific playlist within mixtape page
     * @param expectedVideoName the name of the video that YouTube displays
     * @return a boolean value as to whether the title that youtube displays is truly the desired titled
     */

    public boolean runPlaylistLinksMethod(String playlistLink , String songLink, String expectedVideoName) {
        clickDesiredPlaylist(playlistLink);
        clickPlaylistSong(songLink);
        getYouTubeButton().click();
        String title = getYouTubeVideoName();
        goToMixTapeHome();
        return title.equals(expectedVideoName);
    }

    /**
     Clicks playlist song
     */

    public WebElement getNavItem(){return driver.findElement(By.cssSelector("[ngbdropdown]"));}

    public WebElement getButton() {
        return driver.findElement(By.cssSelector("button"));
    }

    public WebElement getDropDownItem() {return driver.findElement(By.cssSelector(".dropdown-item"));}

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

    /**
     * clicks a desired playlist within a mixtape page
     * @param playlistLink the playlist you want to click
     */

    protected void clickDesiredPlaylist(String playlistLink){
        wait.until(ExpectedConditions.visibilityOf(getPlaylistLogo()));
        driver.findElement(By.cssSelector(".col-sm-2 shadow no-padding"))
                .findElement(By.linkText(playlistLink))
                .click();
    }

    public boolean frontEnd() {return driver.getCurrentUrl().contains("home");}

    public boolean signedIn() {
        wait.until(ExpectedConditions.elementToBeClickable(getYouTubeButton()));
        return true;
    }

    public String getCSVInfo(int i, int j) throws IOException {
        String line = Files.readAllLines(Paths.get(PROFILEINFO)).get(i);
        String info[] = line.split(",");
        return info[j];
    }

}

