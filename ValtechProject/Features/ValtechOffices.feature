
@FunctionalTest
Feature: Count the number of valtech offices
	In order to count the number of valtech offices
	As a user
	I want to be to be able to verify number of valtech offices


Scenario: Verify number of valtech offices in the world
   Given I choose to navigate to valtech
    When I choose to navigate to 'Contact' page
    Then I should see the page title displayed
	 And I should see a total '37' offices
