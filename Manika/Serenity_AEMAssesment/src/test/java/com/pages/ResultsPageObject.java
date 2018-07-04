package com.pages;

import org.openqa.selenium.By;
import net.serenitybdd.core.pages.WebElementFacade;
import net.serenitybdd.core.annotations.findby.FindBy;

import net.thucydides.core.pages.PageObject;

import java.util.List;

public class ResultsPageObject extends PageObject { 

    @FindBy(xpath="//a[@href='https://online.avivaindia.com/']")
    private WebElementFacade avivaLoginLink;
    
    @FindBy(id="lnkLogin")
    private WebElementFacade loginButton;
    
    @FindBy(xpath=".//h3/a")
    private List<WebElementFacade> noOfLinks;
    
    


    public String LinkText(int linkNumber) {
    	String linkText =noOfLinks.get(linkNumber-1).getText();
    	return linkText;
    }
    
    public int linkCount() {
    	return noOfLinks.size();
    }
    
    public void avivaLoginPage() {
    	avivaLoginLink.click();
    }
    
    public void invalidLogin() {
    	loginButton.click();
    }
    
    public String errorMessage() {
    	String text = getDriver().findElement(By.id("spnError")).getText();
    	return text;	
    }
}