Feature: Add Vote
	Login and Vote

@selenium
Scenario: Add Vote
	Given I login to the page
	Then I should see 'Hi'
	When I goto model page with car id 'c4u1mqnarscc72is00e0%7Cc4u1mqnarscc72is00kg'
	Then I should see 'Diablo'
	And I add comment 'Damn Diablo'
	Then I should see 'Damn Diablo'