Feature: Locate element by text

Background:
	Given I am on the home page
	When I navigate to the example named 'Dynamic Controls'
	And I remove the checkbox

Scenario: Element with exact text
	Then I can locate a message with exact text 'It's gone!'

Scenario: Element that contains text
	Then I can locate a message that contains text 'gon'

Scenario: Element that starts with text
	Then I can locate a message that starts with text 'It'

Scenario: Element that ends with text
	Then I can locate a message that ends with text 'one!'