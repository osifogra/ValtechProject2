Feature: Latest News Verification
	As a User
	I want to verify that the Latest News section is displaying in the home page

@LatestNewsSection
Scenario: Latest News section is displaying
	Given I am on the valtech homepage 
	 Then I should see the 'LATEST NEWS' section 
