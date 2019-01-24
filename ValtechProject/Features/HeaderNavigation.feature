
@FunctionalTest
Feature: Header links navigation
	In order to navigation to the header link
	As a user
	I want to be to sure that the correct page header is displayed when I navigate to the page via the header links


Scenario Outline: Select the first blog article displayed
   Given I choose to navigate to valtech
    When I choose to navigate to '<name>' page
    Then I should see the page title displayed
	 And I should see '<name>' title displayed
Scenarios: 
	| name     |
	| About    |
	| Work     |
	| Services |