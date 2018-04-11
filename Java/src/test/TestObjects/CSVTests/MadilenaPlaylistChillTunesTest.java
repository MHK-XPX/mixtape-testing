package TestObjects.CSVTests;

import PageObjectsAndTools.LoginPage;
import PageObjectsAndTools.PageObject;
import org.testng.Assert;
import org.testng.annotations.DataProvider;
import org.testng.annotations.Test;

import TestObjects.BaseTest;

public class MadilenaPlaylistChillTunesTest extends BaseTest{
    //PageObject pageObject;
    LoginPage loginPage;

    public void setUp() {
        loginPage = new LoginPage(driver);
        loginPage.goToMixTapeLogin();
        loginPage.MadilenaRobotLogin();
    }

    String fileName = "/home/xpanxion/IdeaProjects/JavaMixtapeAutomation/mixtape-testing/Java/src/main/resources/MadilenaPlaylistChillTunes.csv";

    /**
     * @DataProvider gets the data from the csv file FooterLinksDataDrivenTests
     */
    @DataProvider(name = "csvFileLoader")
    public Object[][] getDataFromCSV() {
        return csvService.readCsv(fileName, true);
    }

    @Test(dataProvider = "csvFileLoader")
    public void  verifyData(String n1 , String n2 , String n3) {
        setUp();

        Assert.assertTrue(loginPage.runMadilenaPlaylist(n1, n2, n3) , " 'PLAYLIST' LINK DOES NOT NAVIGATE TO CORRECT PAGE");
    }
}

