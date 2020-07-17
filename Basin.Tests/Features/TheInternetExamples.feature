Feature: Basin Functional Tests

	I must know about cats. I MUST!

	Background:
		Given I am on the home page

	Scenario: Locates an element added to the page
		When I navigate to the example named 'Add/Remove Elements'
		And I add an element to the page
		Then I can see 1 Delete button has been added
