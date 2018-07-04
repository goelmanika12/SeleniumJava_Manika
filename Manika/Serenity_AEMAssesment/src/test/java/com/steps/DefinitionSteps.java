package com.steps;

import cucumber.api.java.en.Given;
import cucumber.api.java.en.Then;
import cucumber.api.java.en.When;
import net.thucydides.core.annotations.Steps;

import com.steps.serenity.EndUserSteps;

public class DefinitionSteps {
	
	@Steps
	EndUserSteps EndUser;
	
	@Given("^launch the google home page$")
	public void launch_the_google_home_page(){
	    EndUser.openGoogleSearch();
	}


	@Given("^search with the string \"([^\"]*)\"$")
	public void search_with_the_string(String keyword) {
		EndUser.searchKeyword(keyword);
	}

	@When("^click on search button$")
	public void click_on_search_button() {
	    EndUser.clickSearch();
	}
	
	@Then("^print the '(\\d+)' link text of results page\\.$")
	public void print_the_link_text_of_results_page(int index) throws Exception {
		EndUser.getLinkText(index);
	}


	@Then("^Links should be returned\\.$")
	public void print_the_number_of_links_returned() throws Exception {
		EndUser.verifyNumberOfLinks();
	}


	@Then("^I click on Aviva link and login button without providing credentials$")
	public void i_click_on_Aviva_link_and_login_button_without_providing_credentials(){
	    EndUser.invalidAvivaLogin();
	}



	@Then("^the result should be the error \"([^\"]*)\" display$")
	public void the_result_should_be_the_error_display(String message) {
		EndUser.verifyErrorMessage(message);
	}

	
}
