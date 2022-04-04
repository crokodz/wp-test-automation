Feature: LoginPage
	Login to Buggy Cars Rating

@selenium
Scenario: Login
	Given I login to the page
	Then I should see 'Hi'
