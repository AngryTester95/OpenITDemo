Feature: Smoke
	Smoke Suite for Twitter

Scenario: Log In
	Given Open Twitter with Desktop
	Then Login page is loaded
	When I do Log In with OpenITDemoUser user
	Then Account page is loaded
	And I logged in with OpenITDemoUser user

Scenario: Log In
	Given Open Twitter with Desktop
	Then Login page is loaded
	When I do Log In with OpenITDemoUser user
	Then Account page is loaded
	When I tweet Hello OpenIT!!! {rand:5}
	Then My tweet is posted