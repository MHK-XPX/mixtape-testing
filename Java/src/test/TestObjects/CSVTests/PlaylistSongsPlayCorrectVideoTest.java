package TestObjects.CSVTests;

import PageObjectsAndTools.LoginPage;
import PageObjectsAndTools.PageObject;
import org.testng.Assert;
import org.testng.annotations.DataProvider;
import org.testng.annotations.Test;

import TestObjects.BaseTest;

public class PlaylistSongsPlayCorrectVideoTest extends BaseTest{
    PageObject pageObject;
    LoginPage loginPage;

    public void setUp() {
        loginPage = new LoginPage(driver);
        loginPage.goToMixTapeLogin();
    }

    String fileName = "/home/xpanxion/IdeaProjects/JavaMixtapeAutomation/mixtape-testing/Java/src/main/resources/MadilenaPlaylistChillTunes.csv";

    /**
     * @DataProvider gets the data from the csv file PlaylistSongsPlayCorrectVideo
     */

    @DataProvider(name = "csvFileLoader")
    public Object[][] getDataFromChillTunesCSV() {
        return csvService.readCsv(fileName, true);
    }

    @Test(dataProvider = "csvFileLoader")
    public void verifyPlaylistAndSongAndVideo(String n1,String n2,String n3) {
        setUp();
        loginPage.setLogin("MadilenaM", "NickSurfsBirdRock");
        Assert.assertTrue(loginPage.runPlaylistLinksMethod(n1,n2,n3) , " PLAYLIST SONG DOES NOT GENERATE THE EXPECTED MUSIC VIDEO");
    }
}

