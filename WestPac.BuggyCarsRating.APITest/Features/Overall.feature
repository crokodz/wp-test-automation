Feature: OverallPage
	Overall Page

@selenium
Scenario: Check Most Popular Car Sorted by Rank
	Given I get the overall data
	Then I should see list of models sorted by RanK
