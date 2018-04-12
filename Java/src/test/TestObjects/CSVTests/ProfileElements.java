package TestObjects.CSVTests;

import PageObjectsAndTools.ProfileArea;
import TestObjects.BaseTest;
import org.testng.Assert;
import org.testng.annotations.Test;
import java.io.FileNotFoundException;
import java.io.IOException;

public class ProfileElements extends BaseTest {
    ProfileArea profileArea = new ProfileArea(driver, wait);

    public ProfileElements() throws FileNotFoundException {
    }

    @Test
    public void profileMade(){
        Assert.assertTrue(profileArea.isVisible(), "Profile not visible");
    }

    @Test
    public void usernameMatches(){
        String username = profileArea.getProfileInfo(2);
        Assert.assertTrue(profileArea.getH6Text().equals(username));
    }

    @Test
    public void checkInfoFirstName() throws IOException {
        boolean match = profileArea.getProfileInfo(0) == profileArea.getCSVInfo(0, 0);
        Assert.assertTrue(match, "First name does not match");
    }

    @Test
    public void checkInfoLastName() throws IOException {
        boolean match = profileArea.getProfileInfo(1) == profileArea.getCSVInfo(0, 1);
        Assert.assertTrue(match, "First name does not match");
    }

    @Test
    public void checkInfoUserName() throws IOException {
        boolean match = profileArea.getProfileInfo(2) == profileArea.getCSVInfo(0, 2);
        Assert.assertTrue(match, "First name does not match");
    }

    @Test
    public void changePassword() throws IOException {
        profileArea.actionChangePassword(true);
        Assert.assertTrue(profileArea.snackBarOpacity(), "No change password confirmation");
    }

    @Test
    public void passwordFail() throws IOException {
        profileArea.actionChangePassword(false);
        Assert.assertTrue(profileArea.submitButtonDisabled(), "No cancellation confirmation");
    }


}
