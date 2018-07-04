Feature: Google search functionality
	Open the google page and search with keyword AVIVA
	verify the number of links returned and 
	print the 5th link text.

Background: 
 Given launch the google home page


@PositiveScenario
Scenario Outline: Search with Aviva keyword on Google home page and print the 5th link text
	And search with the string '<keyword>'
	When click on search button
    Then prints the 5th link text of results page.
	And number of links should be <count>
Examples:
	| keyword | count |
	| AVIVA   | 11    |

@NegativeScenario
Scenario Outline: Search with Aviva keyword on Google home page and Invalid login on AVIVA login page
    And search with the string '<keyword1>'
	When click on search button
	And I click on Aviva link and login button without providing credentials
	Then the result should be the error message display
Examples:
	| keyword1 |
	| AVIVA   |
