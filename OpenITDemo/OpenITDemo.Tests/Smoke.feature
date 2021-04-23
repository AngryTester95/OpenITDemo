Feature: Smoke
	Smoke Suite for Twitter

Scenario Outline: Log In
	Given Open Twitter with <Device>
	Then Login page is loaded
	When I do Log In with OpenITDemoUser user
	Then Account page is loaded
	And I logged in with OpenITDemoUser user

	Examples:
		| Device  |
		| Browser |
		| Desktop |
		| Android |

Scenario Outline: Tweet
	Given Open Twitter with <Device>
	Then Login page is loaded
	When I do Log In with OpenITDemoUser user
	Then Account page is loaded
	When I tweet Hello OpenIT from {device}!!! {rand:5}
	Then My tweet is posted

	Examples:
		| Device  |
		| Browser |
		| Desktop |
		| Android |