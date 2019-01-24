Feature: Contact Total offices
	As a User
	I want to output how many Valtech offices there arer in total on the contact page

@TotalOffices
Scenario: Total offices
	Given I am on the valtech homepage 
	 When I navigate to the contact page 
	 Then I should see a total '30' offices
