package com.steps.serenity;

import com.pages.GoogleSearchPageObject;
import com.pages.ResultsPageObject;
import net.thucydides.core.annotations.Step;
import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertTrue;

public class EndUserSteps {
	
	GoogleSearchPageObject gPage;
    ResultsPageObject rPage;;

    @Step
    public void openGoogleSearch() {
        gPage.open();
    }

    @Step
    public void searchKeyword(String keyword) {
        gPage.enter_keyword(keyword);
    }
    
    @Step
    public void clickSearch() {
        gPage.lookup_keyword();
    }

    @Step
    public void verifyNumberOfLinks() {
        int totalLinksCount = rPage.linkCount();
        System.out.println("Total links count is: "+totalLinksCount);
        assertTrue(totalLinksCount>0);
    }

    @Step
    public void getLinkText(int index) {
        String link_text = rPage.LinkText(index);
        System.out.println("5th link text is: "+link_text);
    }

    @Step
    public void invalidAvivaLogin() {
        rPage.avivaLoginPage();
        rPage.invalidLogin();
    }
    
    @Step
    public void verifyErrorMessage(String message) {
        String errorDisplay = rPage.errorMessage();
        assertEquals(message, errorDisplay);
    }
}