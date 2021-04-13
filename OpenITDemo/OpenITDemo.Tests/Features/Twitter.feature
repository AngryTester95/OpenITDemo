Feature: Twitter
	Twitter feature

@web
Scenario Outline: Login to Twitter
	Given I open a browser <browser>
	When Navigate to https://www.twitter.com
	And login with <login> login and <password> password
	Then user should be logged on

@web
Scenario Outline: Create a tweet
	Given I open a browser <browser>
	When Navigate to https://www.twitter.com
	And login with <login> login and <password> password
	And create a tweet with hello, OpenIT conference content
	Then tweet with hello, OpenIT conference content should be created

Examples: 
| browser | login     | password     |
| chrome  | demo_open | zaq123ZAQ!@# |
| firefox | demo_open | zaq123ZAQ!@# |