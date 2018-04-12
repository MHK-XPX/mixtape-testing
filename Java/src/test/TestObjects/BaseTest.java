package TestObjects;

import java.io.FileNotFoundException;
import java.io.IOException;
import java.lang.reflect.Method;
import java.net.MalformedURLException;
import PageObjectsAndTools.LoginPage;
import PageObjectsAndTools.PageObject;
import io.github.bonigarcia.wdm.WebDriverManager;
import org.openqa.selenium.MutableCapabilities;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.chrome.ChromeOptions;
import org.openqa.selenium.edge.EdgeDriver;
import org.openqa.selenium.edge.EdgeOptions;
import org.openqa.selenium.firefox.FirefoxDriver;
import org.openqa.selenium.firefox.FirefoxDriverLogLevel;
import org.openqa.selenium.firefox.FirefoxOptions;
import org.openqa.selenium.ie.InternetExplorerDriver;
import org.openqa.selenium.ie.InternetExplorerOptions;
import org.openqa.selenium.opera.OperaDriver;
import org.openqa.selenium.opera.OperaOptions;
import org.openqa.selenium.safari.SafariDriver;
import org.openqa.selenium.safari.SafariOptions;
import org.openqa.selenium.support.ui.WebDriverWait;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.testng.annotations.*;
import PageObjectsAndTools.services.CSVService;

/**
 * This class is the main testing class. Extend this class from a test class to
 * create a WebDriver object and gain access to it to use for testing.
 */

public class BaseTest {

    public static final Logger LOG = LoggerFactory.getLogger(BaseTest.class);

    /**
     * The WebDriver object for use in testing. Since the scope is protected,
     * the object will be available to all sub-classes.
     */

    protected WebDriver driver;
    protected WebDriverWait wait;
    protected LoginPage loginPage;
    static String URL = "https://mhk-xpx.github.io/mixtape-frontend/#/login";
    /**
     * Singleton CSVService object available to all classes.
     */
    public static final CSVService csvService = new CSVService();

/*    *//**
     * Sets up for the test driver and grabs any test parameters.
     * @param  browser gets browser to be used
     * @param signin decides whether to signin or not
     * @throws MalformedURLException
     * @throws InterruptedException
     *//*
    @Parameters({"selenium.browser"})
    @BeforeTest
    public void setupTest( String browser ) throws MalformedURLException, InterruptedException {
        if (browser == null)
            browser = "chrome";
        MutableCapabilities options = setupOptions(browser);
        driver = this.localWebDriver(options);
        wait = new WebDriverWait(driver, 10);
    }*/

    /**
     * This method is executed before a test method begins, using TestNG's @BeforeMethod
     * annotation. This method is primarily responsible for obtaining a unique
     * WebDriver object for the test to use.
     */
    @Parameters({"selenium.browser", "username", "password"})
    @BeforeMethod
    public void setup(Method m, String browser, String username, String password) throws IOException {
        LOG.debug("Initializing WebDriver...");
        LOG.debug("Finished initializing WebDriver!");
        LOG.debug("Beginning Test '{}'...", this.getTestName(m));
        MutableCapabilities options = setupOptions(browser);
        driver = this.localWebDriver(options);
        wait = new WebDriverWait(driver, 10);
        driver.get(URL);
        loginPage = new LoginPage(driver, wait);
        if (!username.isEmpty()){
            loginPage.setLogin(loginPage.getCSVInfo(0, 2), loginPage.getCSVInfo(0, 3));
        }else{
            loginPage = new LoginPage(driver, wait);
        }
    }

    /**
     * This method is executed after a test method has completed, using TestNG's @AfterMethod
     * annotation. This method is primarily responsible for taking care of all
     * clean up tasks, so that more tests may be run.
     */
    @AfterMethod
    public void teardown(Method m) {
        LOG.debug("Finished Test '{}'.", this.getTestName(m));
        LOG.debug("Tearing down WebDriver...");
        LOG.debug("Finished tearing down WebDriver!");
        driver.close();
    }

    private WebDriver localWebDriver(MutableCapabilities options) {
        switch (options.getClass().getSimpleName()) {
            case "FirefoxOptions":
                WebDriverManager.getInstance(FirefoxDriver.class).setup();
                FirefoxDriver firefox = new FirefoxDriver((FirefoxOptions) options);
                return firefox;

            case "InternetExplorerOptions":
                WebDriverManager.getInstance(InternetExplorerDriver.class).setup();
                InternetExplorerDriver ie = new InternetExplorerDriver((InternetExplorerOptions) options);
                return ie;
            case "SafariOptions":
                // WebDriverManager does not support safari, cause Apple =P
                SafariDriver safari = new SafariDriver((SafariOptions) options);
                return safari;

            case "EdgeOptions":
                WebDriverManager.getInstance(EdgeDriver.class).setup();
                EdgeDriver edge = new EdgeDriver((EdgeOptions) options);
                return edge;

            case "OperaOptions":
                WebDriverManager.getInstance(OperaDriver.class).setup();
                OperaDriver opera = new OperaDriver((OperaOptions) options);
                return opera;

            case "ChromeOptions":
            default:
                WebDriverManager.getInstance(ChromeDriver.class).setup();
                ChromeDriver chrome = new ChromeDriver((ChromeOptions) options);
                return chrome;
        }
    }

    private MutableCapabilities setupOptions(String browser) {
        switch (browser.toLowerCase()) {
            case "firefox":
                FirefoxOptions firefox = new FirefoxOptions();
                firefox.setLogLevel(FirefoxDriverLogLevel.ERROR);
                firefox.setHeadless(false);
                return firefox;

            case "ie":
                InternetExplorerOptions ie = new InternetExplorerOptions();
                ie.destructivelyEnsureCleanSession();
                ie.enablePersistentHovering();
                return ie;

            case "safari":
                SafariOptions safari = new SafariOptions();
                return safari;

            case "edge":
                EdgeOptions edge = new EdgeOptions();
                return edge;

            case "opera":
                OperaOptions opera = new OperaOptions();
                return opera;

            case "chrome":
            default:
                ChromeOptions chrome = new ChromeOptions();
                chrome.setHeadless(false);
                return chrome;
        }

    }

    /**
     * Provided a test <tt>Method</tt> object, returns the name of the test.
     * @param m The method argument
     * @return The name of the test.
     */
    private String getTestName(Method m) {
        return m.getName();
    }
}
