package PageObjectsAndTools;

import PageObjectsAndTools.services.WaitUtils;
import org.apache.commons.lang3.StringUtils;
import org.openqa.selenium.By;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

import org.openqa.selenium.interactions.Actions;
import org.openqa.selenium.support.PageFactory;

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
    WaitUtils waitUtils;

    public static final long DEFAULT_DELAY_MS = 1000;

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


    public String getVideoTitleText(){
        getPauseButton().click();
        driver.switchTo().frame(driver.findElement(By.cssSelector("youtube-player>iframe")));
        String title = driver.findElement(By.cssSelector("div.ytp-chrome-top.ytp-share-button-visible > div.ytp-title > div.ytp-title-text ")).getText();
        waitUtils.hardWait(DEFAULT_DELAY_MS);
        driver.switchTo().defaultContent();
        return title;
    }

    public WebElement getPauseButton(){
        return driver.findElement(By.id("playPauseButton"));
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
        waitUtils.hardWait(DEFAULT_DELAY_MS);
        clickPlaylistSong(songLink);
        waitUtils.hardWait(DEFAULT_DELAY_MS);
        String title = getVideoTitleText();
        waitUtils.hardWait(DEFAULT_DELAY_MS);
        return title.equals(expectedVideoName);
    }

    /**
     Clicks playlist song
     */

    protected void clickPlaylistSong(String songLink) {
        driver
                .findElement(By.xpath("//*[text()[contains(. , '"+songLink+"')]]"))
                .click();
        waitUtils.hardWait(5000);
    }

    /**
     * clicks a desired playlist within a mixtape page
     * @param playlistLink the playlist you want to click
     */

    protected void clickDesiredPlaylist(String playlistLink){
       driver
               .findElement(By.xpath("//*[text()[contains(. , '"+playlistLink+"')]]"))
               .click();
    }

}

