Feature: Verification H1 tag
	As a User
	I want to verify that CASES, SERVICES and JOBS pages has H1 tag in each page

@HeaderTitleH1Tag
Scenario Outline: H1 tag is displaying
	Given I am on the valtech homepage 
	 When I navigate to '<PageTitle>' page 
	 Then I should see '<PageTitleName>' title displayed
   Scenarios:
	| PageTitle | PageTitleName |
	| CASES     | Cases         |
	| SERVICES  | Services      |
	| JOBS      | Jobs          |