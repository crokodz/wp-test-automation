Feature: OverallPage
	Overall Page

@selenium
Scenario: Check Most Popular Car
	Given I goto overall page
	Then I should see 'Diablo'
