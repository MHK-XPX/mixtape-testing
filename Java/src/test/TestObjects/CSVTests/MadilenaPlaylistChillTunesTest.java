package TestObjects.CSVTests;

import PageObjectsAndTools.PageObject;
import org.testng.Assert;
import org.testng.annotations.DataProvider;
import org.testng.annotations.Test;

import TestObjects.BaseTest;

public class MadilenaPlaylistChillTunesTest extends BaseTest{
    PageObject pageObject;

/*    public void setUp() {
        pageObject = new PageObject(driver, wait);
        pageObject.goToMixTapeHome();
    }*/

    String fileName = "/home/xpanxion/IdeaProjects/JavaMixtapeAutomation/mixtape-testing/Java/src/main/resources/MadilenaPlaylistChillTunes.csv";

    /**
     * @DataProvider gets the data from the csv file FooterLinksDataDrivenTests
     */
    @DataProvider(name = "csvFileLoader")
    public Object[][] getDataFromCSV() {
        return csvService.readCsv(fileName, true);
    }

    @Test(dataProvider = "csvFileLoader")
<<<<<<< Updated upstream
    public void  verifyData(String n1 , String n2 , String n3) {
        setUp();
        Assert.assertTrue(pageObject.runMadilenaPlaylist(n1, n2, n3) , " 'PLAYLIST' LINK DOES NOT NAVIGATE TO CORRECT PAGE");
=======
    public void  verifyData(String n1 , String n2) {
        //setUp();
        Assert.assertTrue(pageObject.runPlaylistLinksMethod(n1, n2) , " 'PLAYLIST' LINK DOES NOT NAVIGATE TO CORRECT PAGE");
>>>>>>> Stashed changes
    }
}

