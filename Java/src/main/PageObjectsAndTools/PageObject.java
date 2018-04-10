package PageObjectsAndTools;

import org.apache.commons.lang3.StringUtils;
import org.openqa.selenium.By;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

/**
 * <p>Base PageObject class.
 *
 * <p>This class is the intended root class for all Selenium Page Objects.  All page objects should
 * extend this class, and provide the Selenium WebDriver object as an argument constructor to
 * interact with the current web page.
 */

public class PageObject {

    protected WebDriver driver;
    protected WebDriverWait wait;
    protected String baseURL = "https://mhk-xpx.github.io/mixtape-frontend/";
    LoginPage loginPage;

    /**
     * @return youtubebutton webelement within the video that is displayed when a song is played.
     */

    public WebElement getYouTubeButton(){
        WebElement youTubeButton = driver.findElement(By.xpath("//a[@class= 'ytp-youtube-button ytp-button yt-uix-sessionlink']"));
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
     * runPlaylistLinksMethod will run the songs within a specific playlist of a mixtape page and then check that they
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

}

