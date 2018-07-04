package com;

import org.junit.runner.RunWith;

import cucumber.api.CucumberOptions;
import net.serenitybdd.cucumber.CucumberWithSerenity;

@RunWith(CucumberWithSerenity.class)
@CucumberOptions(features="src/test/resources/features/consult_dictionary/AvivaScenarios.feature"
,glue={"com.steps"}
//, tags={"@PositiveScenario , @NegativeScenario"}
)
public class Runner {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}

}
