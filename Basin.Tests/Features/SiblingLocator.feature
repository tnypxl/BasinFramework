Feature: Sibling Locator

Background:
	Given I am on the home page
	When I navigate to the example named 'Large & Deep DOM'

Scenario: Locates an element by its following element
	Then I can locate element '1.3' that follows element '1.2'

Scenario: Locates an element by its preceding element
	Then I can locate element '1.2' that precedes element '1.3'