package com.pages;

import net.serenitybdd.core.annotations.findby.FindBy;
import net.serenitybdd.core.pages.WebElementFacade;
import net.thucydides.core.annotations.DefaultUrl;
import net.thucydides.core.pages.PageObject;

@DefaultUrl("https://www.google.co.uk")
public class GoogleSearchPageObject extends PageObject {

    @FindBy(name="q")
    private WebElementFacade searchInput;

    @FindBy(name="btnK")
    private WebElementFacade searchButton;

    public void enter_keyword(String keyword) {
        searchInput.type(keyword);
    }

    public void lookup_keyword() {
        searchButton.submit();
    }


}