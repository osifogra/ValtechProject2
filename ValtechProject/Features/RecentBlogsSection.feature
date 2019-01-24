
@FunctionalTest
Feature: Recent blogs section is displayed
	In order to displayed the recent blogs section
	As a user
	I want to be to sure that the recent blogs section is displayed and view the first blog


Scenario: Verify that the recent blogs section is displayed and view the first blog
   Given I choose to navigate to valtech
    Then I should see the 'RECENT BLOGS' section displayed
    When I choose to view the '1st' blog article
    Then I should see the page title displayed
